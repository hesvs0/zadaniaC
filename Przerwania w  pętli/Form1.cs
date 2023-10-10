using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Przerwania_w__pętli
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random los = new Random();
            int zakres = Convert.ToInt16(textBox1.Text);
            int n = Convert.ToInt16(textBox2.Text);
            textBox3.Text = null;
            for (int j = 0; j < n; j++) 
            {
                int i = los.Next(zakres);
                textBox3.AppendText(i.ToString() + Environment.NewLine);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = null;
            int suma = 0;
            for (int j = 0; j < textBox3.Lines.Count() - 1; j++) 
            {
                int i = Convert.ToInt16(textBox3.Lines[j].ToString());
                if (i % 3 != 0) continue;
                textBox4.AppendText(suma.ToString() + "+" + i.ToString());
                suma += i;
                textBox4.AppendText(" = " + suma.ToString() + Environment.NewLine);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random los = new Random();
            int zakres = Convert.ToInt16(textBox5.Text);
            int n = Convert.ToInt16(textBox6.Text);
            textBox8.Text = null;
            for (int j = 0; j < n; j++)
            {
                int i = los.Next(zakres);
                textBox8.AppendText(i.ToString()+  Environment.NewLine);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int granica = Convert.ToInt16(textBox7.Text);
            textBox9.Text = null;
            int suma = 0;
            for (int j = 0; j < textBox8.Lines.Count() - 1; j++) 
            {
                int i = Convert.ToInt16(textBox8.Lines[j].ToString());
                textBox9.AppendText(suma.ToString() + "+" + i.ToString());
                suma += i;
                textBox9.AppendText(" = " + suma.ToString() + Environment.NewLine);
                if (suma >= granica) break;
            }
        }
    }
}
