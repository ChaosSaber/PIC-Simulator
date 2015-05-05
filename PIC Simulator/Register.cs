using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIC_Simulator
{
    internal class Register
    {
        public const int indf = 0;
        public const int tmr0 = 1;
        public const int pcl = 2;
        public const int status = 3;
        public const int fsr = 4;
        public const int porta = 5;
        public const int portb = 6;
        public const int eedata = 8;
        public const int eeadr = 9;
        public const int pclath = 0xA;
        public const int intcon = 0xB;
        public const int option_reg = 0x81;
        public const int trisa = 0x85;
        public const int trisb = 0x86;
        public const int eecon1 = 0x88;
        public const int eecon2 = 0x89;
        public Byte[] Speicher = new Byte[256];//Registerspeicher
        public Byte w_register;

        Form1 PIC;

        public Register(Form1 pic)
        {
            PIC = pic;
        }


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
                PIC.Speicher_grid_updaten(adresse + 0x80);
                return;
            }
            if (adresse > 0x8B && adresse < 0xD0 || adresse >= 0x82 && adresse <= 0x84 || adresse == 0x8A || adresse == 0x8B)
            {
                Speicher[adresse - 0x80] = Speicher[adresse];
                PIC.Speicher_grid_updaten(adresse - 0x80);
            }
        }
        public void pcl_geändert(int adresse)
        {
            //Wenn dass PCL-Register das Ziel eines Schreibbefehls ist wird das PCLATH-Register ins PCH geladen
            if (adresse % 0x80 == Register.pcl)
                PIC.PC.PCH = Speicher[Register.pcl];
        }
        public void speichern(int adresse, int d, Byte ergebnis)
        {
            //d=1->ergebnis in Speicheradresse speichern, d=0 in w-reg speichern
            if (d > 0)
            {
                Speicher[adresse] = ergebnis;
                pcl_geändert(adresse);
                PIC.timer0_geändert(adresse);
                PIC.Speicher_grid_updaten(adresse);
                Speicher_mapping(adresse);
            }
            else
                w_register = ergebnis;
        }
        public void bit_setzen(int register, int Bit)
        {
            Speicher[register] = (Byte)(Speicher[register] | (1 << Bit));
            Speicher_mapping(register);
            pcl_geändert(register);
            PIC.timer0_geändert(register);
            PIC.Speicher_grid_updaten(register);
        }
        public void bit_löschen(int register, int Bit)
        {
            Speicher[register] = (Byte)(Speicher[register] & ~(1 << Bit));
            Speicher_mapping(register);
            pcl_geändert(register);
            PIC.timer0_geändert(register);
            PIC.Speicher_grid_updaten(register);
        }
        public Boolean bit_gesetzt(int register, int Bit)
        {
            return (Speicher[register] & (1 << Bit)) > 0;
        }
        
        
    }
}
