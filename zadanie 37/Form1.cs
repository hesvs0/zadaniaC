using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wartosci_losowe_w_tablicach
{
    public partial class Form1 : Form
    {
        int ileLosowan;
        const int rozmiar = 10;
        int[] tab = new int[rozmiar];
        int nrLosowania = 0;

        public Form1()
        {
            InitializeComponent();
            label4.Text = "Losowanie "+
                           nrLosowania + 
                           " z " + rozmiar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var los = new Random();
            int p = int.Parse(textBox2.Text);
            int q = int.Parse(textBox3.Text);
            ileLosowan = int.Parse(textBox4.Text);
            

            textBox1.Clear();
            textBox1.AppendText("liczby całkowite z przedziału <p,q>, p<=x<=q" + Environment.NewLine);
            for (int i = 0; i < ileLosowan; i++)
            {
                int x=p+los.Next()%(q- p+1);
                textBox1.AppendText(x+Environment.NewLine);
            }
            textBox1.AppendText("liczby całkowite z przedziału (p,q>, p<x<=q" + Environment.NewLine);
            for (int i = 0; i < ileLosowan; i++)
            {
                int x = los.Next(p, q)+1;
                textBox1.AppendText(x + Environment.NewLine);
            }
            textBox1.AppendText("liczby całkowite z przedziału <0,q>, 0<=x<=q" + Environment.NewLine);
            for (int i = 0; i < ileLosowan; i++)
            {
                int x = los.Next()%(q+1);
                textBox1.AppendText(x + Environment.NewLine);
            }
            textBox1.AppendText("liczby rzeczywiste z przedziału <p,q>, p<=x<=q" + Environment.NewLine);
            for (int i = 0; i < ileLosowan; i++)
            {
                double x =p+(double)los.Next()/Int32.MaxValue*(q -p);
                textBox1.AppendText(x + Environment.NewLine);
            }
            textBox1.AppendText("liczby rzeczywiste z przedziału <0,1>, 0<=x<=1" + Environment.NewLine);
            for (int i = 0; i < ileLosowan; i++)
            {
                double x = (double)los.Next() / Int32.MaxValue;
                textBox1.AppendText(x + Environment.NewLine);
            }
            textBox1.AppendText("liczby rzeczywiste z przedziału <0,q>, 0<=x<=q" + Environment.NewLine);
            for (int i = 0; i < ileLosowan; i++)
            {
                double x = (double)los.Next() / Int32.MaxValue*q;
                textBox1.AppendText(x + Environment.NewLine);
            }
        }

        bool bylaWylosowana(int liczba, int[] t, int granica)
        {
            for (int i = 0; i < granica; i++)
                if (t[i] == liczba)
                    return true;
            return false;
        }

        void LosujDoTablicy()
        {
            textBox1.Clear();
            var los = new Random();
            int p = int.Parse(textBox2.Text);
            int q = p+rozmiar-1;
            int licznikLosowan = 0;
            while (licznikLosowan < rozmiar)
            {
                int x = p + los.Next() % (q - p + 1);
                if (!bylaWylosowana(x, tab, licznikLosowan))
                {
                    tab[licznikLosowan] = x;
                    textBox1.AppendText(tab[licznikLosowan] + Environment.NewLine);
                    licznikLosowan++;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LosujDoTablicy();
            button3.Enabled = true;
            nrLosowania = 0;
            label4.Text = "Losowanie " +
                           nrLosowania +
                           " z " + rozmiar;
        }

        void LosujElementTablicyBezPowtorzen(int[] t)
        {
            var los = new Random();
            int id = los.Next(0, rozmiar - nrLosowania);
            textBox1.AppendText("wylosowano :" + t[id] + Environment.NewLine);
            int bufor = t[id];
            t[id] = t[rozmiar - 1 - nrLosowania];
            t[rozmiar - 1 - nrLosowania] = bufor;
            nrLosowania++;
            label4.Text = "Losowanie " +
                           nrLosowania +
                           " z " + rozmiar +
                           Environment.NewLine;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (nrLosowania == rozmiar) return;
            textBox1.AppendText("Tablica przed losowaniem :" +
                           Environment.NewLine);
            for (int i = 0; i < tab.Length; i++)
                textBox1.AppendText(tab[i] + "; ");
            LosujElementTablicyBezPowtorzen(tab);
            textBox1.AppendText("Tablica po losowaniu :" +
                           Environment.NewLine);
            for (int i = 0; i < tab.Length; i++)
                textBox1.AppendText(tab[i] + "; ");
            textBox1.AppendText(Environment.NewLine);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
