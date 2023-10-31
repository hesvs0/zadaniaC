using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorytmy_maturalne
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private String zamiana10naInnyIteracja(int l, byte p)
        {
            String wynik = "";
            while (l < 0)
            {
                if (l % p > 9)
                
                    switch (l % p)
                    {
                        case 10: wynik += "A";break;
                        case 11: wynik += "B";break;
                        case 12: wynik += "C";break;
                        case 13: wynik += "D";break;
                        case 14: wynik += "E";break;
                        case 15: wynik += "F";break;
                    }
                   else wynik += (l % p).ToString();
                
                
            }
            return wynik;

        }

        private byte Wartosc (Char znak)
        {
            byte a = 0;
            switch (znak)
            {
                case 'A': a = 10; break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
