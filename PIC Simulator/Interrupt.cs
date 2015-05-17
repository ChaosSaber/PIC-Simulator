using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIC_Simulator
{
    internal class Interrupt
    {
        Byte RB0_alt = 0; //alter Stand(vom letzten Programmzyklus) des RB0-Bit
        Byte RB_alt = 0; //alter Stand(vom letzten Programmzyklus) des Port B
        Byte Timer0_alt = 0; //alter Stand(vom letzten Programmzyklus) des Timer0

        Controller controller;

        public Interrupt(Controller controller)
        {
            this.controller = controller;
            init();
        }


        //manual Seite 31
        //wenn ein Interrupt passiert wird an die Stelle 4 gesprungen
        public void Flags_setzen()
        {
            intf_setzen();
            rbif_setzen();
        }

        public void init()
        {
            Timer0_alt = 0;
            RB_alt = (Byte)(controller.register.Speicher[Register.portb] & 0xF0);
            RB0_alt = (Byte)(controller.register.Speicher[Register.portb] & 0x01);
        }

        //prüft ob ein Interrupt ausgeführt werden muss
        //wenn ja wird der controller.PC auf Stelle 4 gesetzt 
        public void ausführen()
        {
            if (timer0_interrupt() || external_Interrupt() || rb0_interrupt() || EE_interrupt())
            {
                //For external interrupt events, such as the RB0/INT pin or PORTB change interrupt, the interrupt latency will be three to four instruction cycles.
                controller.timer0.Timermode();
                controller.timer0.Timermode();
                controller.timer0.Timermode();
                controller.timer0.Timermode();
                //TODO aus SLEEP-MODE aufwachen
                //wacht nicht aus SLEEP-Mode auf wenn timer0_interrupt
                if (controller.register.bit_gesetzt(Register.intcon, Bits.gie))
                {
                    controller.TOS.Add(controller.PC.get());
                    controller.PC.set(4);
                    controller.register.bit_löschen(Register.intcon, Bits.gie);
                }
            }
        }
        public void t0if_setzen()
        {//wenn Timer0 überläuft
            if (Timer0_alt == 255 && controller.register.Speicher[Register.tmr0] == 0)
                controller.register.bit_setzen(Register.intcon, Bits.t0if);
            Timer0_alt = controller.register.Speicher[Register.tmr0];
        }
        private void intf_setzen()
        {//external interruptflag
            //The RB0/INT external interrupt occurred (must be cleared in software)
            //wenn das intedg im Optionsregister gesetzt ist bei einer steigenden flanke, ansonsten bei einer fallenden
            if (controller.register.bit_gesetzt(Register.option_reg, Bits.intedg))
            {
                if (RB0_alt == 0 && (controller.register.Speicher[Register.portb] & 0x01) == 1)
                    controller.register.bit_setzen(Register.intcon, Bits.intf);
            }
            else
                if (RB0_alt == 1 && (controller.register.Speicher[Register.portb] & 0x01) == 0)
                    controller.register.bit_setzen(Register.intcon, Bits.intf);
            RB0_alt = (Byte)(controller.register.Speicher[Register.portb] & 0x01);
        }
        private void rbif_setzen()
        {//RB Port Change
            //At least one of the RB7:RB4 pins changed state (must be cleared in software)
            if (RB_alt != (controller.register.Speicher[Register.portb] & 0xF0 & controller.register.Speicher[Register.trisb]))
                controller.register.bit_setzen(Register.intcon, Bits.rbif);
            RB_alt = (Byte)(controller.register.Speicher[Register.portb] & 0xF0 & controller.register.Speicher[Register.trisb]);
        }
        private Boolean timer0_interrupt()
        {
            if (controller.register.bit_gesetzt(Register.intcon, Bits.t0ie) && controller.register.bit_gesetzt(Register.intcon, Bits.t0if))
                return true;
            return false;
        }
        private Boolean external_Interrupt()
        {
            if (controller.register.bit_gesetzt(Register.intcon, Bits.inte) && controller.register.bit_gesetzt(Register.intcon, Bits.intf))
                return true;
            return false;
        }
        private Boolean rb0_interrupt()
        {
            if (controller.register.bit_gesetzt(Register.intcon, Bits.rbie) && controller.register.bit_gesetzt(Register.intcon, Bits.rbif))
                return true;
            return false;
        }
        private Boolean EE_interrupt()
        {//EE Write Complete Interrupt
            if (controller.register.bit_gesetzt(Register.intcon, Bits.eeie) && controller.register.bit_gesetzt(Register.eecon1, Bits.eeif))
                return true;
            return false;
        }
    }
}
