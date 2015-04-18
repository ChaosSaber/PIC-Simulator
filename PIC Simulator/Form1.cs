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
 * externer / interner Takt am TMR0-Pin incl. Vorteiler
 * EEPROM Funktionen (Z)
 */

/* TODO René
 * Registerausgabe Spaltennamen
 * Interrupts
 */

/* TODO Felix
 * graphischen Kram
 * Breakpoints
 * Buutons Start/Stop/reset/step
 * laufzeitzähler
 */




//test
namespace PIC_Simulator
{
    delegate void BEFEHLSFUNKTIONEN(int codezeile); //Zeiger auf die Befehlsfunktionen

    public partial class Form1 : Form
    {
        public String[] code;   //alle  Zeilen des Dokumentes
        public int[] codezeile; //Zeilenummern die verwertbaren Code enthalten; beginnen im Dokument mit 1 anstatt 0, dashalb bei Ausgabe +1 addieren
        public int[] Befehle;//enthält den Befehl(zweiter 4-stelliger Code) der Codezeile als int ;(Byte 5-8)
        public Byte[] Speicher = new Byte[256];//Registerspeicher
        public Byte w_register;
        Boolean NOP = false; //wenn NOP= true, dann wird die nächste Anweisung übersprungen
        List<int> TOS = new List<int>(); //Top of Stack Liste; FiLo-Liste
        Byte PCH = 0;//High-Byte des Programmcounter(PC<12:8>)
        Byte RB_alt = 0; //alter Stand(vom letzten Programmzyklus) des Port B, wird für Interrupt benötigt;
        Byte Timer0_alt = 0; //alter Stand(vom letzten Programmzyklus) des Timer0, wird für Interrupt benötigt
        Byte RB0_alt = 0; //alter Stand(vom letzten Programmzyklus) des RB0-Bit, wird für Interrupt benötigt

        static BEFEHLSFUNKTIONEN[] Befehlsfunktionen = new BEFEHLSFUNKTIONEN[35];//Zeiger auf die Befehlsfunktionen

        

        public Form1()
        {
            InitializeComponent();
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
            Befehle = new int[code.Length];
            for (int i = 0; i < code.Length;i++)
            {
                char[] temp = code[i].ToCharArray();
                if (!String.IsNullOrEmpty(code[i]) && (temp[0] <= '9' && temp[0] >= '0' || temp[0] <= 'F' && temp[0] >= 'A'))
                { //trifft zu wenn erstes Zeichen eine Hex-Ziffer ist.
                    temp_int[zaehler] = i;
                    Befehle[zaehler] = extrahiere_befehle(i);
                    zaehler++;
                }
            }
            Array.Resize(ref Befehle, zaehler);
            Array.Resize(ref temp_int, zaehler);
            codezeile=temp_int;
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
            lade_Speicher_Startzustand();
            
            Code_anzeigen();
            Speicher_grid_anzeigen();
        }

        public void lade_Speicher_Startzustand()
        {
            Speicher[0] = 0;
            Speicher[2] = 0;
            Speicher[3] = 0x18;
            Speicher[5] = 0;//PortA
            Speicher[7] = 0;
            Speicher[0x0A] = 0;
            Speicher[0x0B] = 0;
            Speicher[0x80] = 0;
            Speicher[0x81] = 0xFF;
            Speicher[0x82] = 0;
            Speicher[0x83] = 0x18;
            Speicher[0x85] = 0x1F;
            Speicher[0x86] = 0xFF;
            Speicher[0x87] = 0;
            Speicher[0x88] = 0;
            Speicher[0x89] = 0;
            Speicher[0x8A] = 0;
            Speicher[0x8B] = 0;

            //Variableninitiation
            PCH = 0;
            Timer0_alt = 0;
            RB_alt = (Byte)(Speicher[Register.portb] & 0xF0);
            TOS = new List<int>();
            RB0_alt = (Byte)(Speicher[Register.portb] & 0x01);
            NOP = false;
        }

        //zeigt die Register in einem DataGridView an
        public void Speicher_grid_anzeigen()
        {
            dataGridView1.RowCount = 32;//32 Zeilen à 8 Register/Byte = 256/FFH Register
            for (int i = 0; i < 32; i++)
                dataGridView1.Rows[i].HeaderCell.Value = (i * 8).ToString("X2");//sollte eigentlich funktionieren, tut es aber nicht.
            for (int i = 0; i < 256; i++)
                dataGridView1[i % 8, i / 8].Value = Speicher[i].ToString("X2");
        }

