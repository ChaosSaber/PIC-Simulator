using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PIC_Simulator
{
    class Stack
    {
        private List<int> Stacklist = new List<int>(8); //Stack Liste; FiLo-Liste ; enthält 8 Werte
        private int stackpointer = -1;//enthält die aktuelle Position des TOS;Wert wird Modulo 8 genommen, falls TOS größer 8 oder kleiner 0
        Controller controller;
        Label[] label_zeiger;
        Label[] label_wert;

        public Stack(Controller controller)
        {
            this.controller=controller;
            label_zeiger = new Label[]{
                controller.PIC.label_Stack0_Pfeil,
                controller.PIC.label_Stack1_Pfeil,
                controller.PIC.label_Stack2_Pfeil,
                controller.PIC.label_Stack3_Pfeil,
                controller.PIC.label_Stack4_Pfeil,
                controller.PIC.label_Stack5_Pfeil,
                controller.PIC.label_Stack6_Pfeil,
                controller.PIC.label_Stack7_Pfeil
            };
            label_wert = new Label[]{
                controller.PIC.label_Stack0_Wert,
                controller.PIC.label_Stack1_Wert,
                controller.PIC.label_Stack2_Wert,
                controller.PIC.label_Stack3_Wert,
                controller.PIC.label_Stack4_Wert,
                controller.PIC.label_Stack5_Wert,
                controller.PIC.label_Stack6_Wert,
                controller.PIC.label_Stack7_Wert
            };
            //Liste initielisieren
            for (int i = 0; i < 8; i++)
                Stacklist.Add(0);
            anzeigen();
        }
        //erhöht den Stackpointer und speichert an dieser Stelle den neuen Wert
        public void Add(int Wert)
        {
            stackpointer++;
            Stacklist[stackpointer & 0x7] = Wert;
            anzeigen();
        }

        //gibt den Wert zurück auf den der Stackpointer zeigt und verringert den Stackpointer um 1
        public int Pop()
        {
            int temp = Stacklist[Math.Abs(stackpointer) % 8];
            stackpointer--;
            anzeigen();
            return temp;
        }

        private void anzeigen()
        {
            //alten Zeiger löschen
            for (int i = 0; i < 8; i++)
                label_zeiger[i].Text = "";
            label_zeiger[stackpointer & 0x7].Text = "------->";
            for(int i=0;i<8;i++)
            {
                label_wert[i].Text = Stacklist[i].ToString("X4");
            }
        }
    }
}
