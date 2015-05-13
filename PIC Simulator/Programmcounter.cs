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
        Controller controller;

        public Programmcounter(Controller controller)
        {
            this.controller = controller;
        }

        public void set(int Wert)
        {
            controller.register.Speicher[Register.pcl + 0x80] = (Byte)(Wert & 0xFF);
            controller.register.Speicher[Register.pcl] = (Byte)(Wert & 0xFF);
            PCH = (Byte)((Wert & 0x1F00) >> 8);
            controller.PIC.Speicher_grid_updaten(Register.pcl);
            controller.PIC.Speicher_grid_updaten(Register.pcl + 0x80);
        }
        public int get()
        {
            return (PCH << 8) + controller.register.Speicher[Register.pcl];
        }
        public void erhöhen()//PC um 1 erhöhen
        {
            if ((controller.register.Speicher[Register.pcl + 0x80] += 1) == 0)
                PCH++;
            controller.register.Speicher[Register.pcl] += 1;
            controller.PIC.Speicher_grid_updaten(Register.pcl);
            controller.PIC.Speicher_grid_updaten(Register.pcl + 0x80);
        }
    }
}
