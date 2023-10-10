using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator_prosty
{
    public partial class Form1 : Form
    {
        float a = 0, b = 0, w = 0;

        enum Dzialanie {BRAK,
        DODAWANIE,
        ODEJMOWANIE,
        DZIELENIE,
        MNOZENIE};
        
        Dzialanie dzialanie= Dzialanie.BRAK;

        private void button1_Click(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            textBox1.Text += c.Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1) return;
            a = (float)Convert.ToDouble(textBox1.Text);
            textBox1.Text = "";

            Control c = (Control)sender;

            switch (c.Text) 
            {
                case "/": dzialanie = Dzialanie.DZIELENIE; break;
                case "*": dzialanie = Dzialanie.MNOZENIE; break;
                case "-": dzialanie = Dzialanie.ODEJMOWANIE; break;
                case "+": dzialanie = Dzialanie.DODAWANIE; break;
                default: dzialanie = Dzialanie.BRAK; break;

            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0) b = (float)Convert.ToDouble(textBox1.Text);
            else b = 0;

            switch (dzialanie) 
            {
                case Dzialanie.DODAWANIE: w = a + b; break;
                case Dzialanie.ODEJMOWANIE: w = a - b; break;
                case Dzialanie.DZIELENIE: w = a / b; break;
                case Dzialanie.MNOZENIE : w = a * b; break;
                default: w = a; break;
            }
            textBox1.Text = w.ToString();

            a = 0;
            b = 0;
            w = 0;
            dzialanie = Dzialanie.BRAK;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1) return;
            string zrodlo = textBox1.Text;
            textBox1.Text = zrodlo.Substring(0, zrodlo.Length - 1);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1) return;
            textBox1.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Control przecinek = (Control)sender;
            textBox1.Text += przecinek.Text;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
