using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

/********************************************/
/*
 * TODO
 * WDT (Z)
 * WDT prescaler (Z)
 * irgendwas mit TRISA und TRISB
 * EEPROM Funktionen (Z)
 * RB-Interrupt nur bei Input Pins.
 * Funktionsgenerator
 * timer mit microsecondtimers austauschen: http://www.codeproject.com/Articles/98346/Microsecond-and-Millisecond-NET-Timer
 * 
 */


/*
 * TODO Fragen
 * fragen zum Steuerpult step out, step over,... (so schnell wie möglich)
 * Quarzfreguenz + laufzeitzähler
 * Wie weit bezüglich input/output PortA/PortB (schreiben zu einem input schreibt in den Latch,sobald auf Input umgeschalten wird, wird der latch in den Port geladen)
 */




namespace PIC_Simulator
{
    delegate void BEFEHLSFUNKTIONEN(int codezeile); //Zeiger auf die Befehlsfunktionen

    public partial class Form1 : Form
    {
        public String[] code;   //alle  Zeilen des Dokumentes
        public int[] codezeile; //Zeilenummern die verwertbaren Code enthalten; beginnen im Dokument mit 1 anstatt 0, dashalb bei Ausgabe +1 addieren
        public int[] Befehl;//enthält den Befehl(zweiter 4-stelliger Code) der Codezeile als int ;(Byte 5-8)
        
        
        public Boolean NOP = false; //wenn NOP= true, dann wird die nächste Anweisung übersprungen
        Stack TOS = new Stack(); //Top of Stack Liste; FiLo-Liste ; enthält 8 Werte
       
        Boolean[] breakpoint;//Boolwert ob die Zeile einen Breakpoint enthält
        Boolean reset = false;//wenn dieser Wert true ist wird das laufende Programm abgebrochen
        Boolean stepout = false;//wenn dieser wert true ist wird das laufende Programm abgebrochen sobald es auf ein return trifft;
        Boolean stepover = false;//bestimmt ob sich das Programm im stepovermodus befindet
        int temp_breakpoint = -1;//temporärer Breakpoint für stepover
        String contextmenustrip_aufrufer = "";
        

        Laufzeitzähler laufzeitzähler = new Laufzeitzähler();
        Quarzfrequenz quarzfrequenz = new Quarzfrequenz();
        internal Register register;
        internal Programmcounter PC;
        internal Funktionsgenerator FG;
        internal Interrupt interrupt;
        internal Befehle befehle;

        static BEFEHLSFUNKTIONEN[] Befehlsfunktionen = new BEFEHLSFUNKTIONEN[35];//Zeiger auf die Befehlsfunktionen

        

        public Form1()
        {
            InitializeComponent();
            initialize_my_Component();
        }

        //Hex-Code des Befehls in ein Int umwandeln
        public int extrahiere_befehle(int zeilennummer)
        {
            char[] hilf = code[zeilennummer].ToCharArray();
            for (int i = 0; i < 4; i++) 
            {
                hilf[i] = hilf[5 + i];
            }
            Array.Resize(ref hilf, 4);
            String hilf2 = new String(hilf);
            return Convert.ToInt32(hilf2, 16);
        }

        //finde die Zeilen in denen ausführbarer code steht (Byte 1-4 müssen hexzahlen enthalten)
        public void extrahiere_codezeilen()
        {
            int zaehler=0;
            int[] temp_int = new int[code.Length];
            Befehl = new int[code.Length];
            for (int i = 0; i < code.Length;i++)
            {
                char[] temp = code[i].ToCharArray();
                if (!String.IsNullOrEmpty(code[i]) && (temp[0] <= '9' && temp[0] >= '0' || temp[0] <= 'F' && temp[0] >= 'A'))
                { //trifft zu wenn erstes Zeichen eine Hex-Ziffer ist.
                    temp_int[zaehler] = i;
                    Befehl[zaehler] = extrahiere_befehle(i);
                    zaehler++;
                }
            }
            Array.Resize(ref Befehl, zaehler);
            Array.Resize(ref temp_int, zaehler);
            codezeile=temp_int;
            breakpoint = new Boolean[zaehler];
            for (int i = 0; i < zaehler; i++)
                breakpoint[i] = false;
        }

