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
        Controller controller;

        public Funktionsgenerator(Controller controller)
        {
            this.controller = controller;
        }

        public void change_pin()
        {
            if (Pin > 2)
            {
                if (controller.register.bit_gesetzt(Pin / 10, Pin % 10))
                    controller.register.bit_löschen(Pin / 10, Pin % 10);
                else
                    controller.register.bit_setzen(Pin / 10, Pin % 10);
                controller.PIC.update_port_datagrids();
                controller.PIC.Speicher_grid_updaten(Pin / 10);
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
