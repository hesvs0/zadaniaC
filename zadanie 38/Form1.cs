using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _26tabliceStatyczne
{
    public partial class Form1 : Form
    {
        const int ROZMIAR= 10;
        Random los = new Random();
        int z = 0;
        int[] t1 = new int[ROZMIAR];
        int[] t2 = new int[ROZMIAR];

        int[] losoweElementyTablicy(int rozmiar, int zakres)
        {
            int[] tab = new int[rozmiar];
            for (int i = 0; i < rozmiar; i++)
            {
                tab[i] = los.Next(zakres) + 1;
            }
            return tab;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            z = Convert.ToInt16(textBox3.Text);
            t1 = losoweElementyTablicy(ROZMIAR, z);
            t2 = losoweElementyTablicy(ROZMIAR, z);
            textBox1.Clear();
            textBox2.Clear();
            for (int i = 0; i < ROZMIAR; i++)
            {
                textBox1.AppendText(i.ToString() + ": " + t1[i].ToString() + Environment.NewLine);
                textBox2.AppendText(i.ToString() + ": " + t2[i].ToString() + Environment.NewLine);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            int id = Convert.ToInt16(textBox5.Text);
            float wynik=0;
            Button bt= sender as Button;
            switch (bt.Tag)
            {
                case "+":wynik = t1[id] + t2[id];break;
                case "-":wynik = t1[id] - t2[id];break;
            }
            textBox4.AppendText(t1[id].ToString()+bt.Tag+t2[id].ToString()+"="+wynik.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            for (int id = 0; id < ROZMIAR; id++)
            {
                int wynik = t1[id] + t2[id];
                textBox4.AppendText(t1[id].ToString() + "+" + t2[id].ToString() + "=" + wynik.ToString() + Environment.NewLine);
            }
        }
    }
}
