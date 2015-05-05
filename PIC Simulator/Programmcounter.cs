using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIC_Simulator
{
    internal class Programmcounter
    {
        public Byte PCH = 0;//High-Byte des Programmcounter(PC<12:8>)
        Register register;
        Form1 PIC;

        public Programmcounter(Form1 pic,Register speicher)
        {
            PIC = pic;
            register = speicher;
        }

        public void set(int Wert)
        {
            register.Speicher[Register.pcl + 0x80] = (Byte)(Wert & 0xFF);
            register.Speicher[Register.pcl] = (Byte)(Wert & 0xFF);
            PCH = (Byte)((Wert & 0x1F00) >> 8);
            PIC.Speicher_grid_updaten(Register.pcl);
            PIC.Speicher_grid_updaten(Register.pcl + 0x80);
        }
        public int get()
        {
            return (PCH << 8) + register.Speicher[Register.pcl];
        }
        public void erhöhen()//PC um 1 erhöhen
        {
            if ((register.Speicher[Register.pcl + 0x80] += 1) == 0)
                PCH++;
            register.Speicher[Register.pcl] += 1;
            PIC.Speicher_grid_updaten(Register.pcl);
            PIC.Speicher_grid_updaten(Register.pcl + 0x80);
        }
    }
}
