using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pojęcie_funkcji__metody_
{
    public partial class Form1 : Form
    {
        float a = 0, b = 0, wynik = 0;

        void sumaBezArgumetowa()
        {
            wynik = a + b;
        }

        void sumaArgumetowa(float arg1, float arg2)
        {
            wynik = arg1 + arg2;
        }

        float suma(float  arg1, float arg2)
        {
            return arg1 + arg2;
        }
        string uniwersalna(object sender, float arg1, float arg2)
        {
            Button bt = sender as Button;
            string s= "";
            switch (bt.Tag)
            {
                case "+": s = arg1.ToString() + "+"
                        + arg2.ToString() + "="
                        + (arg1 + arg2).ToString(); break;
                case "-": s = arg1.ToString() + "-"
                        + arg2.ToString() + "="
                        +(arg1 - arg2).ToString(); break;
                default: s = "";break;
            }
            return s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a = (float)Convert.ToDouble(textBox1.Text);
            b = (float)Convert.ToDouble(textBox2.Text);
            sumaBezArgumetowa();
            string s = a.ToString() + "+" + b.ToString() + "=" + wynik.ToString();
            MessageBox.Show(s,"Wynik wykonania sumaBezArgumentowa",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            a = (float)Convert.ToDouble(textBox1.Text);
            b = (float)Convert.ToDouble(textBox2.Text);
            sumaArgumetowa(a,b);
            string s = a.ToString() + "+" + b.ToString() + "=" + wynik.ToString();
            MessageBox.Show(s, "Wynik wykonania sumaArgumetowa niezwracającej typu",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            a = (float)Convert.ToDouble(textBox1.Text);
            b = (float)Convert.ToDouble(textBox2.Text);
            wynik = suma(a, b);
            string s = a.ToString() + "+" + b.ToString() + "=" + wynik.ToString();
            MessageBox.Show(s, "Wynik wykonania suma zwracającej typ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(uniwersalna(sender, (float)Convert.ToDouble(textBox1.Text),
                (float)Convert.ToDouble(textBox2.Text)), "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void but(object sender, EventArgs e)
        {

        }
    }
}
