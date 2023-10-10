using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iteracje.Pętla_for__do_while__while
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s;
            if (textBox1.Text == "") return;
            int n = Convert.ToInt16(textBox1.Text);
            textBox3.Clear();
            for (int i = 0; i < n; i++)
            {
                s = "Znak nr" + i.ToString() + " to " + (char)i;
                textBox3.AppendText(s + Environment.NewLine);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s;
            if (textBox2.Text == "") return;
            int n = Convert.ToInt16(textBox2.Text);
            if (n > 256) n = 256;
            textBox4.Clear();
            int i = 0;
            do
            {
                i++;
                s = i.ToString() + " x " + i.ToString() + "=" + (i * i).ToString();
                textBox4.AppendText(s + Environment.NewLine);
            } while (i < n);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s;
            if (textBox5.Text == "" || textBox6.Text == "" || textBox6.Text == "0") return;
            int n = Convert.ToInt16(textBox5.Text);
            if(n > 256) n= 256;
            int b = Convert.ToInt16(textBox6.Text);
            int c = 0, r = 0;
            int i = 1;
            textBox7.Clear();
            while (i <= n) 
            {
                c = i / b;
                r = i % b;
                s = i.ToString() + "/" + b.ToString() + "=" +  c.ToString() + "; "
                    + i.ToString() + "%" + b.ToString()+ "=" + r.ToString();
                textBox7.AppendText(s + Environment.NewLine);
                i++;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