        //aktuallisiert ein Speicherregister im DataGridView
        public void Speicher_grid_updaten(int adresse)
        {
            dataGridView1[adresse % 8, adresse / 8].Value = Speicher[adresse].ToString("X2");
        }

        public void Code_anzeigen()
        {
            dataGridView2.RowCount = code.Length;
            for(int i=0;i<code.Length;i++)
            {
                try
                {
                    dataGridView2[1, i].Value = code[i];
                }
                catch(Exception e)
                {
                    MessageBox.Show("Hups, es ist ein Fehler aufgetreten\n" + e.Message);
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //wird nicht genutzt, versehentlich erstellt
        }

        private void ladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "lst files (*.lst)|*.lst";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) 
            {
                if (openFileDialog1.FileName != null) 
                {
                    laden(openFileDialog1.FileName);
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //wird nicht genutzt, versehentlich erstellt
        }

        private void schließenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
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
            Speicher_grid_anzeigen();
         
            //Array der Befehlsfunktionen initialisieren
            Befehlsfunktionen[tokens.addwf]=addwf;
            Befehlsfunktionen[tokens.andwf]=andwf;
            Befehlsfunktionen[tokens.clrf]=clrf;
            Befehlsfunktionen[tokens.clrw]=clrw;
            Befehlsfunktionen[tokens.comf]=comf;
            Befehlsfunktionen[tokens.decf]=decf;
            Befehlsfunktionen[tokens.decfsz]=decfsz;
            Befehlsfunktionen[tokens.incf]=incf;
            Befehlsfunktionen[tokens.incfsz]=incfsz;
            Befehlsfunktionen[tokens.iorwf]=iorwf;
            Befehlsfunktionen[tokens.movf]=movf;
            Befehlsfunktionen[tokens.movwf]=movwf;
            Befehlsfunktionen[tokens.nop]=nop;
            Befehlsfunktionen[tokens.rlf]=rlf;
            Befehlsfunktionen[tokens.rrf]=rrf;
            Befehlsfunktionen[tokens.subwf]=subwf;
            Befehlsfunktionen[tokens.swapf]=swapf;
            Befehlsfunktionen[tokens.xorwf]=xorwf;
            Befehlsfunktionen[tokens.bcf]=bcf;
            Befehlsfunktionen[tokens.bsf]=bsf;
            Befehlsfunktionen[tokens.btfsc]=btfsc;
            Befehlsfunktionen[tokens.btfss]=btfss;
            Befehlsfunktionen[tokens.addlw]=addlw;
            Befehlsfunktionen[tokens.andlw]=andlw;
            Befehlsfunktionen[tokens.call]=call;
            Befehlsfunktionen[tokens.clrwdt]=clrwdt;
            Befehlsfunktionen[tokens._goto]=_goto;
            Befehlsfunktionen[tokens.iorlw]=iorlw;
            Befehlsfunktionen[tokens.movlw]=movlw;
            Befehlsfunktionen[tokens.retfie]=retfie;
            Befehlsfunktionen[tokens.retlw]=retlw;
            Befehlsfunktionen[tokens._return]=_return;
            Befehlsfunktionen[tokens.sleep]=sleep;
            Befehlsfunktionen[tokens.sublw]=sublw;
            Befehlsfunktionen[tokens.xorlw]=xorlw;
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
            test_datagrid_zeilenname();
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
            if (Befehle[codezeile] == 0x0064) return tokens.clrwdt;
            if (Befehle[codezeile] == 0x0009) return tokens.retfie;
            if (Befehle[codezeile] == 0x0008) return tokens._return;
            if (Befehle[codezeile] == 0x0063) return tokens.sleep;

            //NOP
            maskiert = Befehle[codezeile] & 0xFF9F;
            if (maskiert == 0) return tokens.nop;

            //Befehle mit 3-stelliger Codeabfolge
            maskiert = Befehle[codezeile] & 0xF800;
            if (maskiert == 0x2000) return tokens.call;
            if (maskiert == 0x2800) return tokens._goto;

            //Befehle mit 4-stelliger Codeabfolge
            maskiert = Befehle[codezeile] & 0xFC00;
            if (maskiert == 0x1000) return tokens.bcf;
            if (maskiert == 0x1400) return tokens.bsf;
            if (maskiert == 0x1800) return tokens.btfsc;
            if (maskiert == 0x1C00) return tokens.btfss;
            if (maskiert == 0x3000) return tokens.movlw;
            if (maskiert == 0x3400) return tokens.retlw;

            //Befehle mit 5-stelliger Codeabfolge
            maskiert = Befehle[codezeile] & 0xFE00;
            if (maskiert == 0x3E00) return tokens.addlw;
            if (maskiert == 0x3C00) return tokens.sublw;

            //Befehle mit 6-stelliger codeabfolge
            maskiert = Befehle[codezeile] & 0xFF00;
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
            maskiert = Befehle[codezeile] & 0xFF80;
            if (maskiert == 0x0180) return tokens.clrf;
            if (maskiert == 0x0100) return tokens.clrw;
            if (maskiert == 0x0080) return tokens.movwf;

            //ansonsten
            return -1;
        }

        /*
         * TODO
         * GPR-Mapping mit den SFR-Registern ergänzen
         */ 
        
        /*************************************************************************************************************/
        //Hilfsfunktionen für Befehlsfunktionen
        public void Z_Flag(Byte ergebnis)
        {
            if (ergebnis == 0)
                Z_Flag_setzen();
            else
                Z_Flag_löschen();
        }
        public void Z_Flag_setzen()
        {
            bit_setzen(Register.status + 0x80, Bits.Z);
            bit_setzen(Register.status, Bits.Z);
        }
        public void Z_Flag_löschen()
        {
            bit_löschen(Register.status + 0x80, Bits.Z);
            bit_löschen(Register.status, Bits.Z);
        }
        public void Carry_setzen()
        {
            bit_setzen(Register.status + 0x80, Bits.C);
            bit_setzen(Register.status, Bits.C);
        }
        public void Carry_löschen()
        {
            bit_löschen(Register.status + 0x80, Bits.C);
            bit_löschen(Register.status, Bits.C);
        }
        public void Digitcarry_setzen()
        {
            bit_setzen(Register.status + 0x80, Bits.DC);
            bit_setzen(Register.status, Bits.DC);
        }
        public void Digitcarry_löschen()
        {
            bit_löschen(Register.status + 0x80, Bits.DC);
            bit_löschen(Register.status, Bits.DC);
        }
        public void Speicher_mapping(int adresse)
        {
            //GPR 0CH-4FH und 8CH-CFH
            //The GPR addresses in Bank 1 are mapped to addresses in Bank 0. 
            //As an example, addressing location 0Ch or 8Ch will access the same GPR.
            /*SFR die gemapped werden
             * PCL (2)
             * Status (3)
             * FSR (4)
             * PCLATH (AH)
             * INTCON (BH)
             */
            if (adresse > 0xB && adresse < 0x50 || adresse >= 2 && adresse <= 4 || adresse == 0xA || adresse == 0xB) 
            {
                Speicher[adresse + 0x80] = Speicher[adresse];
                Speicher_grid_updaten(adresse + 0x80);
                return;
            }
            if (adresse > 0x8B && adresse < 0xD0 || adresse >= 0x82 && adresse <= 0x84 || adresse == 0x8A || adresse == 0x8B)
                Speicher[adresse - 0x80] = Speicher[adresse];
            Speicher_grid_updaten(adresse - 0x80);
        }
        public void speichern(int adresse,int d, Byte ergebnis)
        {
            //d=1->ergebnis in Speicheradresse speichern, d=0 in w-reg speichern
            if (d > 0)
            {
                Speicher[adresse] = ergebnis;
                Speicher_grid_updaten(adresse);
                Speicher_mapping(adresse);
            }
            else
                w_register = ergebnis;
        }
        public void bit_setzen(int register,int Bit)
        {
            Speicher[register] = (Byte)(Speicher[register] | (1 << Bit));
            Speicher_grid_updaten(register);
        }
        public void bit_löschen(int register, int Bit)
        {
            Speicher[register] = (Byte)(Speicher[register] & ~(1 << Bit));
            Speicher_grid_updaten(register);
        }
        public Boolean bit_gesetzt(int register, int Bit)
        {
            return (Speicher[register] & (1 << Bit)) > 0;
        }
        public void PC_setzen(int Wert)
        {
            Speicher[Register.pcl + 0x80] = (Byte)(Wert & 0xFF);
            Speicher[Register.pcl] = (Byte)(Wert & 0xFF);
            PCH = (Byte)((Wert & 0x1F00) >> 8);
            Speicher_grid_updaten(Register.pcl);
            Speicher_grid_updaten(Register.pcl + 0x80);
        }
        public int PC_ausgeben()
        {
            return (PCH << 8) + Speicher[Register.pcl];
        }
        public void PC_erhöhen()//PC um 1 erhöhen
        {
            if ((Speicher[Register.pcl + 0x80] += 1) == 0)
                    PCH++;
            Speicher[Register.pcl] += 1;
            Speicher_grid_updaten(Register.pcl);
            Speicher_grid_updaten(Register.pcl + 0x80);
        }
        public int adressänderungen(ref int adresse)
        {
            //Wenn das RP0-Bit des Statusregisters gesetzt ist wird auf Bank 1 umgeschaltet (alle Register um 80H erhöht)
            if (Bank1())
                adresse += 0x80;
            //wenn die Zieladresse das INDF-Register(0 oder 80H bei Bank 1) ist, dann wird anstelle des Registers 0/80H
            //an die Registerstelle gespeichert, die das FSR-Register(4 oder 84H bei Bank 1) enthält
            if (adresse % 0x80 == 0)
                adresse = Speicher[Register.fsr];
            return adresse;
        }
        public Boolean Bank1()
        {
            return bit_gesetzt(Register.status, Bits.rp0);
        }
        //fügt dem TOS einen Wert hinzu. wenn der TOS bereits 8 Werte enthält
        //wird zuerst der erste gelöscht.
        public void TOS_add(int Wert)
        {
            if (TOS.Count == 8)
                TOS.Remove(0);
            TOS.Add(Wert);
        }
        //gibt den zuletzt eingetragenen TOS-Wert zurück und löscht diesen dann
        public int TOS_POP()
        {
            int temp = TOS[TOS.Count - 1];
            TOS.Remove(TOS.Count - 1);
            return temp;
        }
        /*************************************************************************************************************/
        //Befehlsfunktionen
        //Status = Speicheradresse 3
            //Statusbits:
            //IRP=7;RP1=6;RP0=5;TO(quer)=4;PD(quer)=3;Z=2;DC=1;C=0

        /***************/
        //TODO 
        //Statusbits DC hinzufügen
        //WDT
        //WDT prescaler

        public void addwf(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = Befehle[codezeile] & 0x0080;
            int temp = Speicher[adresse] + w_register;
            if ((adresse % 0x80) != Register.status) 
            {
                if (temp > 255)//wenn das Ergebnis>255(1Byte) dann setze das Carrybit, ansonsten lösche es
                    Carry_setzen();
                else
                    Carry_löschen();
                if ((Speicher[adresse] & 0xF + w_register & 0xF) > 15)
                    Digitcarry_setzen();
                else
                    Digitcarry_löschen();
            }
            
            Byte ergebnis = (Byte)temp;
            speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status) 
                Z_Flag(ergebnis);
            PC_erhöhen();
        }

