using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIC_Simulator
{
    class Parser
    {


        public static int parsen(int Befehl, ref Boolean NOP)
        {
            int maskiert;
            if (NOP)
            {
                NOP = false;//NOP zurücksetzen damit die nächste Zeile wieder normal ausgeführt wird
                return tokens.nop;
            }
            //Befehle mit bestimmter Codeabfolge
            if (Befehl == 0x0064) return tokens.clrwdt;
            if (Befehl == 0x0009) return tokens.retfie;
            if (Befehl == 0x0008) return tokens._return;
            if (Befehl == 0x0063) return tokens.sleep;

            //NOP
            maskiert = Befehl & 0xFF9F;
            if (maskiert == 0) return tokens.nop;

            //Befehle mit 3-stelliger Codeabfolge
            maskiert = Befehl & 0xF800;
            if (maskiert == 0x2000) return tokens.call;
            if (maskiert == 0x2800) return tokens._goto;

            //Befehle mit 4-stelliger Codeabfolge
            maskiert = Befehl & 0xFC00;
            if (maskiert == 0x1000) return tokens.bcf;
            if (maskiert == 0x1400) return tokens.bsf;
            if (maskiert == 0x1800) return tokens.btfsc;
            if (maskiert == 0x1C00) return tokens.btfss;
            if (maskiert == 0x3000) return tokens.movlw;
            if (maskiert == 0x3400) return tokens.retlw;

            //Befehle mit 5-stelliger Codeabfolge
            maskiert = Befehl & 0xFE00;
            if (maskiert == 0x3E00) return tokens.addlw;
            if (maskiert == 0x3C00) return tokens.sublw;

            //Befehle mit 6-stelliger codeabfolge
            maskiert = Befehl & 0xFF00;
            if (maskiert == 0x0700) return tokens.addwf;
            if (maskiert == 0x0500) return tokens.andwf;
            if (maskiert == 0x0900) return tokens.comf;
            if (maskiert == 0x0300) return tokens.decf;
            if (maskiert == 0x0B00) return tokens.decfsz;
            if (maskiert == 0x0A00) return tokens.incf;
            if (maskiert == 0x0F00) return tokens.incfsz;
            if (maskiert == 0x0400) return tokens.iorwf;
            if (maskiert == 0x0800) return tokens.movf;
            if (maskiert == 0x0D00) return tokens.rlf;
            if (maskiert == 0x0C00) return tokens.rrf;
            if (maskiert == 0x0200) return tokens.subwf;
            if (maskiert == 0x0E00) return tokens.swapf;
            if (maskiert == 0x0600) return tokens.xorwf;
            if (maskiert == 0x3900) return tokens.andlw;
            if (maskiert == 0x3800) return tokens.iorlw;
            if (maskiert == 0x3A00) return tokens.xorlw;

            //Befehle mit 7-stelliger Codeabfolge
            maskiert = Befehl & 0xFF80;
            if (maskiert == 0x0180) return tokens.clrf;
            if (maskiert == 0x0100) return tokens.clrw;
            if (maskiert == 0x0080) return tokens.movwf;

            //ansonsten
            return -1;
        }
    }
}
