using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIC_Simulator
{
    class Stack
    {
        private List<int> Stacklist = new List<int>(8); //Stack Liste; FiLo-Liste ; enthält 8 Werte
        private int stackpointer = 0;//enthält die aktuelle Position des TOS;Wert wird Modulo 8 genommen, falls TOS größer 8 oder kleiner 0
        //erhöht den Stackpointer und speichert an dieser Stelle den neuen Wert
        public void Add(int Wert)
        {
            stackpointer++;
            Stacklist[Math.Abs(stackpointer) % 8] = Wert;
        }
        //gibt den Wert zurück auf den der Stackpointer zeigt und verringert den Stackpointer um 1
        public int Pop()
        {
            int temp = Stacklist[Math.Abs(stackpointer) % 8];
            stackpointer--;
            return temp;
        }
    }
}
