using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIC_Simulator
{
    class Timer0
    {
        private int Ra4_alt;//enthält den alten Wert des RA4-Bits(entweder 16 oder 0, weil 2^4=16)
        private int prescaler;

        Controller controller;


        public Timer0(Controller controller)
        {
            this.controller = controller;
            init();
        }

        public void init()
        {
            Ra4_alt = (Byte)(controller.register.Speicher[Register.porta] & 0x10);
            prescaler = 0;
        }

        public void ausführen()
        {
            /*
             * wenn das T0CS-Bit im Optoinsregister gesetzt ist ist der Timer0 im Counter
             * wenn das T0SE-Bit im Optionsregister gesetzt ist wird bei einer fallenden
             * Flanke das Timer0-Register erhöht, ansonsten bei einer fallenden
             */
            if (controller.register.bit_gesetzt(Register.option_reg, Bits.t0cs))
            {
                if (controller.register.bit_gesetzt(Register.option_reg, Bits.t0se))
                {//ra4_alt==16, weil es das 5. Bit ist;2^4=16
                    if (Ra4_alt == 16 && (controller.register.Speicher[Register.porta] & 0x10) == 0)
                        timer0_erhöhen();
                }
                else
                {//5.Bit deshalb 16(2^4=16)
                    if (Ra4_alt == 0 && (controller.register.Speicher[Register.porta] & 0x10) == 16)
                        timer0_erhöhen();
                }
            }
            Ra4_alt = (Byte)(controller.register.Speicher[Register.porta] & 0x10);
        }

        public void geändert(int adresse)
        {
            //wenn das Timer0 controller.register beschrieben wird und der Prescaler dem Timer0 zugewiesen ist
            //wird der Prescaler resettet
            if (adresse == Register.tmr0 && !controller.register.bit_gesetzt(Register.option_reg, Bits.psa))
                prescaler = 0;
        }

        private void timer0_erhöhen()
        {
            //wenn das PSA-Bit im Optionsregister NICHT gesetzt ist wird der Prescaler dem Timer0 zugewiesen
            if (controller.register.bit_gesetzt(Register.option_reg, Bits.psa))
            {
                controller.register.Speicher[Register.tmr0]++;
                controller.interrupt.t0if_setzen();
            }
            else
            {
                prescaler++;
                //Prescaler PS2:PS0(Bit0-2 vom Optionsregister)
                //prescale value von 1:2,1:4,...,1:256
                //000==1:2;001==1:4.......
                if (Math.Pow(2, (controller.register.Speicher[Register.option_reg] & 0x07) + 1) >= prescaler)
                {
                    controller.register.Speicher[Register.tmr0]++;
                    controller.interrupt.t0if_setzen();
                    prescaler = 0;
                }
            }
        }
        public void Timermode()
        {
            //wenn Timer0 im Timer mode erhöhe den Timer0
            if (!controller.register.bit_gesetzt(Register.option_reg, Bits.t0cs))
                timer0_erhöhen();

        }
    }
}
