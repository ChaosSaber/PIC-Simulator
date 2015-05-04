using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIC_Simulator
{
    class Quarzfrequenz
    {
        public const int _50kHz = 0;
        public const int _100kHz = 1;
        public const int _250kHz=2;
        public const int _500kHz=3;
        public const int _1MHz = 4;
        public const int _1_5MHz=5;
        public const int _2MHz = 6;
        public const int _2_5MHz = 7;
        public const int _3MHz = 8;
        public const int _3_5MHz = 9;
        public const int _4MHZ = 10;
        public const int _4_5MHz = 11;
        public const int _5MHZ = 12;
        public const int _6MHZ = 13;
        public const int _7MHz = 14;
        public const int _8MHz = 15;
        public const int _9MHz = 16;
        public const int _10MHz = 17;
        private int[] Frequenzen = new int[3];
        private String[] Name = new String[3];
        private int frequenz=0;
        public const int MAX = 3;


        public Quarzfrequenz()
        {//TODO beenden
            Frequenzen[_50kHz] = 50000;
            Frequenzen[_100kHz] = 100000;
            Frequenzen[_250kHz] = 250000;
            Frequenzen[_500kHz] = 500000;
            Frequenzen[_1_5MHz] = 1500000;


            Frequenzen[_4MHZ] = 4000000;
            Frequenzen[_5MHZ] = 5000000;
            Frequenzen[_6MHZ] = 6000000;

            Name[_50kHz] = "50 kHz";
            Name[_100kHz] = "100 kHz";
            Name[_250kHz] = "250 kHz";
            Name[_4MHZ] = "4,0 MHz";
            Name[_5MHZ] = "5,0 MHz";
            Name[_6MHZ] = "6,0 MHz";
        }

        public void set(int Auswahl)
        {
            frequenz = Auswahl;
        }

        public int get_frequenz()
        {
            return Frequenzen[frequenz];
        }

        public double get_time()
        {
            return 1000000.0 / get_frequenz();
        }
        public String get_String_frequenz()
        {
            return Name[frequenz];
        }

        public String get_String_frequenz(int index)
        {
            return Name[index];
        }

        public String ToString_time()
        {
            return get_time().ToString("F4") + " µs";
        }
    }
}
