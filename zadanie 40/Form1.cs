using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _28tablicaDynamiczna
{
    public partial class Form1 : Form
    {
        static int rozmiar = 1;
        float[] t1 = new float[rozmiar],
                t2 = new float[rozmiar];
        float[,] tabWynikow;
        Random los = new Random();

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < t1.GetLength(0); i++)
            {
                t1.SetValue(los.Next(0, 100), i);
                t2.SetValue(los.Next(0, 100), i);
            }
        }
        void wypiszTablice(Array t, TextBox tb)
        {
            tb.Clear();
            for(int i=0;i<t.GetLength(0); i++)
               tb.AppendText((i + 1).ToString() + ") " + t.GetValue(i).ToString()+Environment.NewLine);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            wypiszTablice(t1, textBox1);
            wypiszTablice(t2, textBox2);
        }

        void Sortuj_AdoZ_i_Wypisz(ref float[] t,TextBox tb)
        {
            Array.Sort(t);
            wypiszTablice(t, tb);
        }
        void Sortuj_ZdoA_i_Wypisz(ref float[] t, TextBox tb)
        {
            Array.Sort(t);
            Array.Reverse(t);
            wypiszTablice(t, tb);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sortuj_AdoZ_i_Wypisz(ref t1, textBox1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Sortuj_ZdoA_i_Wypisz(ref t2, textBox2);
        }

        void Dodawanie(float[] tA,float[] tB,ref float[,] tWynik,TextBox tb) 
        {
            tb.Clear();
            int rozmiar = tA.GetLength(0);
            tWynik = new float[rozmiar, 3];
            for(int i = 0; i < rozmiar; i++)
            {
                tWynik[i,0] = tA[i];
                tWynik[i,1] = tB[i];
                tWynik[i,2] = tWynik[i,0] + tWynik[i,1];
                tb.AppendText((i + 1).ToString() + ")" + tabWynikow[i, 0].ToString() + "+" + tabWynikow[i, 1].ToString() + "=" + tabWynikow[i, 2].ToString() + Environment.NewLine);
            }
        }
        void Odejmowanie(float[] tA, float[] tB, ref float[,] tWynik, TextBox tb)
        {
            tb.Clear();
            int rozmiar = tA.GetLength(0);
            tWynik = new float[rozmiar, 3];
            for (int i = 0; i < rozmiar; i++)
            {
                tWynik[i, 0] = tA[i];
                tWynik[i, 1] = tB[i];
                tWynik[i, 2] = tWynik[i, 0] - tWynik[i, 1];
                tb.AppendText((i + 1).ToString() + ")" + tabWynikow[i, 0].ToString() + "-" + tabWynikow[i, 1].ToString() + "=" + tabWynikow[i, 2].ToString() + Environment.NewLine);
            }
        }
        void Mnozenie(float[] tA, float[] tB, ref float[,] tWynik, TextBox tb)
        {
            tb.Clear();
            int rozmiar = tA.GetLength(0);
            tWynik = new float[rozmiar, 3];
            for (int i = 0; i < rozmiar; i++)
            {
                tWynik[i, 0] = tA[i];
                tWynik[i, 1] = tB[i];
                tWynik[i, 2] = tWynik[i, 0] * tWynik[i, 1];
                tb.AppendText((i + 1).ToString() + ")" + tabWynikow[i, 0].ToString() + "*" + tabWynikow[i, 1].ToString() + "=" + tabWynikow[i, 2].ToString() + Environment.NewLine);
            }
        }
        void Dzielenie(float[] tA, float[] tB, ref float[,] tWynik, TextBox tb)
        {
            tb.Clear();
            int rozmiar = tA.GetLength(0);
            tWynik = new float[rozmiar, 3];
            for (int i = 0; i < rozmiar; i++)
            {
                tWynik[i, 0] = tA[i];
                tWynik[i, 1] = tB[i];
                if (tWynik[i, 1] != 0)
                {
                    tWynik[i, 2] = tWynik[i, 0] / tWynik[i, 1];
                    tb.AppendText((i + 1).ToString() + ")" + tabWynikow[i, 0].ToString() + "/" + tabWynikow[i, 1].ToString() + "=" + tabWynikow[i, 2].ToString() + Environment.NewLine);
                }
                else tb.AppendText("Dzielenie przez zero!" + Environment.NewLine);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            switch (bt.Tag)
            {
                case "+":Dodawanie(t1, t2,ref tabWynikow,textBox3); break;
                case "-": Odejmowanie(t1, t2, ref tabWynikow, textBox3); break;
                case "*": Mnozenie(t1, t2, ref tabWynikow, textBox3); break;
                case "/": Dzielenie(t1, t2, ref tabWynikow, textBox3); break;
            }
        }

        void zwiekszRozmiarTablicy(ref float[] t, int rozmiar)
        {
            int staryRozmiar = t.GetLength(0);
            Array.Resize(ref t, rozmiar);
            for (int i = staryRozmiar; i < rozmiar; i++)
                t.SetValue(los.Next(0, 100), i);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rozmiar = Convert.ToInt16(textBox4.Text);
            zwiekszRozmiarTablicy(ref t1,t1.GetLength(0) + rozmiar);
            wypiszTablice(t1, textBox1);
            zwiekszRozmiarTablicy(ref t2, t2.GetLength(0) + rozmiar);
            wypiszTablice(t2, textBox2);
        }
    }
}
