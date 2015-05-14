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
 * Quarzfreguenz + controller.laufzeitzähler
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
       
        public Boolean[] breakpoint;//Boolwert ob die Zeile einen Breakpoint enthält
        String contextmenustrip_aufrufer = "";
        
        

        Controller controller;

        

        

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
            Code_anzeigen();
            Power_On_Reset();
            
            
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
            controller.register.Power_on_Reset();

            //Variableninitiation
            controller.PC.PCH = 0;
            controller.interrupt.init();
            controller.program.init();
            controller.timer0.init();

            for (int i = 0; i < breakpoint.Length; i++)
            {
                breakpoint[i] = false;
                dataGridView_code[0, codezeile[i]].Value = "";
            }

            Speicher_grid_befüllen();
            update_SpecialFunctionRegister();
            update_port_datagrids();
        }

        public void MCLR()
        {
            //manual Seite 27
            //during: normal Operation, sleep
            //WDT-Reset during normal operation
            controller.PC.set(0);
            controller.register.MCLR();
            //TODO wie beeinflusst das die Variablen?

            update_SpecialFunctionRegister();
            update_port_datagrids();
        }

        public void Wakeup_from_sleep()
        {
            //manual seite 27
            //Through controller.interrupt
            //through WDT Time-out
            controller.PC.erhöhen();
            controller.register.Wakeup_from_Sleep();
            //TODO wie beeinflusst das die Variablen

            update_port_datagrids();
            update_SpecialFunctionRegister();
        }

        //Resets Ende
        /***********************************************************************************************/

        //enthält sämtliche Interruptfunktionen und wird von einem Timer alle 50ms ausgeführt
        private void interrupttimer_Tick(object sender, EventArgs e)
        {
            controller.interrupt.Flags_setzen();
        }

        //zeigt die Register in einem DataGridView an
        public void Speicher_grid_befüllen()
        {
            for (int i = 0; i < 256; i++)
                dataGridView_Speicher[i % 8, i / 8].Value = controller.register.Speicher[i].ToString("X2");
        }

        //aktuallisiert ein Speicherregister im DataGridView
        public void Speicher_grid_updaten(int adresse)
        {
            adresse %= 256;
            dataGridView_Speicher[adresse % 8, adresse / 8].Value = controller.register.Speicher[adresse].ToString("X2");
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

            controller = new Controller(this);

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
                     
            

            //label für SFR mit Werten belegen
            update_SpecialFunctionRegister();

            //Datagrid für PortA und PortB mit Werten belegen
            update_port_datagrids();

            label_laufzeit.Text = controller.laufzeitzähler.ToString();
            label_quarzfrquenz.Text = controller.quarzfrequenz.ToString_time();
            //combobox für Quarzfrequenz mit Werten belegen
            for (int k = 0; k < controller.quarzfrequenz.get_frequenzcount(); k++)
                comboBox_quarzfrequenz.Items.Add(controller.quarzfrequenz.get_String_frequenz(k));
            comboBox_quarzfrequenz.SelectedIndex = 0;
        }

        

        private void button1_Click(object sender, EventArgs e)//testfunktion
        {
            MessageBox.Show((-1 & 0x7).ToString());
        }


        //timer der den Timer0 Clock mode steuert
        //wird etwa alle 50ms ausgeführt
        private void timer0_counter_Tick(object sender, EventArgs e)
        {
            controller.timer0.ausführen();
        }


        /*************************************************************************************************************/
        //Timer in dem das Programm abläuft
        private void timer1_Tick(object sender, EventArgs e)
        {
            controller.program.ausführen();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            //TODO welcher Reset?
            controller.program.set_modi(Programmablauf.reset);
            Power_On_Reset();
            Programm_start(false);
            markiere_zeile(codezeile[controller.PC.get()]);
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

        private void IgnoreButton_Click(object sender, EventArgs e)
        {
            //überspringt den nächsten Befehl(ändert nur den controller.PC)
            controller.PC.erhöhen();
            markiere_zeile(codezeile[controller.PC.get()]);
        }

        private void StepInButton_Click(object sender, EventArgs e)
        {
            //führt den nächsten Befehl aus
            controller.program.ausführen();
        }

        private void StepOutButton_Click(object sender, EventArgs e)
        {
            //führt aus einem Unterprogramm heraus. Es werden die Befehle 
            //nach und nach abgeabreitet bis ein Rücksprungbefehl (RETLW, 
            //RETURN, RETFIE) auftaucht.
            controller.program.set_modi(Programmablauf.stepout);
            Programm_start(true);
        }

        private void StepOverButton_Click(object sender, EventArgs e)
        {
            //setzt einen temporären Brakpoint auf den nachfolgenden Befehl und startet das Programm.
            //So lassen sich die Unterprogramme schnell durchlaufen. Sobald der Breakpoint erreicht
            //wird, stoppt die Simulation. Sollte das Programm in eine Endlosschleife laufen, kann man die Simulation
            //durch Reset (F2) abbrechen.
            controller.program.set_modi(Programmablauf.stepover);
            int temp_breakpoint = controller.PC.get() + 1;
            controller.program.set_temp_breakpoint(temp_breakpoint);
            controller.PC.set(0);
            markiere_zeile(codezeile[controller.PC.get()]);
            dataGridView_code[0, codezeile[temp_breakpoint]].Value = "b";
            Programm_start(true);
        }

        public void update_SpecialFunctionRegister()
        {
            label_w_register.Text = controller.register.w_register.ToString("X2");
            label_fsr.Text = controller.register.Speicher[Register.fsr].ToString("X2");
            label_pcl.Text = controller.register.Speicher[Register.pcl].ToString("X2");
            label_pclath.Text = controller.register.Speicher[Register.pclath].ToString("X2");
            label_pc.Text = controller.PC.get().ToString("X4");
            label_status.Text = controller.register.Speicher[Register.status].ToString("X2");
            label_option.Text = controller.register.Speicher[Register.option_reg].ToString("X2");
            label_intcon.Text = controller.register.Speicher[Register.intcon].ToString("X2");
            //status, option, intcon datagrids mit Werten belegen
            for (int i = 0; i < 8; i++)
            {
                //status
                if (controller.register.bit_gesetzt(Register.status, 7 - i))
                    dataGridView_status[i, 0].Value = "1";
                else
                    dataGridView_status[i, 0].Value = "0";
                //option
                if (controller.register.bit_gesetzt(Register.option_reg, 7 - i))
                    dataGridView_option[i, 0].Value = "1";
                else
                    dataGridView_option[i, 0].Value = "0";
                //intcon
                if (controller.register.bit_gesetzt(Register.intcon, 7 - i))
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
                if (controller.register.bit_gesetzt(Register.porta, 5 - i))
                    dataGridView_PortA[i, 1].Value = "1";
                else
                    dataGridView_PortA[i, 1].Value = "0";
                //datagrid TrisA
                if (controller.register.bit_gesetzt(Register.trisa, 5 - i))
                    dataGridView_PortA[i, 0].Value = "i";
                else
                    dataGridView_PortA[i, 0].Value = "o";
            }
            for (int i = 0; i < 8; i++)
            {
                //datagrid PortB
                if (controller.register.bit_gesetzt(Register.portb, 7 - i))
                    dataGridView_PortB[i, 1].Value = "1";
                else
                    dataGridView_PortB[i, 1].Value = "0";
                //datagrid TrisB
                if (controller.register.bit_gesetzt(Register.trisb, 7 - i))
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
                controller.register.bit_löschen(Register.status, 7 - e.ColumnIndex);
            }
            else
            {
                dataGridView_status[e.ColumnIndex, 0].Value = "1";
                controller.register.bit_setzen(Register.status, 7 - e.ColumnIndex);
            }
            update_SpecialFunctionRegister();
        }

        private void dataGridView_option_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_option[e.ColumnIndex, 0].Value.ToString() == "1")
            {
                dataGridView_option[e.ColumnIndex, 0].Value = "0";
                controller.register.bit_löschen(Register.option_reg, 7 - e.ColumnIndex);
            }
            else
            {
                dataGridView_option[e.ColumnIndex, 0].Value = "1";
                controller.register.bit_setzen(Register.option_reg, 7 - e.ColumnIndex);
            }
            update_SpecialFunctionRegister();
        }

        private void dataGridView_intcon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_intcon[e.ColumnIndex, 0].Value.ToString() == "1")
            {
                dataGridView_intcon[e.ColumnIndex, 0].Value = "0";
                controller.register.bit_löschen(Register.intcon, 7 - e.ColumnIndex);
            }
            else
            {
                dataGridView_intcon[e.ColumnIndex, 0].Value = "1";
                controller.register.bit_setzen(Register.intcon, 7 - e.ColumnIndex);
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
                controller.register.Speicher[Registerspeicher] = (Byte)temp;
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
            label.Text = "    Bitte geben sie den Wert als\n     Hexwert ein, den sie in das\nRegister " + register.ToString("X2") + "H controller.register.speichern möchten";
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
            if (controller.register.bit_gesetzt(Register.porta, 5 - e.ColumnIndex))
                controller.register.bit_löschen(Register.porta, 5 - e.ColumnIndex);
            else
                controller.register.bit_setzen(Register.porta, 5 - e.ColumnIndex);
            update_port_datagrids();
        }

        private void dataGridView_PortB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)//Zeile für TRIS-Register
                return;
            if (controller.register.bit_gesetzt(Register.portb, 7 - e.ColumnIndex))
                controller.register.bit_löschen(Register.portb, 7 - e.ColumnIndex);
            else
                controller.register.bit_setzen(Register.portb, 7 - e.ColumnIndex);
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
                controller.FG.set_Pin(pin);
                textBox_FG_pin.Text = Pins.ToString(pin);
            }
        }

        private void timer_Funktionsgenerator_Tick(object sender, EventArgs e)
        {
            controller.FG.change_pin();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.laufzeitzähler.Reset();
        }

        private void comboBox_quarzfrequenz_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.quarzfrequenz.set(comboBox_quarzfrequenz.SelectedIndex);
            label_quarzfrquenz.Text = controller.quarzfrequenz.ToString_time();
        }

    }
}
