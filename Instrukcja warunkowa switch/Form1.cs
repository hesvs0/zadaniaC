using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Instrukcja_warunkowa_switch
{
    public partial class Form1 : Form
    {
        byte dzialanie = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                switch (rb.Text)
                {
                    case "+": dzialanie = 1; break;
                    case "-": dzialanie = 2; break;
                    case "*": dzialanie = 3; break;
                    case "/": dzialanie = 4; break;
                    default: dzialanie = 5; break;
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float a = Convert.ToInt16(textBox1.Text),
            b = Convert.ToInt16(textBox2.Text),
            wynik = 0;


            switch (dzialanie)
            {
                case 1: wynik = a + b; break;
                case 2: wynik = a - b; break;
                case 3: wynik = a * b; break;
                case 4:
                    if (b != 0)
                    {
                        wynik = a / b;
                    }
                    else
                    {
                       
                        label3.Text = "Dziełenie przez zero";
                    }
                    break;
                default: wynik = 0; break;

            }
           
            label3.Text = wynik.ToString();
        }
    }
}
