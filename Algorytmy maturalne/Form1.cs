using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorytmy_maturalne
{

    struct Kubelek
    {
        public List<Int32> t;
    }
    public partial class Form1 : Form
    {
        float[] nominal = { 500, 200, 100, 50, 20, 10, 5, 2, 1, 0.50f, 0.20f, 0.10f, 0.02f, 0.01f };

        Int32[] tab;
        Int32[] tab1,
         tabBufor;
        int rozmiar = 10;

        List<Kubelek> lista = new List<Kubelek>();
        public Form1()
        {
            InitializeComponent();
        }

        private String zamiana10naInnyIteracja(int l, byte p)
        {
            String wynik = "";
            while (l > 0)
            {
                if (l % p > 9)

                    switch (l % p)
                    {
                        case 10: wynik += "A"; break;
                        case 11: wynik += "B"; break;
                        case 12: wynik += "C"; break;
                        case 13: wynik += "D"; break;
                        case 14: wynik += "E"; break;
                    }
                else wynik = (l % p).ToString() + wynik;
                l = l / p;


            }
            return wynik;

        }

        private String zamiana10naInnyRekurencja(int l, byte p)
        {
            String wynik = "";
            if (l > 0)
            {
                wynik += zamiana10naInnyRekurencja(l / p, p);
                if (l % p > 9)
                    switch (l % p)
                    {
                        case 10: wynik += "A"; break;
                        case 11: wynik += "B"; break;
                        case 12: wynik += "C"; break;
                        case 13: wynik += "D"; break;
                        case 14: wynik += "E"; break;
                        case 15: wynik += "F"; break;
                    }
                else wynik += (l % p).ToString();
            }
            return wynik;
        }

        private byte Wartosc(Char znak)
        {
            byte a = 0;
            switch (znak)
            {
                case 'A': a = 10; break;
                case 'B': a = 11; break;
                case 'C': a = 12; break;
                case 'D': a = 13; break;
                case 'E': a = 14; break;
                case 'F': a = 15; break;
                default: a = Convert.ToByte(znak - '0'); break;
            }
            return a;
        }

        private long DowolnyNaDziesietny(String s, byte p)
        {
            long wynik = 0;
            int i = 0;
            while (i < s.Length - 1)
            {
                wynik = (wynik + Wartosc(s[i])) * p;
                i++;
            }
            wynik += Wartosc(s[i]);
            return wynik;
        }

        private bool czy_jest_pirwsza(int n)
        {
            int m = (int)Math.Floor(Math.Sqrt(n));
            for (int i = 2; i <= m; i++)
                if (n % i == 0) return false;
            return true;
        }

        private bool czy_jest_doskonala(long n)
        {
            long suma = 1,
                p = (long)Math.Floor(Math.Sqrt(n));
            for (long i = 2; i <= p; i++)
                if (n % i == 0)
                    suma += i + n / i;
            if (n == p * p) suma -= p;
            if (n == suma) return true;
            return false;
        }

        int iteracjaNWD(int a, int b)
        {
            int bufor;
            while (b != 0)
            {
                bufor = b;
                b = a % b;
                a = bufor;
            }
            return a;
        }
        int rekurencjaNWD(int a, int b)
        {
            if (b != 0) return rekurencjaNWD(b, a % b);
            return a;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1)
            {
                MessageBox.Show("Nie podano liczby!",
                    "Komunikat",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            int l = Convert.ToUInt16(textBox1.Text);
            byte p = Convert.ToByte(comboBox1.Text);
            if (l > 0) label3.Text = zamiana10naInnyRekurencja(l, p);
            else label3.Text = "0";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rozlozNaCzynnikiPierwsze(int n, TextBox tb)
        {
            int i = 2;
            while (n > 1)
            {
                while (n % i == 0)
                {
                    tb.AppendText(i.ToString() + Environment.NewLine);
                    n = n / i;
                }
                i++;
            }
        }

        void fibIteracja(int n, TextBox tb)
        {
            Int64 a = 0, b = 1;
            for (int i = 0; i < n; i++)
            {
                tb.AppendText(b.ToString() + Environment.NewLine);
                b += a;
                a = b - a;
            }
        }
        int fibRekurencja(int n)
        {
            if (n < 3) return 1;
            return fibRekurencja(n - 2) + fibRekurencja(n - 1);
        }


        void wydaj(float kwota, TextBox tb)
        {
            int i = 0;
            while (kwota > 0)
            {
                if (kwota >= nominal[i])
                {
                    int ileNominalow = (int)(kwota / nominal[i]);
                    kwota = (float)Math.Round(kwota - nominal[i] * ileNominalow, 2);
                    tb.AppendText(ileNominalow.ToString() + " x " + nominal[i] + "zł" + Environment.NewLine);
                }
                i++;
            }
        }


        void losujTabliceBezPowtorzen(Int32[] t, int zakres)
        {
            Random r = new Random();
            int L, P, los;
            bool fWylosowano;
            int i = 0;
            while (i <= t.Length - 1)
            {
                fWylosowano = false;
                los = r.Next(zakres) + 1;
                L = 0;
                P = t.Length - 1;
                while (L <= P)
                {
                    if (t[L] == los) { fWylosowano = true; break; }
                    if (t[L] == los) { fWylosowano = true; break; }
                    L++;
                    P--;
                }
                if (!fWylosowano)
                {
                    t[i] = los;
                    i++;
                }
            }
        }

        void naiwnyMax(Int32[] t)
        {
            Int32 poz = 0, max = t[poz];
            for (Int32 i = 1; i < t.Length; i++)
                if (t[i] > max)
                {
                    max = t[i];
                    poz = i + 1;
                }
            MessageBox.Show("Wartosc max = " + max.ToString()
                + ", jest na poz. " + poz.ToString(), "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void optymalnyMinMax(Int32[] t)
        {
            Int32 max, min;
            if (t.Length % 2 == 1)
            {
                int staryRozmiar = t.GetLength(0);
                Array.Resize(ref t, staryRozmiar + 1);
                t[staryRozmiar] = t[staryRozmiar - 1];
            }
            if (t[0] > t[1]) { max = t[0]; min = t[1]; }
            else { max = t[1]; min = t[0]; }
            for (int i = 2; i < t.Length - 2; i += 2)
            {
                if (t[i] > t[i + 1])
                {
                    if (t[i] > max) max = t[i];
                    if (t[i + 1] < min) min = t[i + 1];
                }
                else
                {
                    if (t[i] < min) min = t[i];
                    if (t[i + 1] > max) max = t[i + 1];
                }
            }
            MessageBox.Show("Min = " + min.ToString() + ", Max = " + max.ToString(), "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        void losujTablice(Int32[] t, int zakres)
        {
            Random r = new Random();
            int i = 0;
            while (i < t.Length)
            {
                t[i] = r.Next(zakres) + 1;
                i++;
            }
        }

        void losujTablice2(Int32[] t, int zakres)
        {
            Random r = new Random();
            int i = 0;
            while (i < t.Length)
            {
                t[i] = r.Next(zakres) + 1;
                i++;
            }
        }

        void sortujBabelkowo(Int32[] t, int rozmiar)
        {
            for (int i = rozmiar - 1; i > 0; i--)
                for (int j = 0; j < i; j++)
                    if (t[j] > t[j + 1])
                    {
                        int bufor = t[j];
                        t[j] = t[j + 1];
                        t[j + 1] = bufor;
                    }
        }

        void sortWybor(Int32[] t, int rozmiar)
        {
            int id;
            for (int i = 0; i < rozmiar; i++)
            {
                id = i;
                for (int j = i + 1; j < rozmiar; j++)
                    if (t[j] < t[id])
                        id = j;
                int bufor = t[i];
                t[i] = t[id];
                t[id] = bufor;
            }
        }

        void sortPrezWsawianieLiniowe(Int32[] t, int rozmiar)
        {
            int bufor, j;
            for (int i = 1; i < rozmiar; i++)
            {
                bufor = t[i];
                j = i - 1;
                while (j >= 0 && t[j] > bufor)
                {
                    t[j + 1] = t[j];
                    j--;
                }
                t[j + 1] = bufor;
            }
        }

        void sortScalanie(Int32[] t, Int32[] tB, int L, int P)
        {
            if (P <= L) return;
            int sr = (P + L) / 2;

            sortScalanie(t, tB, L, sr);
            sortScalanie(t, tB, sr + 1, P);

            int i, j;

            for (i = sr + 1; i > L; i--)
                tB[i - 1] = t[i - 1];
            for (j = sr; j < P; j++)
                tB[P + sr - j] = t[j + 1];
            for (int k = L; k <= P; k++)
                if (tB[j] < tB[i])
                    t[k] = tB[j--];
                else
                    t[k] = tB[i++];
        }


        void qSort_A_Z(Int32[] t, int L, int P)
        {
            Int32 bufor, sr, i, j;
            i = L;
            j = P;
            sr = t[(L + P) / 2];
            do
            {
                while (t[i] < sr) i++;
                while (sr < t[j]) j--;
                if (i <= j)
                {
                    bufor = t[i];
                    t[i] = t[j];
                    t[j] = bufor;
                    i++;
                    j--;
                }

            } while (i < j);
            if (L < j) qSort_A_Z(t, L, j);
            if (i < P) qSort_A_Z(t, i, P);
        }

        void qSort_Z_A(Int32[] t, int L, int P)
        {
            Int32 bufor, sr, i, j;
            i = L;
            j = P;
            sr = t[(L + P) / 2];
            do
            {
                while (t[i] > sr) i++;
                while (sr > t[j]) j--;
                if (i <= j)
                {
                    bufor = t[i];
                    t[i] = t[j];
                    t[j] = bufor;
                    i++;
                    j--;
                }
            }while (i < j);
            if (L < j) qSort_Z_A(t, L, j);
            if (i < P) qSort_Z_A(t, i, P);
        }

        void sortKubelkowe(Int32[] t, List<Kubelek> lis, int roz)
        {
            int z = 1000000000 / roz;

            for (int i = 0; i < roz; i++)
            {
                Kubelek k = new Kubelek();
                k.t = new List<Int32>();
                lis.Add(k);
            }
            for (int i = 0; i < roz; i++)
                lis[t[i] / z].t.Add(t[i]); 
            for (int i = 0; i < roz; i++)
                if (lis[i].t.Count > 1) lis[i].t.Sort();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;
            if (e.KeyChar < '0' || e.KeyChar > '9')e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1)
            {
                MessageBox.Show("Nie podano liczby!",
                    "Komunikat",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            int l = Convert.ToUInt16(textBox1.Text);
            byte p = Convert.ToByte(comboBox1.Text);
            if (l > 0) label3.Text = zamiana10naInnyIteracja(l, p);
            else label3.Text = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length < 1)
            {
                MessageBox.Show("Nie podano liczby!",
                    "Komunikat",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            byte p = Convert.ToByte(comboBox2.Text);
            label6.Text = DowolnyNaDziesietny(textBox2.Text, p).ToString();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length < 1) return;
            int liczba = Int32.Parse(textBox3.Text);
            if (czy_jest_pirwsza(liczba))
                MessageBox.Show("To jest liczba pierwsza",
                    "Komunikat",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show("To nie jest liczba pierwsza",
                    "Komunikat",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length < 1)
                textBox5.Clear();
            int i = 2, k= Int32.Parse(textBox4.Text);
            while (i < k)
            {
                if(czy_jest_pirwsza(i))
                    textBox5.AppendText(i.ToString()+ Environment.NewLine);
                i++;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Length < 1) return;
            long n = Int64.Parse(textBox6.Text);
            if (czy_jest_doskonala(n))
                MessageBox.Show("To jest liczba doskonala",
                    "Komunikat",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show("To nie jest liczba doskonala",
                    "Komunikat",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Length < 1) return;
            int n = Convert.ToInt32(textBox7.Text);
            textBox8.Clear();
            rozlozNaCzynnikiPierwsze(n, textBox8);

        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int a = Int16.Parse(textBox9.Text),
            b = Int16.Parse(textBox10.Text);
            label14.Text = "NWD = " + iteracjaNWD(a, b).ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int a = Int16.Parse(textBox9.Text),
            b = Int16.Parse(textBox10.Text);
            label14.Text = "NWD = " + rekurencjaNWD(a, b).ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox11.Text.Length < 1) return;
            textBox12.Clear();
            int n = int.Parse(textBox11.Text);
            fibIteracja(n, textBox12);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox11.Text.Length < 1) return;
            textBox12.Clear();
            int n = int.Parse(textBox11.Text);
            for (int i = 1; i <= n; i++)
                textBox12.AppendText(fibRekurencja(i).ToString() + Environment.NewLine);
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox13.Text.Length < 1) return;
            textBox14.Clear();
            float kwota = float.Parse(textBox13.Text);
            wydaj(kwota, textBox14);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox16.Text.Length < 1) return;
            if(tab != null) Array.Clear(tab,0, tab.Length);
            rozmiar = int.Parse(textBox16.Text);
            tab = new Int32[rozmiar];
            losujTabliceBezPowtorzen(tab, rozmiar * 2);
            textBox15.Clear();
            for ( int i = 0; i < tab.Length; i++ )
                textBox15.AppendText(tab[i].ToString() + Environment.NewLine);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (tab == null) return;
            naiwnyMax(tab);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            optymalnyMinMax(tab);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            sortujBabelkowo(tab, rozmiar);
            textBox19.Clear();
            for (int i = 0; i < tab.Length; i++)
                textBox19.AppendText(tab[i].ToString() + Environment.NewLine);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox17.Text.Length < 1) return;

            if(tab != null) Array.Clear(tab, 0, tab.Length);
            rozmiar = int.Parse(textBox17.Text);
            tab = new int[rozmiar];
            losujTablice(tab, 2 * rozmiar);
            textBox18.Clear();
            for (int i = 0; i < tab.Length; i++)
                textBox18.AppendText(tab[i].ToString() + Environment.NewLine);
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox20.Text.Length < 1) return;

            if (tab != null) Array.Clear(tab, 0 ,tab.Length);
            rozmiar = int.Parse(textBox20.Text);
            tab = new int[rozmiar];
            losujTablice2(tab, 2 * rozmiar);
            textBox21.Clear();
            for (int i = 0; i < tab.Length; i++)
                textBox21.AppendText(tab[i].ToString() + Environment.NewLine);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (tab == null) return;
            sortWybor(tab, rozmiar);
            textBox22.Clear();
            for (int i = 0; i < tab.Length; i++)
                textBox22.AppendText(tab[i].ToString() + Environment.NewLine);
        }

        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox23.Text.Length < 1) return;

            if (tab != null) Array.Clear(tab, 0, tab.Length);
            rozmiar = int.Parse(textBox23.Text);
            tab = new int[rozmiar];
            losujTablice(tab, 2 * rozmiar);
            textBox24.Clear();
            for (int i = 0; i < tab.Length; i++)
                textBox24.AppendText(tab[i].ToString() + Environment.NewLine);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (tab == null) return;
            sortPrezWsawianieLiniowe(tab, rozmiar);
            textBox25.Clear();
            for (int i = 0; i < tab.Length; i++)
                textBox25.AppendText(tab[i].ToString() + Environment.NewLine);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (textBox26.Text.Length < 1) return;

            if (tab1 != null) Array.Clear(tab1, 0, tab1.Length);
            if (tabBufor != null) Array.Clear(tabBufor, 0, tabBufor.Length);
            rozmiar = int.Parse(textBox26.Text);
            tab1 = new int[rozmiar];
            tabBufor = new int[rozmiar];
            losujTablice2(tab1, 2 * rozmiar);
            textBox27.Clear();
            for (int i = 0; i < tab1.Length; i++)
                textBox27.AppendText(tab1[i].ToString() + Environment.NewLine);
        }

        private void textBox26_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;
        }

        private void textBox29_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (textBox29.Text.Length < 1) return;

            if (tab != null) Array.Clear(tab, 0, tab.Length);
            rozmiar = int.Parse(textBox29.Text);
            tab = new int[rozmiar];
            losujTablice(tab, 2 * rozmiar);
            textBox30.Clear();
            for (int i = 0; i < tab.Length; i++)
                textBox30.AppendText(tab[i].ToString() + Environment.NewLine);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if(tab == null) return;
            qSort_A_Z(tab, 0, rozmiar - 1);
            textBox31.Clear();
                for (int i = 0;i < tab.Length;i++)
                textBox31.AppendText(tab[i].ToString() + Environment.NewLine);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (tab == null) return;
            qSort_Z_A(tab, 0, rozmiar - 1);
            textBox31.Clear();
                for (int i = 0; i < tab.Length; i++)
                textBox31.AppendText(tab[i].ToString() + Environment.NewLine);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (textBox32.Text.Length < 1) return;
            lista.Clear();

            if (tab != null) Array.Clear(tab, 0, tab.Length);
            rozmiar = int.Parse(textBox32.Text);
            tab = new int[rozmiar];
            losujTablice(tab, 2 * rozmiar);
            textBox33.Clear();
            for (int i = 0; i < tab.Length; i++)
                textBox33.AppendText(tab[i].ToString() + Environment.NewLine);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (tab == null) return;
            sortKubelkowe(tab, lista, rozmiar);
            textBox34.Clear();
            for (int i = 0; i < rozmiar; i++)
                for (int j = 0; j < lista[i].t.Count; j++)
                    textBox34.AppendText(lista[i].t[j].ToString() + Environment.NewLine);
        }

        private void textBox32_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (tab1 == null) return;
            sortScalanie(tab1, tabBufor, 0, rozmiar - 1);
            textBox28.Clear();
            for (int i = 0; i < tab1.Length; i++)
                textBox28.AppendText(tab1[i].ToString() + Environment.NewLine);
        }
    }
}
