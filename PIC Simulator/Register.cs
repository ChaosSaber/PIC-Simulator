using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIC_Simulator
{
    class Register
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
    }
}
