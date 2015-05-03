using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIC_Simulator
{
    class Pins
    {
        public const int nc = 0;
        public const int Vdd = 1;
        public const int GND = 2;
        public const int RA0 = Register.porta * 10;
        public const int RA1 = Register.porta * 10 + 1;
        public const int RA2 = Register.porta * 10 + 2;
        public const int RA3 = Register.porta * 10 + 3;
        public const int RA4 = Register.porta * 10 + 4;
        public const int RA5 = Register.porta * 10 + 5;
        public const int RA6 = Register.porta * 10 + 6;
        public const int RA7 = Register.porta * 10 + 7;
        public const int RB0 = Register.portb * 10;
        public const int RB1 = Register.portb * 10 + 1;
        public const int RB2 = Register.portb * 10 + 2;
        public const int RB3 = Register.portb * 10 + 3;
        public const int RB4 = Register.portb * 10 + 4;
        public const int RB5 = Register.portb * 10 + 5;
        public const int RB6 = Register.portb * 10 + 6;
        public const int RB7 = Register.portb * 10 + 7;

        public static String ToString(int pin)
        {
            switch(pin)
            {
                case nc: return "nc";
                case Vdd: return "Vdd";
                case GND: return "GND";
                case RA0: return "RA0";
                case RA1: return "RA1";
                case RA2: return "RA2";
                case RA3: return "RA3";
                case RA4: return "RA4";
                case RA5: return "RA5";
                case RA6: return "RA6";
                case RA7: return "RA7";
                case RB0: return "RB0";
                case RB1: return "RB1";
                case RB2: return "RB2";
                case RB3: return "RB3";
                case RB4: return "RB4";
                case RB5: return "RB5";
                case RB6: return "RB6";
                case RB7: return "RB7";
                default: return "";
            }
        }
    }
}
