using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _27tabliceWielowymiarowe
{
    public partial class Form1 : Form
    {
        int[,] t;
        int rozmiar = 0, zakres =100;
        Random los = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        void dodawanie(int[,] t,TextBox tb)
        {
            tb.Clear();
            for(int i = 0; i < t.GetLength(0); i++)
            {
                tb.AppendText((i + 1).ToString() + ") " + t[i, 0].ToString() + "+" + t[i, 1].ToString() +"="+(t[i,0]+t[i,1]).ToString()+ Environment.NewLine);
            }
        }

        void odejmowanie(int[,] t, TextBox tb)
        {
            tb.Clear();
            for (int i = 0; i < t.GetLength(0); i++)
            {
                tb.AppendText((i + 1).ToString() + ") " + t[i, 0].ToString() + "-" + t[i, 1].ToString() + "=" + (t[i, 0] - t[i, 1]).ToString() + Environment.NewLine);
            }
        }
        void mnozenie(int[,] t, TextBox tb)
        {
            tb.Clear();
            for (int i = 0; i < t.GetLength(0); i++)
            {
                tb.AppendText((i + 1).ToString() + ") " + t[i, 0].ToString() + "*" + t[i, 1].ToString() + "=" + (t[i, 0] * t[i, 1]).ToString() + Environment.NewLine);
            }
        }
        void dzielenie(int[,] t, TextBox tb)
        {
            tb.Clear();
            for (int i = 0; i < t.GetLength(0); i++)
            {
                if(t[i,1]!=0)
                tb.AppendText((i + 1).ToString() + ") " + t[i, 0].ToString() + "/" + t[i, 1].ToString() + "=" + ((float)t[i, 0]/(float)t[i, 1]).ToString() + Environment.NewLine);
                else
                tb.AppendText("dzielnie przez zero" + Environment.NewLine);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            switch (bt.Tag)
            {
                case "+": dodawanie(t, textBox3); break;
                case "-": odejmowanie(t, textBox3); break;
                case "*": mnozenie(t, textBox3); break;
                case "/": dzielenie(t, textBox3); break;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            rozmiar = Convert.ToInt16(textBox1.Text);
            zakres = Convert.ToInt16(textBox2.Text);
            textBox3.Clear();
            t = new int [rozmiar,2];
            for(int i = 0; i < rozmiar; i++)
            {
                t[i, 0] = los.Next(zakres);
                t[i, 1] = los.Next(zakres);
                textBox3.AppendText((i + 1).ToString() + ") " + t[i, 0].ToString() + ";" + t[i, 1].ToString()+Environment.NewLine);
            }
        }
    }
}
