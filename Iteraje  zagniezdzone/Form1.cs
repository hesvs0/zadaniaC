using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iteraje__zagniezdzone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            for (int i = 1; i <= 10; i++) 
            {
                textBox1.AppendText("Tabliczka mnożenia dla liczby "
                    + i.ToString() + Environment.NewLine);
                for (int j = 1; j <= 10; j++) 
                {
                    int w = i * j;
                    textBox1.AppendText(i.ToString() +
                        " x " + j.ToString() +
                        "=" + w.ToString()+
                        Environment.NewLine);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt16(textBox3.Text);
            int b = Convert.ToInt16(textBox4.Text);
            textBox2.Text = null;
            int i = 0;
            while (i < a) 
            {
                int j = 0;
                while (j < b)
                {
                    textBox2.AppendText("X");
                    j++;
                }
                textBox2.AppendText(Environment.NewLine);
                i++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int h = Convert.ToInt16(textBox6.Text),
                i = 0,
                j = 0,
                k = 1;
            textBox5.Text = null;
            do
            {
                do
                {
                    textBox5.AppendText("*");
                    j++;
                } while (j < k);
                textBox5.AppendText(Environment.NewLine);
                j = 0;
                k++;
                i++;
            } while (i < h);
           


        }

        private void button4_Click(object sender, EventArgs e)
        {
            int h = Convert.ToInt16(textBox7.Text);
            char znak = '\u2591',
                znakKoncaWiersza = '\u2591';
            textBox8.Text = null;
            for (int i = 0; i < h; i++) 
            {
                for (int j = 0; j < h; j++) 
                {
                    if (znak == '\u2588') znak = '\u2591';
                    else znak = '\u2588';
                    textBox8.AppendText(char.ToString(znak));
                }
                if (znakKoncaWiersza == '\u2588') znak = '\u2591';
                else znak = '\u2588';
                znakKoncaWiersza = znak;
                textBox8.AppendText(Environment.NewLine);

            }
        }
    }
}