        //Datei laden
        public void laden(String dateiname)
        {
            try
            {
                using (StreamReader sr = new StreamReader(dateiname))
                {
                    String line = sr.ReadToEnd();
                    richTextBox1.Text = line;
                    code = richTextBox1.Lines;
                    sr.Close();
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("Datei konnte nicht geladen werden:\n"+f.Message);
            }
            extrahiere_codezeilen();
            Power_On_Reset();
            
            Code_anzeigen();
            Speicher_grid_befüllen();
            markiere_zeile(codezeile[0]);
            update_port_datagrids();
            update_SpecialFunctionRegister();

            //Button für reset, start und step enablen
            StartStopButton.Enabled = true;
            resetButton.Enabled = true;
            StepInButton.Enabled = true;
            StepOverButton.Enabled = true;
            IgnoreButton.Enabled = true;
            StepOutButton.Enabled = true;
        }

        /*****************************************************************************************************/
        //Reset

        //TODO welcher Reset ist der Button-Reset?
        
        public void Power_On_Reset()
        {
            //Manual Seite 27
            register.Power_on_Reset();

            //Variableninitiation
            PC.PCH = 0;
            interrupt.init();
            NOP = false;
            Ra4_alt = (Byte)(register.Speicher[Register.porta] & 0x10);
            prescaler = 0;
            stepout = false;
            stepover = false;
            temp_breakpoint = -1;
            reset = false;

            for (int i = 0; i < breakpoint.Length; i++)
                breakpoint[i] = false;

            update_SpecialFunctionRegister();
            update_port_datagrids();
        }

        public void MCLR()
        {
            //manual Seite 27
            //during: normal Operation, sleep
            //WDT-Reset during normal operation
            PC.set(0);
            register.MCLR();
            //TODO wie beeinflusst das die Variablen?

            update_SpecialFunctionRegister();
            update_port_datagrids();
        }

        public void Wakeup_from_sleep()
        {
            //manual seite 27
            //Through interrupt
            //through WDT Time-out
            PC.erhöhen();
            register.Wakeup_from_Sleep();
            //TODO wie beeinflusst das die Variablen

            update_port_datagrids();
            update_SpecialFunctionRegister();
        }

        //Resets Ende
        /***********************************************************************************************/

        //enthält sämtliche Interruptfunktionen und wird von einem Timer alle 50ms ausgeführt
        private void interrupttimer_Tick(object sender, EventArgs e)
        {
            interrupt.Flags_setzen();
        }

        //zeigt die Register in einem DataGridView an
        public void Speicher_grid_befüllen()
        {
            for (int i = 0; i < 256; i++)
                dataGridView_Speicher[i % 8, i / 8].Value = register.Speicher[i].ToString("X2");
        }

        //aktuallisiert ein Speicherregister im DataGridView
        public void Speicher_grid_updaten(int adresse)
        {
            adresse %= 256;
            dataGridView_Speicher[adresse % 8, adresse / 8].Value = register.Speicher[adresse].ToString("X2");
        }

        public void Code_anzeigen()
        {
            dataGridView_code.RowCount = code.Length;
            for(int i=0;i<code.Length;i++)
            {
                try
                {
                    dataGridView_code[1, i].Value = code[i];
                }
                catch(Exception e)
                {
                    MessageBox.Show("Hups, es ist ein Fehler aufgetreten\n" + e.Message);
                }
            }
        }

        private void ladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) 
            {
                if (openFileDialog1.FileName != null) 
                {
                    laden(openFileDialog1.FileName);
                }
            }
        }

        private void schließenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            register = new Register(this);
            PC = new Programmcounter(this, register);
            FG = new Funktionsgenerator(this, register);
            interrupt = new Interrupt(this, register, TOS, PC);
            befehle = new Befehle(this, register, PC, TOS);

