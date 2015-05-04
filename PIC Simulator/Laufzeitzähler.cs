using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIC_Simulator
{
    class Laufzeitzähler
    {
        private double laufzeitzähler = 0;

        public void Reset()
        {
            laufzeitzähler = 0;
        }

        public void erhöhen(double wert)
        {
            laufzeitzähler += wert;
        }

        public double get()
        {
            return laufzeitzähler;
        }

        override public String ToString()
        {
            return laufzeitzähler.ToString("F4") + " µs";
        }
    }
}
