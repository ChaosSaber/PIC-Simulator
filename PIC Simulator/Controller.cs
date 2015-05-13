using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIC_Simulator
{
    class Controller
    {
        public Form1 PIC;
        public Register register;
        public Programmcounter PC;
        public Funktionsgenerator FG;
        public Interrupt interrupt;
        public Timer0 timer0;
        public Programmablauf program;

        public Stack TOS = new Stack();
        public Laufzeitzähler laufzeitzähler = new Laufzeitzähler();
        public Quarzfrequenz quarzfrequenz = new Quarzfrequenz();

        public Controller(Form1 pic)
        {
            PIC = pic;
            register = new Register(this);
            PC = new Programmcounter(this);
            FG = new Funktionsgenerator(this);
            interrupt = new Interrupt(this);
            timer0 = new Timer0(this);
            program = new Programmablauf(this);
        }
    }
}