        public void andwf(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = Befehle[codezeile] & 0x0080;
            Byte ergebnis = (Byte)(Speicher[adresse] & w_register);
            speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status) 
                Z_Flag(ergebnis); 
            PC_erhöhen();
        }

        public void clrf(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            Speicher[adresse] = 0;
            Speicher_mapping(adresse);
            if (adresse % 0x80 != Register.status) 
                Z_Flag(Speicher[adresse]);
            PC_erhöhen();
        }

        public void clrw(int codezeile)
        {
            w_register = 0;
            Z_Flag(w_register);
            PC_erhöhen();
        }

        public void comf(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = Befehle[codezeile] & 0x0080;
            Byte ergebnis = (Byte)~Speicher[adresse];
            speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status) 
                Z_Flag(ergebnis);
            PC_erhöhen();
        }

        public void decf(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = Befehle[codezeile] & 0x0080;
            Byte ergebnis = (Byte)(Speicher[adresse] - 1);
            speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status)
                Z_Flag(ergebnis);
            PC_erhöhen();
        }

        public void decfsz(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = Befehle[codezeile] & 0x0080;
            Byte ergebnis = (Byte)(Speicher[adresse]-1);
            speichern(adresse, d, ergebnis);
            if (ergebnis == 0)
                NOP = true;//nächste Anweisung überspringen
            PC_erhöhen();
        }

        public void incf(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = Befehle[codezeile] & 0x0080;
            Byte ergebnis = (Byte)(Speicher[adresse] + 1);
            speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status)
                Z_Flag(ergebnis);
            PC_erhöhen();
        }

        public void incfsz(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = Befehle[codezeile] & 0x0080;
            Byte ergebnis = (Byte)(Speicher[adresse] + 1);
            speichern(adresse, d, ergebnis);
            if (ergebnis == 0)
                NOP = true;//nächste Anweisung wird überspringen
            PC_erhöhen();
        }

        public void iorwf(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = Befehle[codezeile] & 0x0080;
            Byte ergebnis = (Byte)(Speicher[adresse] | w_register);
            speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status)
                Z_Flag(ergebnis);
            PC_erhöhen();
        }

        public void movf(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = Befehle[codezeile] & 0x0080;
            if (d == 0) 
                w_register = Speicher[adresse];
            if (adresse % 0x80 != Register.status) 
                Z_Flag(Speicher[adresse]);
            PC_erhöhen();
        }

        public void movwf(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            Speicher[adresse] = w_register;
            Speicher_grid_updaten(adresse);
            Speicher_mapping(adresse);
            PC_erhöhen();
        }

        public void nop(int codezeile)
        {
            PC_erhöhen();
            return;//tue nichts
        }
       
        public void rlf(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = Befehle[codezeile] & 0x0080;
            Boolean carry = bit_gesetzt(Register.status, Bits.C);//Carrybit zwischenspeichern
            if (bit_gesetzt(adresse, 7))//wenn Bit7=1 dann setze Carrybit, ansonsten nicht
                Carry_setzen();
            else
                Carry_löschen();
            Byte ergebnis = (Byte)(Speicher[adresse] << 1);
            if (carry)
                bit_setzen(adresse,0);//wenn das Carrybit am Anfang gesetzt war, setze das Bit0 auf 1
            speichern(adresse, d, ergebnis);
            PC_erhöhen();
        }
        
        public void rrf(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = Befehle[codezeile] & 0x0080;
            Boolean carry = bit_gesetzt(Register.status, Bits.C);//Carrybit zwischenspeichern
            if (bit_gesetzt(adresse, 0))//wenn Bit0=1 dann setze Carrybit, ansonsten nicht
                Carry_setzen();
            else
                Carry_löschen();
            Byte ergebnis = (Byte)(Speicher[adresse] >> 1);
            if (carry)
                bit_setzen(adresse, 7);//wenn das Carrybit am Anfang gesetzt war, setze das Bit7
            speichern(adresse, d, ergebnis);
            PC_erhöhen();
        }

        public void subwf(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = Befehle[codezeile] & 0x0080;
            int temp = Speicher[adresse] - w_register;
            if (adresse % 0x80 != Register.status)
            {
                if (temp <= 0)//wenn das Ergebnis<0 dann lösche das Carrybit, ansonsten setze es
                    Carry_löschen();
                else
                    Carry_setzen();
                if ((Speicher[adresse] & 0xF - w_register & 0xF) <= 0)
                    Digitcarry_setzen();
                else
                    Digitcarry_löschen();
            }
            Byte ergebnis = (Byte)temp;
            speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status)
                Z_Flag(ergebnis);
            PC_erhöhen();
        }

        public void swapf(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = Befehle[codezeile] & 0x0080;
            Byte ergebnis = (Byte)((Speicher[adresse] & 0xF0)>>4);//Bit(7-4) maskieren und auf Position 3-0 verschieben
            ergebnis |= (Byte)((Speicher[adresse] & 0x0F) << 4);//Bit(3-0) maskieren und auf Position 7-4 verschieben sowie mit vorherigen Schritt verodern
            speichern(adresse, d, ergebnis);
            PC_erhöhen();
        }

        public void xorwf(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = Befehle[codezeile] & 0x0080;
            Byte ergebnis = (Byte)(Speicher[adresse] ^ w_register);
            speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status)
                Z_Flag(ergebnis);
            PC_erhöhen();
        }

        public void bcf(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int bitnummer = Befehle[codezeile] & 0x0380;
            bitnummer >>= 7;
            bit_löschen(adresse, bitnummer);
            Speicher_mapping(adresse);
            PC_erhöhen();
        }

        public void bsf(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int bitnummer = Befehle[codezeile] & 0x0380;
            bitnummer >>= 7;
            bit_setzen(adresse, bitnummer);
            Speicher_mapping(adresse);
            PC_erhöhen();
        }

        public void btfsc(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int bitnummer = Befehle[codezeile] & 0x0380;
            bitnummer >>= 7;
            if (!bit_gesetzt(adresse, bitnummer))
                NOP = true;//nächste Anweisung NOP
            PC_erhöhen();
        }

        public void btfss(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int bitnummer = Befehle[codezeile] & 0x0380;
            bitnummer >>= 7;
            if (bit_gesetzt(adresse, bitnummer))
                NOP = true;//nächste Anweisung NOP
            PC_erhöhen();
        }

        public void addlw(int codezeile)
        {
            int literal = Befehle[codezeile] & 0x00FF;
            int temp = literal + w_register;
            if (temp > 255)//wenn das Ergebnis>255(1 Byte) dann setze das Carrybit, ansonsten lösche es
                Carry_setzen();
            else
                Carry_löschen();
            if ((literal & 0xF + w_register & 0xF) > 15)
                Digitcarry_setzen();
            else
                Digitcarry_löschen();
            w_register = (Byte)temp;
            Z_Flag(w_register);
            PC_erhöhen();
        }

        public void andlw(int codezeile)
        {
            int literal = Befehle[codezeile] & 0x00FF;
            w_register &= (Byte)literal;
            Z_Flag(w_register);
            PC_erhöhen();
        }
        //wenn PCLATH nicht gemapped wird, überarbeiten
        public void call(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x07FF; //Zielsprungadresse !!!!! KEINE Adressänderung !!!!!
            TOS_add(PC_ausgeben() + 1);//PC + 1 -> TOS
            PC_setzen(adresse);//literal -> PC<10:0>
            PCH |= (Byte)(Speicher[Register.pclath] & 0x18);//PCLATH<4:3> -> PC<12:11> 
            //2-cycle Instruction
        }
        
        public void clrwdt(int codezeile)
        {
            //WDT=0;
            //WDT prescaler=0;
            Speicher[Register.status + 0x80] |= 0x18;//Statusbit TO(Bit4) und PD(Bit3) setzen
            Speicher[Register.status] |= 0x18;//Statusbit TO(Bit4) und PD(Bit3) setzen
            PC_erhöhen();
        }
        
        public void _goto(int codezeile)
        {
            int adresse = Befehle[codezeile] & 0x07FF; //Zielsprungadresse !!!!! KEINE Adressänderung !!!!!
            PC_setzen(adresse);//literal -> PC<10:0>
            PCH |= (Byte)(Speicher[Register.pclath] & 0x18);//PCLATH<4:3> -> PC<12:11>
        }

        public void iorlw(int codezeile)
        {
            int literal = Befehle[codezeile] & 0x00FF;
            w_register |= (Byte)literal;
            Z_Flag(w_register);
            PC_erhöhen();
        }

        public void movlw(int codezeile)
        {
            int literal = Befehle[codezeile] & 0x00FF;
            w_register = (Byte)literal;
            PC_erhöhen();
        }
        
        public void retfie(int codezeile)
        {
            //return from interrupt;
            PC_setzen(TOS_POP());//TOS -> PC
            bit_setzen(Register.intcon + 0x80, Bits.gie);//1 -> GIE
            bit_setzen(Register.intcon, Bits.gie);
        }

        public void retlw(int codezeile)
        {
            int literal = Befehle[codezeile] & 0x00FF;
            w_register = (Byte)literal;
            PC_setzen(TOS_POP());//TOS -> PC
        }

        public void _return(int codezeile)
        {
            //return from Subroutine
            PC_setzen(TOS_POP());//TOS -> PC
            //this is a two-cycle instruction
        }
       
        public void sleep(int codezeile)
        {
            //The processor is put into SLEEP-mode with the oscillator stopped.
            //0 -> WDT
            //0 -> WDT prescaler
            bit_setzen(Register.status + 0x80, Bits.to);//TO-Bit(4) im Statusregister setzen
            bit_setzen(Register.status, Bits.to);//TO-Bit(4) im Statusregister setzen
            bit_löschen(Register.status + 0x80, Bits.pd);//PD-Bit(3) im Statusregister löschen
            bit_löschen(Register.status, Bits.pd);//PD-Bit(3) im Statusregister löschen            
        }

        public void sublw(int codezeile)
        {
            int literal = Befehle[codezeile] & 0x00FF;
            int temp = literal - w_register;
            if (temp <= 0)//wenn das Ergebnis<=0 dann lösche das Carrybit, ansonsten setze es
                Carry_löschen();
            else
                Carry_setzen();
            if ((literal & 0xF - w_register & 0xF) <=0)
                Digitcarry_setzen();
            else
                Digitcarry_löschen();
            w_register = (Byte)temp;
            Z_Flag(w_register);
            PC_erhöhen();
        }

        public void xorlw(int codezeile)
        {
            int literal = Befehle[codezeile] & 0x00FF;
            w_register ^= (Byte)literal;
            Z_Flag(w_register);
            PC_erhöhen();
        }

        //Befehlsfunktionen Ende
        /**********************************************************************************************************/



        /**********************************************************************************************************/
        //Interrupt
        //manual Seite 31
        //wenn ein Interrupt passiert wird an die Stelle 4 gesprungen
        //For external interrupt events, such as the RB0/INT pin or PORTB change interrupt, the interrupt latency will be three to four instruction cycles.
        //The interrupt flag bit(s) must be cleared in software before re-enabling interrupts to avoid infinite interrupt requests.
        
        //enthält sämtliche Interruptfunktionen und wird bei jedem Durchlauf vor der Befehlsausführung durchgeführt
        public void interrupt()
        {
            t0if_setzen();
            intf_setzen();
            rbif_setzen();
            if(timer0_interrupt()||external_Interrupt()||rb0_interrupt()||EE_interrupt())
            {
                //aus SLEEP-MODE aufwachen
                if(bit_gesetzt(Register.intcon,Bits.gie))
                {
                    TOS_add(PC_ausgeben());
                    PC_setzen(4);
                    bit_löschen(Register.intcon, Bits.gie);
                }
            }
        }
        public void t0if_setzen()
        {//wenn Timer0 überläuft
            if (Timer0_alt == 255 && Speicher[Register.tmr0] == 0)
                bit_setzen(Register.intcon, Bits.t0if);
            Timer0_alt = Speicher[Register.tmr0];
        }
        public void intf_setzen()
        {//external interruptflag
            //The RB0/INT external interrupt occurred (must be cleared in software)
            //wenn das intedg im Optionsregister gesetzt ist bei einer steigenden flanke, ansonsten bei einer fallenden
            if (bit_gesetzt(Register.option_reg, Bits.intedg)) 
            {
                if (RB0_alt == 0 && (Speicher[Register.portb] & 0x01) == 1) 
                    bit_setzen(Register.intcon, Bits.intf);
            }
            else
                if (RB0_alt == 1 && (Speicher[Register.portb] & 0x01) == 0)
                    bit_setzen(Register.intcon, Bits.intf);
            RB0_alt = (Byte)(Speicher[Register.portb] & 0x01);
        }
        public void rbif_setzen()
        {//RB Port Change
            //At least one of the RB7:RB4 pins changed state (must be cleared in software)
            if (RB_alt != (Speicher[Register.portb] & 0xF0))
                bit_setzen(Register.intcon, Bits.rbif);
            RB_alt = (Byte)(Speicher[Register.portb] & 0xF0);
        }
        public Boolean timer0_interrupt()
        {
            if (bit_gesetzt(Register.intcon, Bits.t0ie) && bit_gesetzt(Register.intcon, Bits.t0if)) 
                return true;
            return false;
        }
        public Boolean external_Interrupt()
        {
            if (bit_gesetzt(Register.intcon, Bits.inte) && bit_gesetzt(Register.intcon, Bits.intf))
                return true;
            return false;
        }
        public Boolean rb0_interrupt()
        {
            if (bit_gesetzt(Register.intcon, Bits.rbie) && bit_gesetzt(Register.intcon, Bits.rbif))
                return true;
            return false;
        }
        public Boolean EE_interrupt()
        {//EE Write Complete Interrupt
            if (bit_gesetzt(Register.intcon, Bits.eeie) && bit_gesetzt(Register.eecon1, Bits.eeif)) 
                return true;
            return false;
        }







        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //falschen Eventhandler erstellt
        }

        // Register ändern wenn man in das Datagrid klickt
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int register = e.RowIndex * 8 + e.ColumnIndex;
            string input = "";
            DialogResult result = ShowInputDialog(ref input,register);
            if (result == DialogResult.OK)
            {
                int temp = Convert.ToInt32(input, 16);
                Speicher[register] = (Byte)temp;
                Speicher_grid_updaten(register);
            }
        }

        //öffnet eine neue Form mit Editfeld, OK-Button und einem Cancel-Button
        //wird genutzt, da eine Messagebox kein Editfeld enthalten kann.
        //TODO Verschönern mit Text und Beschriftung sowie Ausrichtung, bissl experimentieren
        //http://stackoverflow.com/questions/97097/what-is-the-c-sharp-version-of-vb-nets-inputdialog
        private static DialogResult ShowInputDialog(ref string input,int register)
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
            label.Text = "    Bitte geben sie den Wert als\n     Hexwert ein, den sie in das\nRegister " + register.ToString("X2") + "H speichern möchten";
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







        /**************************************************************************************************************/
        //Testfunktionen
        public void test_codezeilen_erkennen()
        {
            String[] test = new String[codezeile.Length];
            for (int i = 0; i < codezeile.Length; i++)
            {
                test[i] = code[codezeile[i]];
            }
            richTextBox1.Lines = test;
        }
        public void test_nicht_initialisierte_var_codezeilen()
        {
            //if(codezeile.)

            MessageBox.Show(codezeile.Length.ToString());
        }
        public void test_laenge_short()
        {
            MessageBox.Show(sizeof(short).ToString());
        }
        public void test_parser()
        {
            for(int i=0;i<codezeile.Length;i++)
            {
                MessageBox.Show(parser(i).ToString());
            }
        }
        public void test_datagrid()
        {
            Speicher[0] = 30;
            Speicher[1] = 200;
            Speicher[9] = 0xF0;
            Speicher_grid_updaten(0);
            Speicher_grid_updaten(1);
            Speicher_grid_updaten(9);
        }
        public void test_speicher()
        {
            MessageBox.Show(Speicher[0].ToString() + " " + Speicher[1].ToString() + " " + Speicher[9].ToString());
        }
        public void test_liste()
        {
            TOS.Add(1);
            TOS.Add(2);
            TOS.Add(3);
            TOS.Add(4);
            TOS.Add(5);
            MessageBox.Show(TOS.Count.ToString());
            MessageBox.Show(TOS[3].ToString());
            TOS.Remove(3);
            MessageBox.Show(TOS[3].ToString());
            MessageBox.Show(TOS.Count.ToString());
        }
        public void test_Simulation()
        {
            while(true)
            {
                int zeilennummer = PC_ausgeben();
                Befehlsfunktionen[parser(zeilennummer)](zeilennummer);
                MessageBox.Show("Programmzeile: " + (1 + codezeile[zeilennummer]).ToString() + "\n" +
                    "w_register: " + w_register.ToString() + "\n" +
                    "Count: " + Speicher[0xC].ToString() + "\n" +
                    "fsr: " + Speicher[4].ToString() + "\n" +
                    "indirect: " + Speicher[0].ToString() + "\n" +
                    "10H: " + Speicher[0x10].ToString() + "\n" +
                    "11H: " + Speicher[0x11].ToString() + "\n" +
                    "12H: " + Speicher[0x12].ToString() + "\n" +
                    "13H: " + Speicher[0x13].ToString() + "\n" +
                    "14H: " + Speicher[0x14].ToString() + "\n" +
                    "15H: " + Speicher[0x15].ToString() + "\n" +
                    "16H: " + Speicher[0x16].ToString() + "\n" +
                    "17H: " + Speicher[0x17].ToString() + "\n" +
                    "18H: " + Speicher[0x18].ToString() + "\n" +
                    "19H: " + Speicher[0x19].ToString() + "\n" +
                    "1AH: " + Speicher[0x1A].ToString() + "\n" +
                    "1BH: " + Speicher[0x1B].ToString() + "\n" +
                    "1CH: " + Speicher[0x1C].ToString() + "\n" +
                    "1DH: " + Speicher[0x1D].ToString() + "\n" +
                    "1EH: " + Speicher[0x1E].ToString() + "\n" +
                    "1FH: " + Speicher[0x1F].ToString() + "\n" +
                    "0FH: " + Speicher[0x0F].ToString() + "\n" +
                    "0EH: " + Speicher[0x0E].ToString() + "\n");
            }
            
        }

        public void test_datagrid_zeilenname()
        {
            dataGridView1.Rows[0].HeaderCell.Value = "test";
        }
    }
}
