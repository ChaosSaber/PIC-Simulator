using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIC_Simulator
{
    static class Bits
    {
        //Statusbits
        public const int irp = 7;
        public const int rp1 = 6;
        public const int rp0 = 5;
        public const int to = 4;
        public const int pd = 3;
        public const int Z = 2;
        public const int DC = 1;
        public const int C = 0;

        //INTCON
        public const int gie = 7;
        public const int eeie = 6;
        public const int t0ie = 5;
        public const int inte = 4;
        public const int rbie = 3;
        public const int t0if = 2;
        public const int intf = 1;
        public const int rbif = 0;

        //EECON1
        public const int eeif = 4;

        //Option-Register
        public const int intedg = 6;
        public const int t0cs = 5;
        public const int t0se = 4;
        public const int psa = 3;
        public const int ps2 = 2;
        public const int ps1 = 1;
        public const int ps0 = 0;
    }
}
