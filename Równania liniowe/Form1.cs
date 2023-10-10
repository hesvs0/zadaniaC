using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Równania_liniowe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        float wyznaznik2x2(float _i1, float  _j1, float _i2, float _j2)
        {
            return _i1 * _j2 - _i2 * _j1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            label7.Text = textBox1.Text + "x" +
                "+" + textBox2.Text + "y" +
                "=" + textBox3.Text;
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            label8.Text = textBox4.Text + "x" +
                "+" + textBox5.Text + "y" + 
                "=" + textBox6.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float a1 = (float)Convert.ToDouble(textBox1.Text),


            b1 = (float)Convert.ToDouble(textBox2.Text),


            c1 = (float)Convert.ToDouble(textBox3.Text),


            a2 = (float)Convert.ToDouble(textBox4.Text),


            b2 = (float)Convert.ToDouble(textBox5.Text),


            c2 = (float)Convert.ToDouble(textBox6.Text);

            float Wx = wyznaznik2x2(c1, b1, c2, b2),
                Wy = wyznaznik2x2(a1, c1, a2, c2),
                W = wyznaznik2x2(a1, b1, a2, b2);

            textBox7.Text = null;
            float x, y;

            if (W != 0)
            {
                x = Wx / W;
                y = Wy / W;
                textBox7.AppendText("Istneje jedno rozwiązanie" + Environment.NewLine);
                textBox7.AppendText("x = " + x.ToString("F2") + Environment.NewLine);
                textBox7.AppendText("y = " + y.ToString("F2"));
            }
            else
                if (Wx == 0 && Wy == 0)
                textBox7.AppendText("Układ nieoznaczony, nieskończony wiele rozwiązań");
            else
                textBox7.AppendText("Układ sprzeczny, brak rozwiązań");

        }
    }
}
