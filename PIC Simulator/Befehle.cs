using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PIC_Simulator
{
    class Befehle
    {
        Controller controller;


        public Befehle(Controller controller)
        {
            this.controller = controller;
        }


        
        //Hilfsfunktionen für Befehlsfunktionen
        private int adressänderungen(ref int adresse)
        {
            //Wenn das RP0-Bit des Statusregisters gesetzt ist wird auf Bank 1 umgeschaltet (alle Register um 80H erhöht)
            if (Bank1())
                adresse += 0x80;
            //wenn die Zieladresse das INDF-Register(0 oder 80H bei Bank 1) ist, dann wird anstelle des Registers 0/80H
            //an die Registerstelle gespeichert, die das FSR-Register(4 oder 84H bei Bank 1) enthält
            if (adresse % 0x80 == 0)
                adresse = controller.register.Speicher[Register.fsr];
            return adresse;
        }
        private Boolean Bank1()
        {
            return controller.register.bit_gesetzt(Register.status, Bits.rp0);
        }

        //Befehlsfunktionen
        //Status = Speicheradresse 3
        //Statusbits:
        //IRP=7;RP1=6;RP0=5;TO(quer)=4;PD(quer)=3;Z=2;DC=1;C=0


        public void addwf(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = controller.PIC.Befehl[codezeile] & 0x0080;
            int temp = controller.register.Speicher[adresse] + controller.register.w_register;
            if ((adresse % 0x80) != Register.status)
            {
                if (temp > 255)//wenn das Ergebnis>255(1Byte) dann setze das Carrybit, ansonsten lösche es
                    controller.register.Carry_setzen();
                else
                    controller.register.Carry_löschen();
                if (((controller.register.Speicher[adresse] & 0xF) + (controller.register.w_register & 0xF)) > 15)
                    controller.register.Digitcarry_setzen();
                else
                    controller.register.Digitcarry_löschen();
            }

            Byte ergebnis = (Byte)temp;
            controller.register.speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status)
                controller.register.Z_Flag(ergebnis);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void andwf(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = controller.PIC.Befehl[codezeile] & 0x0080;
            Byte ergebnis = (Byte)(controller.register.Speicher[adresse] & controller.register.w_register);
            controller.register.speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status)
                controller.register.Z_Flag(ergebnis);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void clrf(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            controller.register.speichern(adresse, 1, 0);
            if (adresse % 0x80 != Register.status)
                controller.register.Z_Flag(controller.register.Speicher[adresse]);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void clrw(int codezeile)
        {
            controller.register.w_register = 0;
            controller.register.Z_Flag(controller.register.w_register);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void comf(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = controller.PIC.Befehl[codezeile] & 0x0080;
            Byte ergebnis = (Byte)~controller.register.Speicher[adresse];
            controller.register.speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status)
                controller.register.Z_Flag(ergebnis);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void decf(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = controller.PIC.Befehl[codezeile] & 0x0080;
            Byte ergebnis = (Byte)(controller.register.Speicher[adresse] - 1);
            controller.register.speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status)
                controller.register.Z_Flag(ergebnis);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void decfsz(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = controller.PIC.Befehl[codezeile] & 0x0080;
            Byte ergebnis = (Byte)(controller.register.Speicher[adresse] - 1);
            controller.register.speichern(adresse, d, ergebnis);
            if (ergebnis == 0)
                controller.program.NOP = true;//nächste Anweisung überspringen
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void incf(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = controller.PIC.Befehl[codezeile] & 0x0080;
            Byte ergebnis = (Byte)(controller.register.Speicher[adresse] + 1);
            controller.register.speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status)
                controller.register.Z_Flag(ergebnis);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void incfsz(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = controller.PIC.Befehl[codezeile] & 0x0080;
            Byte ergebnis = (Byte)(controller.register.Speicher[adresse] + 1);
            controller.register.speichern(adresse, d, ergebnis);
            if (ergebnis == 0)
                controller.program.NOP = true;//nächste Anweisung wird überspringen
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void iorwf(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = controller.PIC.Befehl[codezeile] & 0x0080;
            Byte ergebnis = (Byte)(controller.register.Speicher[adresse] | controller.register.w_register);
            controller.register.speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status)
                controller.register.Z_Flag(ergebnis);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void movf(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = controller.PIC.Befehl[codezeile] & 0x0080;
            controller.register.speichern(adresse, d, controller.register.Speicher[adresse]);
            if ((adresse % 0x80 != Register.status) || d == 0) 
                controller.register.Z_Flag(controller.register.Speicher[adresse]);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void movwf(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            controller.register.speichern(adresse, 1, controller.register.w_register);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void nop(int codezeile)
        {
            controller.PC.erhöhen();
            controller.timer0.Timermode();
            return;//tue nichts
        }

        public void rlf(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = controller.PIC.Befehl[codezeile] & 0x0080;
            Boolean carry = controller.register.bit_gesetzt(Register.status, Bits.C);//Carrybit zwischenspeichern
            if (controller.register.bit_gesetzt(adresse, 7))//wenn Bit7=1 dann setze Carrybit, ansonsten nicht
                controller.register.Carry_setzen();
            else
                controller.register.Carry_löschen();
            Byte ergebnis = (Byte)(controller.register.Speicher[adresse] << 1);
            if (carry)
                ergebnis |= (Byte)0x01;//wenn das Carrybit am Anfang gesetzt war, setze das Bit0 auf 1
            controller.register.speichern(adresse, d, ergebnis);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void rrf(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = controller.PIC.Befehl[codezeile] & 0x0080;
            Boolean carry = controller.register.bit_gesetzt(Register.status, Bits.C);//Carrybit zwischenspeichern
            if (controller.register.bit_gesetzt(adresse, 0))//wenn Bit0=1 dann setze Carrybit, ansonsten nicht
                controller.register.Carry_setzen();
            else
                controller.register.Carry_löschen();
            Byte ergebnis = (Byte)(controller.register.Speicher[adresse] >> 1);
            if (carry)
                ergebnis |= (Byte)0x80;//wenn das Carrybit am Anfang gesetzt war, setze das Bit7
            controller.register.speichern(adresse, d, ergebnis);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void subwf(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = controller.PIC.Befehl[codezeile] & 0x0080;
            int temp = controller.register.Speicher[adresse] - controller.register.w_register;
            if ((adresse % 0x80 != Register.status) || d == 0) 
            {
                if (temp <= 0)//wenn das Ergebnis<0 dann lösche das Carrybit, ansonsten setze es
                    controller.register.Carry_setzen();
                else
                    controller.register.Carry_löschen();
                if (((controller.register.Speicher[adresse] & 0xF) - (controller.register.w_register & 0xF)) <= 0)
                    controller.register.Digitcarry_setzen();
                else
                    controller.register.Digitcarry_löschen();
            }
            Byte ergebnis = (Byte)temp;
            controller.register.speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status)
                controller.register.Z_Flag(ergebnis);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void swapf(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = controller.PIC.Befehl[codezeile] & 0x0080;
            Byte ergebnis = (Byte)((controller.register.Speicher[adresse] & 0xF0) >> 4);//Bit(7-4) maskieren und auf Position 3-0 verschieben
            ergebnis |= (Byte)((controller.register.Speicher[adresse] & 0x0F) << 4);//Bit(3-0) maskieren und auf Position 7-4 verschieben sowie mit vorherigen Schritt verodern
            controller.register.speichern(adresse, d, ergebnis);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void xorwf(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = controller.PIC.Befehl[codezeile] & 0x0080;
            Byte ergebnis = (Byte)(controller.register.Speicher[adresse] ^ controller.register.w_register);
            controller.register.speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status)
                controller.register.Z_Flag(ergebnis);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void bcf(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int bitnummer = controller.PIC.Befehl[codezeile] & 0x0380;
            bitnummer >>= 7;
            controller.register.bit_löschen(adresse, bitnummer);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void bsf(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int bitnummer = controller.PIC.Befehl[codezeile] & 0x0380;
            bitnummer >>= 7;
            controller.register.bit_setzen(adresse, bitnummer);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void btfsc(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int bitnummer = controller.PIC.Befehl[codezeile] & 0x0380;
            bitnummer >>= 7;
            if (!controller.register.bit_gesetzt(adresse, bitnummer))
                controller.program.NOP = true;//nächste Anweisung controller.PIC.NOP
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void btfss(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int bitnummer = controller.PIC.Befehl[codezeile] & 0x0380;
            bitnummer >>= 7;
            if (controller.register.bit_gesetzt(adresse, bitnummer))
                controller.program.NOP = true;//nächste Anweisung controller.PIC.NOP
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void addlw(int codezeile)
        {
            int literal = controller.PIC.Befehl[codezeile] & 0x00FF;
            int temp = literal + controller.register.w_register;
            if (temp > 255)//wenn das Ergebnis>255(1 Byte) dann setze das Carrybit, ansonsten lösche es
                controller.register.Carry_setzen();
            else
                controller.register.Carry_löschen();
            if (((literal & 0xF) + (controller.register.w_register & 0xF)) > 15)
                controller.register.Digitcarry_setzen();
            else
                controller.register.Digitcarry_löschen();
            controller.register.w_register = (Byte)temp;
            controller.register.Z_Flag(controller.register.w_register);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void andlw(int codezeile)
        {
            int literal = controller.PIC.Befehl[codezeile] & 0x00FF;
            controller.register.w_register &= (Byte)literal;
            controller.register.Z_Flag(controller.register.w_register);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void call(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x07FF; //Zielsprungadresse !!!!! KEINE Adressänderung !!!!!
            controller.TOS.Add(controller.PC.get() + 1);//controller.PC + 1 -> controller.TOS
            controller.PC.set(adresse);//literal -> controller.PC<10:0>
            //nächste Zeile kann so ausgeführt werden, da controller.PC<12:11> an dieser Stelle 0
            controller.PC.PCH |= (Byte)(controller.register.Speicher[Register.pclath] & 0x18);//PCLATH<4:3> -> controller.PC<12:11> 
            //2-cycle Instruction
            controller.timer0.Timermode();
            controller.timer0.Timermode();
        }

        public void clrwdt(int codezeile)
        {
            //WDT=0;
            //WDT prescaler=0;
            controller.register.Speicher[Register.status + 0x80] |= 0x18;//Statusbit TO(Bit4) und PD(Bit3) setzen
            controller.register.Speicher[Register.status] |= 0x18;//Statusbit TO(Bit4) und PD(Bit3) setzen
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void _goto(int codezeile)
        {
            int adresse = controller.PIC.Befehl[codezeile] & 0x07FF; //Zielsprungadresse !!!!! KEINE Adressänderung !!!!!
            controller.PC.set(adresse);//literal -> controller.PC<10:0>
            controller.PC.PCH |= (Byte)(controller.register.Speicher[Register.pclath] & 0x18);//PCLATH<4:3> -> controller.PC<12:11>
            controller.timer0.Timermode();
        }

        public void iorlw(int codezeile)
        {
            int literal = controller.PIC.Befehl[codezeile] & 0x00FF;
            controller.register.w_register |= (Byte)literal;
            controller.register.Z_Flag(controller.register.w_register);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void movlw(int codezeile)
        {
            int literal = controller.PIC.Befehl[codezeile] & 0x00FF;
            controller.register.w_register = (Byte)literal;
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void retfie(int codezeile)
        {
            //return from interrupt;
            controller.PC.set(controller.TOS.Pop());//controller.TOS -> controller.PC
            controller.register.bit_setzen(Register.intcon + 0x80, Bits.gie);//1 -> GIE
            controller.register.bit_setzen(Register.intcon, Bits.gie);
            controller.timer0.Timermode();
        }

        public void retlw(int codezeile)
        {
            int literal = controller.PIC.Befehl[codezeile] & 0x00FF;
            controller.register.w_register = (Byte)literal;
            controller.PC.set(controller.TOS.Pop());//controller.TOS -> controller.PC
            //Two-Cycle Instruction
            controller.timer0.Timermode();
            controller.timer0.Timermode();
        }

        public void _return(int codezeile)
        {
            //return from Subroutine
            controller.PC.set(controller.TOS.Pop());//controller.TOS -> controller.PC
            //this is a two-cycle instruction
            controller.timer0.Timermode();
            controller.timer0.Timermode();
        }

        public void sleep(int codezeile)
        {
            //The processor is put into SLEEP-mode with the oscillator stopped.
            //0 -> WDT
            //0 -> WDT prescaler
            controller.register.bit_setzen(Register.status + 0x80, Bits.to);//TO-Bit(4) im Statusregister setzen
            controller.register.bit_setzen(Register.status, Bits.to);//TO-Bit(4) im Statusregister setzen
            controller.register.bit_löschen(Register.status + 0x80, Bits.pd);//PD-Bit(3) im Statusregister löschen
            controller.register.bit_löschen(Register.status, Bits.pd);//PD-Bit(3) im Statusregister löschen            
            controller.timer0.Timermode();
        }

        public void sublw(int codezeile)
        {
            int literal = controller.PIC.Befehl[codezeile] & 0x00FF;
            int temp = literal - controller.register.w_register;
            if (temp <= 0)//wenn das Ergebnis<=0 dann lösche das Carrybit, ansonsten setze es
                controller.register.Carry_löschen();
            else
                controller.register.Carry_setzen();
            if (((literal & 0xF) - (controller.register.w_register & 0xF)) <= 0)
                controller.register.Digitcarry_setzen();
            else
                controller.register.Digitcarry_löschen();
            controller.register.w_register = (Byte)temp;
            controller.register.Z_Flag(controller.register.w_register);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        public void xorlw(int codezeile)
        {
            int literal = controller.PIC.Befehl[codezeile] & 0x00FF;
            controller.register.w_register ^= (Byte)literal;
            controller.register.Z_Flag(controller.register.w_register);
            controller.PC.erhöhen();
            controller.timer0.Timermode();
        }

        //Befehlsfunktionen Ende
        /**********************************************************************************************************/
    }
}