            int i = 0;
            foreach (string arg in Environment.GetCommandLineArgs())
            {
                if (i == 1)
                {
                    char[] temp = arg.ToCharArray();
                    int laenge=temp.Length;
                    //prüft ob die angegebene Datei eine LST-Datei ist
                    if (temp[laenge - 4] == '.' && (temp[laenge - 3] == 'L' || temp[laenge - 3] == 'l') && (temp[laenge - 2] == 'S' || temp[laenge - 2] == 's') && (temp[laenge - 1] == 'T' || temp[laenge - 1] == 't'))
                        laden(arg);
                    else
                        MessageBox.Show("Bitte geben sie eine LST-Datei an");
                } 
                i++;
            }
            Speicher_grid_befüllen();

         
            //Array der Befehlsfunktionen initialisieren
            Befehlsfunktionen[tokens.addwf] = befehle.addwf;
            Befehlsfunktionen[tokens.andwf] = befehle.andwf;
            Befehlsfunktionen[tokens.clrf] = befehle.clrf;
            Befehlsfunktionen[tokens.clrw] = befehle.clrw;
            Befehlsfunktionen[tokens.comf] = befehle.comf;
            Befehlsfunktionen[tokens.decf] = befehle.decf;
            Befehlsfunktionen[tokens.decfsz] = befehle.decfsz;
            Befehlsfunktionen[tokens.incf] = befehle.incf;
            Befehlsfunktionen[tokens.incfsz] = befehle.incfsz;
            Befehlsfunktionen[tokens.iorwf] = befehle.iorwf;
            Befehlsfunktionen[tokens.movf] = befehle.movf;
            Befehlsfunktionen[tokens.movwf] = befehle.movwf;
            Befehlsfunktionen[tokens.nop] = befehle.nop;
            Befehlsfunktionen[tokens.rlf] = befehle.rlf;
            Befehlsfunktionen[tokens.rrf] = befehle.rrf;
            Befehlsfunktionen[tokens.subwf] = befehle.subwf;
            Befehlsfunktionen[tokens.swapf] = befehle.swapf;
            Befehlsfunktionen[tokens.xorwf] = befehle.xorwf;
            Befehlsfunktionen[tokens.bcf] = befehle.bcf;
            Befehlsfunktionen[tokens.bsf] = befehle.bsf;
            Befehlsfunktionen[tokens.btfsc] = befehle.btfsc;
            Befehlsfunktionen[tokens.btfss] = befehle.btfss;
            Befehlsfunktionen[tokens.addlw] = befehle.addlw;
            Befehlsfunktionen[tokens.andlw] = befehle.andlw;
            Befehlsfunktionen[tokens.call] = befehle.call;
            Befehlsfunktionen[tokens.clrwdt] = befehle.clrwdt;
            Befehlsfunktionen[tokens._goto] = befehle._goto;
            Befehlsfunktionen[tokens.iorlw] = befehle.iorlw;
            Befehlsfunktionen[tokens.movlw] = befehle.movlw;
            Befehlsfunktionen[tokens.retfie] = befehle.retfie;
            Befehlsfunktionen[tokens.retlw] = befehle.retlw;
            Befehlsfunktionen[tokens._return] = befehle._return;
            Befehlsfunktionen[tokens.sleep] = befehle.sleep;
            Befehlsfunktionen[tokens.sublw] = befehle.sublw;
            Befehlsfunktionen[tokens.xorlw] = befehle.xorlw;

            //label für SFR mit Werten belegen
            update_SpecialFunctionRegister();

            //Datagrid für PortA und PortB mit Werten belegen
            update_port_datagrids();

