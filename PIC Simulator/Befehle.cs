using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIC_Simulator
{
    class Befehle
    {
        Register register;
        Form1 PIC;
        Programmcounter PC;
        Stack TOS;


        public Befehle(Form1 pic,Register speicher,Programmcounter pc,Stack tos)
        {
            PIC = pic;
            register = speicher;
            PC = pc;
            TOS = tos;
        }


        
        //Hilfsfunktionen für Befehlsfunktionen
        public int adressänderungen(ref int adresse)
        {
            //Wenn das RP0-Bit des Statusregisters gesetzt ist wird auf Bank 1 umgeschaltet (alle Register um 80H erhöht)
            if (Bank1())
                adresse += 0x80;
            //wenn die Zieladresse das INDF-Register(0 oder 80H bei Bank 1) ist, dann wird anstelle des Registers 0/80H
            //an die Registerstelle gespeichert, die das FSR-Register(4 oder 84H bei Bank 1) enthält
            if (adresse % 0x80 == 0)
                adresse = register.Speicher[Register.fsr];
            return adresse;
        }
        public Boolean Bank1()
        {
            return register.bit_gesetzt(Register.status, Bits.rp0);
        }

        //Befehlsfunktionen
        //Status = Speicheradresse 3
        //Statusbits:
        //IRP=7;RP1=6;RP0=5;TO(quer)=4;PD(quer)=3;Z=2;DC=1;C=0


        public void addwf(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = PIC.Befehl[codezeile] & 0x0080;
            int temp = register.Speicher[adresse] + register.w_register;
            if ((adresse % 0x80) != Register.status)
            {
                if (temp > 255)//wenn das Ergebnis>255(1Byte) dann setze das Carrybit, ansonsten lösche es
                    register.Carry_setzen();
                else
                    register.Carry_löschen();
                if ((register.Speicher[adresse] & 0xF + register.w_register & 0xF) > 15)
                    register.Digitcarry_setzen();
                else
                    register.Digitcarry_löschen();
            }

            Byte ergebnis = (Byte)temp;
            register.speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status)
                register.Z_Flag(ergebnis);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void andwf(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = PIC.Befehl[codezeile] & 0x0080;
            Byte ergebnis = (Byte)(register.Speicher[adresse] & register.w_register);
            register.speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status)
                register.Z_Flag(ergebnis);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void clrf(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            register.speichern(adresse, 1, 0);
            if (adresse % 0x80 != Register.status)
                register.Z_Flag(register.Speicher[adresse]);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void clrw(int codezeile)
        {
            register.w_register = 0;
            register.Z_Flag(register.w_register);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void comf(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = PIC.Befehl[codezeile] & 0x0080;
            Byte ergebnis = (Byte)~register.Speicher[adresse];
            register.speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status)
                register.Z_Flag(ergebnis);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void decf(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = PIC.Befehl[codezeile] & 0x0080;
            Byte ergebnis = (Byte)(register.Speicher[adresse] - 1);
            register.speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status)
                register.Z_Flag(ergebnis);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void decfsz(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = PIC.Befehl[codezeile] & 0x0080;
            Byte ergebnis = (Byte)(register.Speicher[adresse] - 1);
            register.speichern(adresse, d, ergebnis);
            if (ergebnis == 0)
                PIC.NOP = true;//nächste Anweisung überspringen
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void incf(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = PIC.Befehl[codezeile] & 0x0080;
            Byte ergebnis = (Byte)(register.Speicher[adresse] + 1);
            register.speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status)
                register.Z_Flag(ergebnis);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void incfsz(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = PIC.Befehl[codezeile] & 0x0080;
            Byte ergebnis = (Byte)(register.Speicher[adresse] + 1);
            register.speichern(adresse, d, ergebnis);
            if (ergebnis == 0)
                PIC.NOP = true;//nächste Anweisung wird überspringen
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void iorwf(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = PIC.Befehl[codezeile] & 0x0080;
            Byte ergebnis = (Byte)(register.Speicher[adresse] | register.w_register);
            register.speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status)
                register.Z_Flag(ergebnis);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void movf(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = PIC.Befehl[codezeile] & 0x0080;
            register.speichern(adresse, d, register.Speicher[adresse]);
            if (adresse % 0x80 != Register.status)
                register.Z_Flag(register.Speicher[adresse]);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void movwf(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            register.speichern(adresse, 1, register.w_register);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void nop(int codezeile)
        {
            PC.erhöhen();
            PIC.Timer0_Timermode();
            return;//tue nichts
        }

        public void rlf(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = PIC.Befehl[codezeile] & 0x0080;
            Boolean carry = register.bit_gesetzt(Register.status, Bits.C);//Carrybit zwischenspeichern
            if (register.bit_gesetzt(adresse, 7))//wenn Bit7=1 dann setze Carrybit, ansonsten nicht
                register.Carry_setzen();
            else
                register.Carry_löschen();
            Byte ergebnis = (Byte)(register.Speicher[adresse] << 1);
            if (carry)
                ergebnis |= (Byte)0x01;//wenn das Carrybit am Anfang gesetzt war, setze das Bit0 auf 1
            register.speichern(adresse, d, ergebnis);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void rrf(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = PIC.Befehl[codezeile] & 0x0080;
            Boolean carry = register.bit_gesetzt(Register.status, Bits.C);//Carrybit zwischenspeichern
            if (register.bit_gesetzt(adresse, 0))//wenn Bit0=1 dann setze Carrybit, ansonsten nicht
                register.Carry_setzen();
            else
                register.Carry_löschen();
            Byte ergebnis = (Byte)(register.Speicher[adresse] >> 1);
            if (carry)
                ergebnis |= (Byte)0x80;//wenn das Carrybit am Anfang gesetzt war, setze das Bit7
            register.speichern(adresse, d, ergebnis);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void subwf(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = PIC.Befehl[codezeile] & 0x0080;
            int temp = register.Speicher[adresse] - register.w_register;
            if (adresse % 0x80 != Register.status)
            {
                if (temp <= 0)//wenn das Ergebnis<0 dann lösche das Carrybit, ansonsten setze es
                    register.Carry_löschen();
                else
                    register.Carry_setzen();
                if ((register.Speicher[adresse] & 0xF - register.w_register & 0xF) <= 0)
                    register.Digitcarry_setzen();
                else
                    register.Digitcarry_löschen();
            }
            Byte ergebnis = (Byte)temp;
            register.speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status)
                register.Z_Flag(ergebnis);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void swapf(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = PIC.Befehl[codezeile] & 0x0080;
            Byte ergebnis = (Byte)((register.Speicher[adresse] & 0xF0) >> 4);//Bit(7-4) maskieren und auf Position 3-0 verschieben
            ergebnis |= (Byte)((register.Speicher[adresse] & 0x0F) << 4);//Bit(3-0) maskieren und auf Position 7-4 verschieben sowie mit vorherigen Schritt verodern
            register.speichern(adresse, d, ergebnis);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void xorwf(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int d = PIC.Befehl[codezeile] & 0x0080;
            Byte ergebnis = (Byte)(register.Speicher[adresse] ^ register.w_register);
            register.speichern(adresse, d, ergebnis);
            if (adresse % 0x80 != Register.status)
                register.Z_Flag(ergebnis);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void bcf(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int bitnummer = PIC.Befehl[codezeile] & 0x0380;
            bitnummer >>= 7;
            register.bit_löschen(adresse, bitnummer);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void bsf(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int bitnummer = PIC.Befehl[codezeile] & 0x0380;
            bitnummer >>= 7;
            register.bit_setzen(adresse, bitnummer);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void btfsc(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int bitnummer = PIC.Befehl[codezeile] & 0x0380;
            bitnummer >>= 7;
            if (!register.bit_gesetzt(adresse, bitnummer))
                PIC.NOP = true;//nächste Anweisung PIC.NOP
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void btfss(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x007F;
            adressänderungen(ref adresse);
            int bitnummer = PIC.Befehl[codezeile] & 0x0380;
            bitnummer >>= 7;
            if (register.bit_gesetzt(adresse, bitnummer))
                PIC.NOP = true;//nächste Anweisung PIC.NOP
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void addlw(int codezeile)
        {
            int literal = PIC.Befehl[codezeile] & 0x00FF;
            int temp = literal + register.w_register;
            if (temp > 255)//wenn das Ergebnis>255(1 Byte) dann setze das Carrybit, ansonsten lösche es
                register.Carry_setzen();
            else
                register.Carry_löschen();
            if ((literal & 0xF + register.w_register & 0xF) > 15)
                register.Digitcarry_setzen();
            else
                register.Digitcarry_löschen();
            register.w_register = (Byte)temp;
            register.Z_Flag(register.w_register);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void andlw(int codezeile)
        {
            int literal = PIC.Befehl[codezeile] & 0x00FF;
            register.w_register &= (Byte)literal;
            register.Z_Flag(register.w_register);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void call(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x07FF; //Zielsprungadresse !!!!! KEINE Adressänderung !!!!!
            TOS.Add(PC.get() + 1);//PC + 1 -> TOS
            PC.set(adresse);//literal -> PC<10:0>
            //nächste Zeile kann so ausgeführt werden, da PC<12:11> an dieser Stelle 0
            PC.PCH |= (Byte)(register.Speicher[Register.pclath] & 0x18);//PCLATH<4:3> -> PC<12:11> 
            //2-cycle Instruction
            PIC.Timer0_Timermode();
            PIC.Timer0_Timermode();
        }

        public void clrwdt(int codezeile)
        {
            //WDT=0;
            //WDT prescaler=0;
            register.Speicher[Register.status + 0x80] |= 0x18;//Statusbit TO(Bit4) und PD(Bit3) setzen
            register.Speicher[Register.status] |= 0x18;//Statusbit TO(Bit4) und PD(Bit3) setzen
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void _goto(int codezeile)
        {
            int adresse = PIC.Befehl[codezeile] & 0x07FF; //Zielsprungadresse !!!!! KEINE Adressänderung !!!!!
            PC.set(adresse);//literal -> PC<10:0>
            PC.PCH |= (Byte)(register.Speicher[Register.pclath] & 0x18);//PCLATH<4:3> -> PC<12:11>
            PIC.Timer0_Timermode();
        }

        public void iorlw(int codezeile)
        {
            int literal = PIC.Befehl[codezeile] & 0x00FF;
            register.w_register |= (Byte)literal;
            register.Z_Flag(register.w_register);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void movlw(int codezeile)
        {
            int literal = PIC.Befehl[codezeile] & 0x00FF;
            register.w_register = (Byte)literal;
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void retfie(int codezeile)
        {
            //return from interrupt;
            PC.set(TOS.Pop());//TOS -> PC
            register.bit_setzen(Register.intcon + 0x80, Bits.gie);//1 -> GIE
            register.bit_setzen(Register.intcon, Bits.gie);
            PIC.Timer0_Timermode();
        }

        public void retlw(int codezeile)
        {
            int literal = PIC.Befehl[codezeile] & 0x00FF;
            register.w_register = (Byte)literal;
            PC.set(TOS.Pop());//TOS -> PC
            //Two-Cycle Instruction
            PIC.Timer0_Timermode();
            PIC.Timer0_Timermode();
        }

        public void _return(int codezeile)
        {
            //return from Subroutine
            PC.set(TOS.Pop());//TOS -> PC
            //this is a two-cycle instruction
            PIC.Timer0_Timermode();
            PIC.Timer0_Timermode();
        }

        public void sleep(int codezeile)
        {
            //The processor is put into SLEEP-mode with the oscillator stopped.
            //0 -> WDT
            //0 -> WDT prescaler
            register.bit_setzen(Register.status + 0x80, Bits.to);//TO-Bit(4) im Statusregister setzen
            register.bit_setzen(Register.status, Bits.to);//TO-Bit(4) im Statusregister setzen
            register.bit_löschen(Register.status + 0x80, Bits.pd);//PD-Bit(3) im Statusregister löschen
            register.bit_löschen(Register.status, Bits.pd);//PD-Bit(3) im Statusregister löschen            
            PIC.Timer0_Timermode();
        }

        public void sublw(int codezeile)
        {
            int literal = PIC.Befehl[codezeile] & 0x00FF;
            int temp = literal - register.w_register;
            if (temp <= 0)//wenn das Ergebnis<=0 dann lösche das Carrybit, ansonsten setze es
                register.Carry_löschen();
            else
                register.Carry_setzen();
            if ((literal & 0xF - register.w_register & 0xF) <= 0)
                register.Digitcarry_setzen();
            else
                register.Digitcarry_löschen();
            register.w_register = (Byte)temp;
            register.Z_Flag(register.w_register);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        public void xorlw(int codezeile)
        {
            int literal = PIC.Befehl[codezeile] & 0x00FF;
            register.w_register ^= (Byte)literal;
            register.Z_Flag(register.w_register);
            PC.erhöhen();
            PIC.Timer0_Timermode();
        }

        //Befehlsfunktionen Ende
        /**********************************************************************************************************/
    }
}
