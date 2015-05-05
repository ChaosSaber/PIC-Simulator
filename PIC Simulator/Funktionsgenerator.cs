using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIC_Simulator
{
    internal class Funktionsgenerator
    {
        private int Pin = Pins.nc;
        private int verhältnis = 1;//noch nicht implementiert
        Register register;
        Form1 PIC;

        public Funktionsgenerator(Form1 pic,Register speicher)
        {
            PIC = pic;
            register = speicher;
        }

        public void change_pin()
        {
            if (Pin > 2)
            {
                if (register.bit_gesetzt(Pin / 10, Pin % 10))
                    register.bit_löschen(Pin / 10, Pin % 10);
                else
                    register.bit_setzen(Pin / 10, Pin % 10);
                PIC.update_port_datagrids();
                PIC.Speicher_grid_updaten(Pin / 10);
            }
        }

        public void set_Pin(int pin)
        {
            Pin = pin;
        }

        public int get_pin()
        {
            return Pin;
        }
    }
}