            label_laufzeit.Text = laufzeitzähler.ToString();
            label_quarzfrquenz.Text = quarzfrequenz.ToString_time();
            //combobox für Quarzfrequenz mit Werten belegen
            for (int k = 0; k < quarzfrequenz.get_frequenzcount(); k++)
                comboBox_quarzfrequenz.Items.Add(quarzfrequenz.get_String_frequenz(k));
            comboBox_quarzfrequenz.SelectedIndex = 0;
        }

        

        private void button1_Click(object sender, EventArgs e)//testfunktion
        {
            //test_nicht_initialisierte_var_codezeilen();
            //test_codezeilen_erkennen();
            //test_laenge_short();
            //test_parser();
            //test_datagrid();
            //test_speicher();
            //test_liste();
            //test_Simulation();
            //test_datagrid_zeilenname();
            //test_Spalten_headergröße();
            //test_datagrid_fonts();
            //test_timer();
            //test_datagrid_zeile_markieren();
        }



        /*************************************************************************************************************/
        //Parser
        public int parser(int codezeile)
        {
            int maskiert;
            if (NOP)
            {
                NOP = false;//NOP zurücksetzen damit die nächste Zeile wieder normal ausgeführt wird
                return tokens.nop;
            }
            //Befehle mit bestimmter Codeabfolge
            if (Befehl[codezeile] == 0x0064) return tokens.clrwdt;
            if (Befehl[codezeile] == 0x0009) return tokens.retfie;
            if (Befehl[codezeile] == 0x0008) return tokens._return;
            if (Befehl[codezeile] == 0x0063) return tokens.sleep;

            //NOP
            maskiert = Befehl[codezeile] & 0xFF9F;
            if (maskiert == 0) return tokens.nop;

            //Befehle mit 3-stelliger Codeabfolge
            maskiert = Befehl[codezeile] & 0xF800;
            if (maskiert == 0x2000) return tokens.call;
            if (maskiert == 0x2800) return tokens._goto;

            //Befehle mit 4-stelliger Codeabfolge
            maskiert = Befehl[codezeile] & 0xFC00;
            if (maskiert == 0x1000) return tokens.bcf;
            if (maskiert == 0x1400) return tokens.bsf;
            if (maskiert == 0x1800) return tokens.btfsc;
            if (maskiert == 0x1C00) return tokens.btfss;
            if (maskiert == 0x3000) return tokens.movlw;
            if (maskiert == 0x3400) return tokens.retlw;

            //Befehle mit 5-stelliger Codeabfolge
            maskiert = Befehl[codezeile] & 0xFE00;
            if (maskiert == 0x3E00) return tokens.addlw;
            if (maskiert == 0x3C00) return tokens.sublw;

            //Befehle mit 6-stelliger codeabfolge
            maskiert = Befehl[codezeile] & 0xFF00;
            if (maskiert == 0x0700) return tokens.addwf;
            if (maskiert == 0x0500) return tokens.andwf;
            if (maskiert == 0x0900) return tokens.comf;
            if (maskiert == 0x0300) return tokens.decf;
            if (maskiert == 0x0B00) return tokens.decfsz;
            if (maskiert == 0x0A00) return tokens.incf;
            if (maskiert == 0x0F00) return tokens.incfsz;
            if (maskiert == 0x0400) return tokens.iorwf;
            if (maskiert == 0x0800) return tokens.movf;
            if (maskiert == 0x0D00) return tokens.rlf;
            if (maskiert == 0x0C00) return tokens.rrf;
            if (maskiert == 0x0200) return tokens.subwf;
            if (maskiert == 0x0E00) return tokens.swapf;
            if (maskiert == 0x0600) return tokens.xorwf;
            if (maskiert == 0x3900) return tokens.andlw;
            if (maskiert == 0x3800) return tokens.iorlw;
            if (maskiert == 0x3A00) return tokens.xorlw;

            //Befehle mit 7-stelliger Codeabfolge
            maskiert = Befehl[codezeile] & 0xFF80;
            if (maskiert == 0x0180) return tokens.clrf;
            if (maskiert == 0x0100) return tokens.clrw;
            if (maskiert == 0x0080) return tokens.movwf;

            //ansonsten
            return -1;
        }
        
        




        /*************************************************************************************************************/
        //Timer0 

        //Variablen
        private int Ra4_alt;//enthält den alten Wert des RA4-Bits(entweder 16 oder 0, weil 2^4=16)
        private int prescaler;

        //timer der den Timer0 Clock mode steuert
        //wird etwa alle 50ms ausgeführt
        private void timer0_counter_Tick(object sender, EventArgs e)
        {
            /*
             * wenn das T0CS-Bit im Optoinsregister gesetzt ist ist der Timer0 im Counter
             * wenn das T0SE-Bit im Optionsregister gesetzt ist wird bei einer fallenden
             * Flanke das Timer0-Register erhöht, ansonsten bei einer fallenden
             */
            if(register.bit_gesetzt(Register.option_reg,Bits.t0cs))
            {
                if(register.bit_gesetzt(Register.option_reg,Bits.t0se))
                {//ra4_alt==16, weil es das 5. Bit ist;2^4=16
                    if (Ra4_alt == 16 && (register.Speicher[Register.porta] & 0x10) == 0)
                        timer0_erhöhen();
                }
                else
                {//5.Bit deshalb 16(2^4=16)
                    if (Ra4_alt == 0 && (register.Speicher[Register.porta] & 0x10) == 16)
                        timer0_erhöhen();
                }
            }
            Ra4_alt = (Byte)(register.Speicher[Register.porta] & 0x10);
        }

        public void timer0_geändert(int adresse)
        {
            //wenn das Timer0 register beschrieben wird und der Prescaler dem Timer0 zugewiesen ist
            //wird der Prescaler resettet
            if (adresse == Register.tmr0 && !register.bit_gesetzt(Register.option_reg, Bits.psa)) 
                prescaler = 0;
        }

        public void timer0_erhöhen()
        {
            //wenn das PSA-Bit im Optionsregister NICHT gesetzt ist wird der Prescaler dem Timer0 zugewiesen
            if (register.bit_gesetzt(Register.option_reg, Bits.psa))
            {
                register.Speicher[Register.tmr0]++;
                interrupt.t0if_setzen();
            }
            else
            {
                prescaler++;
                //Prescaler PS2:PS0(Bit0-2 vom Optionsregister)
                //prescale value von 1:2,1:4,...,1:256
                //000==1:2;001==1:4.......
                if (Math.Pow(2, (register.Speicher[Register.option_reg] & 0x07) + 1) >= prescaler) 
                {
                    register.Speicher[Register.tmr0]++;
                    interrupt.t0if_setzen();
                    prescaler = 0;
                }
            }
        }
        public void Timer0_Timermode()
        {
            //wenn Timer0 im Timer mode erhöhe den Timer0
            if (!register.bit_gesetzt(Register.option_reg, Bits.t0cs))
                timer0_erhöhen();

        }




        //Timer0 Ende
        /*************************************************************************************************************/


        /*************************************************************************************************************/
        //Timer in dem das Programm abläuft
        private void timer1_Tick(object sender, EventArgs e)
        {
            Programmablauf();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            //TODO welcher Reset?
            reset = true;
            Power_On_Reset();
            Programm_start(false);
            markiere_zeile(codezeile[PC.get()]);
        }

        private void StartStopButton_Click(object sender, EventArgs e)
        {
            //startet das Programm bis entweder ein Breakpoint erreicht wird oder die Go-Taste erneut
            //betätigt wird. Ein Reset (F2) ist auch möglich.
            if (programmtimer.Enabled)
                Programm_start(false);
            else
                Programm_start(true);
        }

        public int ist_codezeile(int zeile)
        {
            //wenn die übergebene Zeile verwertbaren Code enthält wird true zurückgegeben
            for (int i = 0; i < codezeile.Length; i++) 
            {
                if (zeile == codezeile[i])
                    return i;
            }
            return -1;
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //wenn in die Zweite Spalte geklickt wird, wird diese Funktion beendet, da in die erste Spalte geklickt werden muss
            if (e.ColumnIndex == 1)
                return;
            int temp=ist_codezeile(e.RowIndex);
            if(temp>=0)
            {
                if(breakpoint[temp])
                {
                    breakpoint[temp] = false;
                    dataGridView_code[0, e.RowIndex].Value = "";
                }
                else
                {
                    breakpoint[temp] = true;
                    dataGridView_code[0, e.RowIndex].Value = "B";
                }
            }
        }
        public void Zeile_anzeigen(int zeilennummer)
        {
            //macht die aktuelle Zeile zur ersten angezeigten Zeile, sofern sie außerhalb des angezeigten Bereichs ist
            if (zeilennummer < dataGridView_code.FirstDisplayedCell.RowIndex || zeilennummer > dataGridView_code.FirstDisplayedCell.RowIndex + 14)
                dataGridView_code.FirstDisplayedCell = dataGridView_code[0, zeilennummer];
        }

        public void markiere_zeile(int zeilennummer)
        {
            dataGridView_code.ClearSelection();
            dataGridView_code.Rows[zeilennummer].Selected = true;
            Zeile_anzeigen(zeilennummer);
        }


        public void Programm_start(Boolean starten)
        {
            if(starten)
            {
                programmtimer.Enabled = true;
                interrupttimer.Enabled = true;
                timer0_counter.Enabled = true;
                StartStopButton.Text = "Stop";
            }
            else
            {
                programmtimer.Enabled = false;
                interrupttimer.Enabled = false;
                timer0_counter.Enabled = false;
                StartStopButton.Text = "Start";
            }
        }

        public void Programmablauf()
        {
            interrupt.ausführen();
            int zeilennummer = PC.get();
            int befehl=parser(zeilennummer);
            Befehlsfunktionen[befehl](zeilennummer);
            if (breakpoint[PC.get()]) 
            {
                Programm_start(false);
            }
            if(reset)
            {
                reset = false;
                Programm_start(false);
                Power_On_Reset();
            }
            if (stepout && (befehl == tokens.retfie || befehl == tokens.retlw || befehl == tokens._return)) 
            {
                stepout = false;
                Programm_start(false);
            }
            if(stepover&&temp_breakpoint==PC.get())
            {
                stepover = false;
                Programm_start(false);
                dataGridView_code[0, codezeile[temp_breakpoint]].Value = "";
                temp_breakpoint = -1;
            }
            //nächste Zeile markieren
            markiere_zeile(codezeile[PC.get()]);
            //GUI updaten
            update_SpecialFunctionRegister();
            update_port_datagrids();
            //Laufzeitzähler
            laufzeitzähler.erhöhen(quarzfrequenz.get_time());
            label_laufzeit.Text = laufzeitzähler.ToString();
        }

        private void IgnoreButton_Click(object sender, EventArgs e)
        {
            //überspringt den nächsten Befehl(ändert nur den PC)
            PC.erhöhen();
            markiere_zeile(codezeile[PC.get()]);
        }

        private void StepInButton_Click(object sender, EventArgs e)
        {
            //führt den nächsten Befehl aus
            Programmablauf();
        }

        private void StepOutButton_Click(object sender, EventArgs e)
        {
            //führt aus einem Unterprogramm heraus. Es werden die Befehle 
            //nach und nach abgeabreitet bis ein Rücksprungbefehl (RETLW, 
            //RETURN, RETFIE) auftaucht.
            stepout = true;
            Programm_start(true);
        }

        private void StepOverButton_Click(object sender, EventArgs e)
        {
            //setzt einen temporären Brakpoint auf den nachfolgenden Befehl und startet das Programm.
            //So lassen sich die Unterprogramme schnell durchlaufen. Sobald der Breakpoint erreicht
            //wird, stoppt die Simulation. Sollte das Programm in eine Endlosschleife laufen, kann man die Simulation
            //durch Reset (F2) abbrechen.
            stepover = true;
            temp_breakpoint = PC.get() + 1;
            PC.set(0);
            markiere_zeile(codezeile[PC.get()]);
            dataGridView_code[0, codezeile[temp_breakpoint]].Value = "b";
            Programm_start(true);
        }

        public void update_SpecialFunctionRegister()
        {
            label_w_register.Text = register.w_register.ToString("X2");
            label_fsr.Text = register.Speicher[Register.fsr].ToString("X2");
            label_pcl.Text = register.Speicher[Register.pcl].ToString("X2");
            label_pclath.Text = register.Speicher[Register.pclath].ToString("X2");
            label_pc.Text = PC.get().ToString("X4");
            label_status.Text = register.Speicher[Register.status].ToString("X2");
            label_option.Text = register.Speicher[Register.option_reg].ToString("X2");
            label_intcon.Text = register.Speicher[Register.intcon].ToString("X2");
            //status, option, intcon datagrids mit Werten belegen
            for (int i = 0; i < 8; i++)
            {
                //status
                if (register.bit_gesetzt(Register.status, 7 - i))
                    dataGridView_status[i, 0].Value = "1";
                else
                    dataGridView_status[i, 0].Value = "0";
                //option
                if (register.bit_gesetzt(Register.option_reg, 7 - i))
                    dataGridView_option[i, 0].Value = "1";
                else
                    dataGridView_option[i, 0].Value = "0";
                //intcon
                if (register.bit_gesetzt(Register.intcon, 7 - i))
                    dataGridView_intcon[i, 0].Value = "1";
                else
                    dataGridView_intcon[i, 0].Value = "0";
            }
                
        }

        public void update_port_datagrids()
        {
            //TRIS 1 = i(nput); 0 = o(utput)
            for (int i = 0; i < 5; i++)
            {
                //datagrid portA
                if (register.bit_gesetzt(Register.porta, 5 - i))
                    dataGridView_PortA[i, 1].Value = "1";
                else
                    dataGridView_PortA[i, 1].Value = "0";
                //datagrid TrisA
                if (register.bit_gesetzt(Register.trisa, 5 - i))
                    dataGridView_PortA[i, 0].Value = "i";
                else
                    dataGridView_PortA[i, 0].Value = "o";
            }
            for (int i = 0; i < 8; i++)
            {
                //datagrid PortB
                if (register.bit_gesetzt(Register.portb, 7 - i))
                    dataGridView_PortB[i, 1].Value = "1";
                else
                    dataGridView_PortB[i, 1].Value = "0";
                //datagrid TrisB
                if (register.bit_gesetzt(Register.trisb, 7 - i))
                    dataGridView_PortB[i, 0].Value = "i";
                else
                    dataGridView_PortB[i, 0].Value = "o";
            }
        }

        private void hilfeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Dokumentation öffnen
            System.Diagnostics.Process.Start("PIC-Simulator.pdf");
        }

        private void dataGridView_status_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_status[e.ColumnIndex, 0].Value.ToString() == "1")
            {
                dataGridView_status[e.ColumnIndex, 0].Value = "0";
                register.bit_löschen(Register.status, 7 - e.ColumnIndex);
            }
            else
            {
                dataGridView_status[e.ColumnIndex, 0].Value = "1";
                register.bit_setzen(Register.status, 7 - e.ColumnIndex);
            }
            update_SpecialFunctionRegister();
        }

        private void dataGridView_option_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_option[e.ColumnIndex, 0].Value.ToString() == "1")
            {
                dataGridView_option[e.ColumnIndex, 0].Value = "0";
                register.bit_löschen(Register.option_reg, 7 - e.ColumnIndex);
            }
            else
            {
                dataGridView_option[e.ColumnIndex, 0].Value = "1";
                register.bit_setzen(Register.option_reg, 7 - e.ColumnIndex);
            }
            update_SpecialFunctionRegister();
        }

        private void dataGridView_intcon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_intcon[e.ColumnIndex, 0].Value.ToString() == "1")
            {
                dataGridView_intcon[e.ColumnIndex, 0].Value = "0";
                register.bit_löschen(Register.intcon, 7 - e.ColumnIndex);
            }
            else
            {
                dataGridView_intcon[e.ColumnIndex, 0].Value = "1";
                register.bit_setzen(Register.intcon, 7 - e.ColumnIndex);
            }
            update_SpecialFunctionRegister();
        }

        private void dataGridView_Speicher_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Registerspeicher = e.RowIndex * 8 + e.ColumnIndex;
            string input = "";
            DialogResult result = ShowInputDialog(ref input, Registerspeicher);
            if (result == DialogResult.OK)
            {
                int temp = Convert.ToInt32(input, 16);
                register.Speicher[Registerspeicher] = (Byte)temp;
                Speicher_grid_updaten(Registerspeicher);
            }
        }

        //öffnet eine neue Form mit Editfeld, OK-Button und einem Cancel-Button
        //wird genutzt, da eine Messagebox kein Editfeld enthalten kann.
        private static DialogResult ShowInputDialog(ref string input, int register)
        {
            System.Drawing.Size size = new System.Drawing.Size(165, 100);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Registerspeicher ändern";
            inputBox.ControlBox = false;

            System.Windows.Forms.Label label = new Label();
            label.Location = new System.Drawing.Point(2, 5);
            label.Visible = true;
            label.Text = "    Bitte geben sie den Wert als\n     Hexwert ein, den sie in das\nRegister " + register.ToString("X2") + "H register.speichern möchten";
            label.Size = new Size(label.PreferredWidth, label.PreferredHeight);
            inputBox.Controls.Add(label);

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 48);
            textBox.Text = "0";
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 74);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 74);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }

        private void dataGridView_PortA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)//Zeile für TRIS-Register
                return;
            if (register.bit_gesetzt(Register.porta, 5 - e.ColumnIndex))
                register.bit_löschen(Register.porta, 5 - e.ColumnIndex);
            else
                register.bit_setzen(Register.porta, 5 - e.ColumnIndex);
            update_port_datagrids();
        }

        private void dataGridView_PortB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)//Zeile für TRIS-Register
                return;
            if (register.bit_gesetzt(Register.portb, 7 - e.ColumnIndex))
                register.bit_löschen(Register.portb, 7 - e.ColumnIndex);
            else
                register.bit_setzen(Register.portb, 7 - e.ColumnIndex);
            update_port_datagrids();
        }

        private void groupBox_funktionsgenerator_Enter(object sender, EventArgs e)
        {
            Show_Funktionsgenerator();
        }
        private static DialogResult Show_Funktionsgenerator()
        {
            //TODO, falls die Änderungen des Funktionsgenerators etwas Schicker ändern zu wollen dann das vervolständigen
            System.Drawing.Size size = new System.Drawing.Size(187, 144);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Funktionsgenerator";
            inputBox.ControlBox = false;

            DataGridView dataGridView_FG = new System.Windows.Forms.DataGridView();
            DataGridViewTextBoxColumn Kanal1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridView_FG.AllowUserToAddRows = false;
            dataGridView_FG.AllowUserToDeleteRows = false;
            dataGridView_FG.AllowUserToResizeColumns = false;
            dataGridView_FG.AllowUserToResizeRows = false;
            dataGridView_FG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_FG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            Kanal1});
            dataGridView_FG.Location = new System.Drawing.Point(12, 12);
            dataGridView_FG.Name = "dataGridView_FG";
            dataGridView_FG.RowHeadersWidth = 100;
            dataGridView_FG.RowTemplate.Height = 24;
            dataGridView_FG.ScrollBars = System.Windows.Forms.ScrollBars.None;
            dataGridView_FG.Size = new System.Drawing.Size(165, 95);
            dataGridView_FG.TabIndex = 0;
            dataGridView_FG.Rows.Add();
            dataGridView_FG.Rows.Add();
            dataGridView_FG.Rows.Add();
            dataGridView_FG.Rows[0].HeaderCell.Value = "Port-Pin";
            dataGridView_FG.Rows[1].HeaderCell.Value = "Frequenz(Hz)";
            dataGridView_FG.Rows[2].HeaderCell.Value = "Verhältnis";
            Kanal1.HeaderText = "Kanal1";
            Kanal1.Name = "Kanal1";
            Kanal1.Width = 65;
            inputBox.Controls.Add(dataGridView_FG);


            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 112);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 112);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            return result;
        }

        private void textBox_FG_frequenz_TextChanged(object sender, EventArgs e)
        {
            //TODO nicht das optimalste, aber funktioniert erstmal
            double frequenz=Convert.ToDouble(textBox_FG_frequenz.Text);
            try
            {
                frequenz = Convert.ToDouble(textBox_FG_frequenz.Text);
            }
            catch(Exception)
            {
                MessageBox.Show("Bitte geben sie eine Integerzahl ein");
                textBox_FG_frequenz.Text = frequenz.ToString();
            }
            if (frequenz <= 0)
            {
                MessageBox.Show("Bitte geben sie eine ganze Zahl größer 0 an");
                frequenz = Math.Abs(frequenz);
                textBox_FG_frequenz.Text = frequenz.ToString();
            }
            else if (frequenz > 1000) 
            {
                MessageBox.Show("Bitte geben sie eine ganze Zahl größer 0 an und kleinergleich 1000");
                frequenz = 1000;
                textBox_FG_frequenz.Text = "1000";
            }
            else
            {
                timer_Funktionsgenerator.Interval = (int)(1000 / frequenz);
            }
        }

        private void nctoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pinänderung(Pins.nc);
        }

        private void rA0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pinänderung(Pins.RA0);
        }

        private void rA1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pinänderung(Pins.RA1);
        }

        private void rA2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pinänderung(Pins.RA2);
        }

        private void rA3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pinänderung(Pins.RA3);
        }

        private void rA4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pinänderung(Pins.RA4);
        }

        private void rA5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pinänderung(Pins.RA5);
        }

        private void rA6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pinänderung(Pins.RA6);
        }

        private void rA7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pinänderung(Pins.RA7);
        }

        private void rB0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pinänderung(Pins.RB0);
        }

        private void rB1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pinänderung(Pins.RB1);
        }

        private void rB2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pinänderung(Pins.RB2);
        }

        private void rB3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pinänderung(Pins.RB3);
        }

        private void rB4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pinänderung(Pins.RB4);
        }

        private void rB5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pinänderung(Pins.RB5);
        }

        private void rB6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pinänderung(Pins.RB6);
        }

        private void rB7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pinänderung(Pins.RB7);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            contextmenustrip_aufrufer = contextMenuStrip1.SourceControl.Name;
        }

        public void Pinänderung(int pin)
        {
            if(contextmenustrip_aufrufer=="textBox_FG_pin")
            {
                FG.set_Pin(pin);
                textBox_FG_pin.Text = Pins.ToString(pin);
            }
        }

        private void timer_Funktionsgenerator_Tick(object sender, EventArgs e)
        {
            FG.change_pin();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            laufzeitzähler.Reset();
        }

        private void comboBox_quarzfrequenz_SelectedIndexChanged(object sender, EventArgs e)
        {
            quarzfrequenz.set(comboBox_quarzfrequenz.SelectedIndex);
            label_quarzfrquenz.Text = quarzfrequenz.ToString_time();
        } 
    }
}
