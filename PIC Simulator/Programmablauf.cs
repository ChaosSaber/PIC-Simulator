using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIC_Simulator
{
    class Programmablauf
    {
        public const int normal = 0;
        public const int stepover = 1;
        public const int stepout = 2;
        public const int reset = 3;

        private int modi = 0;
        private int temp_breakpoint = -1;
        public Boolean NOP = false; //wenn NOP= true, dann wird die nächste Anweisung übersprungen

        static BEFEHLSFUNKTIONEN[] Befehlsfunktionen = new BEFEHLSFUNKTIONEN[35];//Zeiger auf die Befehlsfunktionen

        Controller controller;
        Befehle befehle;

        public int intervallzeit;//wird gesetzt wenn ein anderer Modi als normal genutz wird um die Simulationsfrequenz zwischenzuspeichern
        


        public Programmablauf(Controller controller)
        {
            this.controller = controller;

            befehle = new Befehle(controller);


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
        }

        public void set_modi(int modus)
        {
            modi = modus;
        }

        public void set_temp_breakpoint(int breakpoint)
        {
            temp_breakpoint = breakpoint;
        }

        public void init()
        {
            NOP = false;
            modi = normal;
            temp_breakpoint = -1;
        }

        public void ausführen()
        {
            controller.interrupt.ausführen();
            int zeilennummer = controller.PC.get();
            int anweisung = Parser.parsen(controller.PIC.Befehl[zeilennummer], ref NOP);
            Befehlsfunktionen[anweisung](zeilennummer);
            if (modi == normal && controller.PIC.breakpoint[controller.PC.get()]) 
            {
                controller.PIC.Programm_start(false);
            }
            if (modi==reset)
            {
                modi = normal;
                controller.PIC.Programm_start(false);
                controller.PIC.Power_On_Reset();
            }
            if (modi==stepout && (anweisung == tokens.retfie || anweisung == tokens.retlw || anweisung == tokens._return))
            {
                modi = normal;
                controller.PIC.Programm_start(false);
                controller.PIC.programmtimer.Interval = intervallzeit;
            }
            if (modi==stepover && temp_breakpoint == controller.PC.get())
            {
                modi = normal;
                controller.PIC.Programm_start(false);
                controller.PIC.dataGridView_code[0, controller.PIC.codezeile[temp_breakpoint]].Value = "";
                temp_breakpoint = -1;
                controller.PIC.programmtimer.Interval = intervallzeit;
            }
            //nächste Zeile markieren
            controller.PIC.markiere_zeile(controller.PIC.codezeile[controller.PC.get()]);
            //GUI updaten
            controller.PIC.update_SpecialFunctionRegister();
            controller.PIC.update_port_datagrids();
            //Laufzeitzähler
            controller.laufzeitzähler.erhöhen(controller.quarzfrequenz.get_time());
            controller.PIC.label_laufzeit.Text = controller.laufzeitzähler.ToString();
        }
    }
}
