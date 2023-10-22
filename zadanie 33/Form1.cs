using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23pozycjaZnakuWLancuchu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        char pokazZnak_z_Pozycji(string tekst,int id)
        {
            char z =(char)0;
            z = tekst[id];
            return z;
        }

        string zmienZnak(string zrodlo,char znak,int poz)
        {
            string sNowy = "";
            for (int i = 0; i < zrodlo.Length; i++)
            {
                char z = zrodlo[i];
                if (i == poz) z = znak;
                sNowy += z.ToString();
            }
            return sNowy;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt16(textBox2.Text);
            label3.Text = pokazZnak_z_Pozycji(textBox1.Text, i).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int poz = Convert.ToInt16(textBox2.Text);
            label3.Text = zmienZnak(textBox1.Text, textBox3.Text[0],poz);
        }
    }
}
