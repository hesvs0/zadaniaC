using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

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

        int x;
        int n = 0;
        int a;
        
        List<int> wsp = new List<int>();

        List<Kubelek> lista = new List<Kubelek>();

        List<String> lista1 = new List<String>();

        Stack stos = new Stack();

        const int _f = 1000, _t = 200;
        String[,] alfabet = new String[60, 2]
                  {
                   {"A",".-"},{"B","-..."},{"C","-.-."},{"D","-.."},{"E","."},
                   {"F","..-."},{"G","--."},{"H","...."},{"I",".."},{"J",".---"},
                   {"K","-.-"},{"L",".-.."},{"M","--"},{"N","-."},{"O","---"},
                   {"P",".--."},{"Q","--.-"},{"R",".-."},{"S","..."},{"T","-"},
                   {"U","..-"},{"V","...-"},{"W",".--"},{"X","-..-"},{"Y","-.--"},
                   {"Z","--.."},{"Ą",".-.-"},{"Ć",".-..."},{"Ę","..-.."},{"Ł",".-..-"},
                   {"Ń","--.--"},{"Ó","---."},{"Ś","...-..."},{"Ź","--..-."},{"Ż","--..-"},
                   {"1",".----"},{"2","..---"},{"3","...--"},{"4","....-"},{"5","....."},
                   {"6","-...."},{"7","--..."},{"8","---.."},{"9","----."},{"0","-----"},
                   {".",".-.-.-"},{",","--..--"},{"'",".----."},{"\"",".-..-."},{"+","..--.-"},
                   {":","---..."},{";","-.-.-."},{"?","..--.."},{"!","-.-.--"},{"-","-....-"},
                   {"+",".-.-."},{"/","-..-."},{"(","-.--."},{")","-.--.-"},{"=","-...-"}
                  };


        float f(float x)
        {
            
            return Math.Abs(x * x - 36);
            
        }


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


        float pierwiastek(float n, float dokladnosc)
        {
            float a = 1.0f,
            b = n;
            while((float)Math.Abs(a-b) >= dokladnosc)
            {
                a = (a + b) / 2;
                b = n / a;
            }
            return (float)(a + b) / 2;
            
        }


        int wieIte(int x, List<int> w)
        {
            int y = w[0];
            for (int i = 1; i > w.Count; i++)
                y = y * x + w[i];
            return y;
        }

        int wieRek(int x, int i, List<int> w)
        {
            if (i > 0) { return wieRek(x, i - 1, w) * x + w[i]; }
            return w[0];
        }


       void wczytajWspolczynniki(List<int> w, TextBox tb, Label lb)
        {

            if (tb.Text.Length < 1) return;
            w.Clear();
            lb.Text = null;
            n = tb.Lines.Count() - 1;
            for (int i = 0; i < tb.Lines.Count(); i++)
            {
                String s = tb.Lines[i].ToString();
                if (Int32.TryParse(s, out int j))
                {
                    w.Add(j);
                    string plus = "+";
                    if (i == n) plus = " ";
                    lb.Text += w[w.Count - 1].ToString() + "x^" + (n - i).ToString() + plus;
                }
            }
        }



        long potIteracja(int a, int n)
        {
            long w = 1;
            while (n > 0)
            {
                if (n % 2 == 1) w = w * a;
                a = a * a;
                n = n / 2;
            }
            return w;
        }

        long potRekurencja(int a, int n)
        {
            if (n == 0) return 1;
            if (n % 2 == 1) return a * potRekurencja(a, n - 1);
            long w = potRekurencja(a, n / 2);
            return w;
        }


        float badanaFunkcja(float x)
        {
            return x * x - 2;
        }

        float mejscaZerowe(float a, float b, float dokladnosc)
        {
            float fa, fs,
                sr = 0;
            fa = badanaFunkcja(a);
            while (b - a > dokladnosc)
            {
                sr = (a + b) / 2;
                fs = badanaFunkcja(sr);
                if (fa * fs < 0)
                {
                    a = a - dokladnosc;
                    b = sr;
                }
                else
                {
                    a = sr;
                    b = b - dokladnosc;
                    fa = fs;
                }
            } return sr;
        }



        float mProstokatow(float a, float b, int n)
        {
            float dx = (b - a) / (float)n,
                  h = 0,
                  sr = a + (b - a) / (2.0f * n);
            for (int i = 0; i < n; i++)
            {
                h = h + f(sr);
                sr = sr + dx;
            }
            return h * dx;
        }

        float mTrapez(float a, float b, int n)
        {
            float dx = (b - a) / (float)n,
                  da = f(a),
                  db,
                  h = 0;
            for (int i = 1; i <= n; i++)
            {
                db = f(a + dx * i);
                h = h + (db + da);
                da = db;
            }
            return h * 0.5f * dx;
        }


        bool czyPalindrom(string slowo)
        {
            int L = 0, P = slowo.Length - 1;
            while (L < P)
            {
                if (slowo[L] != slowo[P]) return false;
                L++;
                P--;
            }
            return true;
        }

        bool czyAnagram(string slowo1, string slowo2)
        {
            if (slowo1.Length != slowo2.Length) return false;
            int[] tabSum = new int[256];
            for (int i = 0; i < 256; i++) tabSum[i] = 0;
            for (int i = 0; i < slowo1.Length; i++) tabSum[slowo1[i]]++;
            for (int i = 0; i < slowo2.Length; i++) tabSum[slowo2[i]]--;
            for (int i = 0; i < 256; i++)
                if (tabSum[i] != 0) return false;
            return true;
        }

        void wczytajDane_i_Sortuj_A_Z(List<String> lis, TextBox tb)
        {
            lis.Clear();
            for (int i = 0; i < tb.Lines.Count(); i++)
                lis.Add(tb.Lines[i]);
            CultureInfo polska = new CultureInfo("pl-PL");
            StringComparer kraj = StringComparer.Create(polska, true);
            lis.Sort(kraj);
        }

        void wczytajDane_i_Sortuj_Z_A(List<String> lis, TextBox tb)
        {
            lis.Clear();
            for (int i = 0; i < tb.Lines.Count(); i++)
                lis.Add(tb.Lines[i]);
            CultureInfo polska = new CultureInfo("pl-PL");
            StringComparer kraj = StringComparer.Create(polska, true);
            lis.Sort(kraj);
            lis.Reverse();
        }


        void szukajWzorca(String tZrodlo, String tWzorzec, TextBox txtWynik)
        {
            txtWynik.Text = "";
            int dt = tZrodlo.Length;
            int dw = tWzorzec.Length;
            int licznik = 0;
            for (int i = 0; i < dt; i++)
            {
                int j = 0;
                while (j < dw && tZrodlo[i + j] == tWzorzec[j]) j++;
                if (j == dw)
                {
                    licznik++;
                    txtWynik.AppendText("wzorzec wystąpił po raz: "
                                        + licznik.ToString()
                                        + " pozycja znaku: "
                                        + i.ToString()
                                        + Environment.NewLine);
                }
            }
        }


        bool cyfra(char z)
        {
            return z >= '0' && z <= '9';
        }

        bool dzialanie(char z)
        {

            return z == '+' ||
                   z == '-' ||
                   z == '*' ||
                   z == '/';
        }

        float oblicz(float a, float b, char z)
        {
            switch (z)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '*': return a * b;
                case '/': return a / b;
            }
            return 0;
        }


        float dajLiczbe(string lancuch, int id)
        {
            int liczba = 0;
            while (id < lancuch.Length && cyfra(lancuch[id]) && lancuch[id] != ' ')
            {
                liczba = liczba * 10 + lancuch[id] - '0';
                ++id;
            }
            return liczba;
        }

        void znakDzwiek(String tekst, int f, int t)
        {
            for (int i = 0; i < tekst.Length; i++)
            {
                switch (tekst[i])
                {
                    case '.': Console.Beep(f, t); break;
                    case '-': Console.Beep(f, 3 * t); break;
                }
            }
            Thread.Sleep(t);
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

        private void button29_Click(object sender, EventArgs e)
        {
            if (textBox35.Text.Length < 1 || textBox36.Text.Length < 1) return;

            float n = float.Parse(textBox35.Text),
                dokladnosc = float.Parse(textBox36.Text);
            MessageBox.Show(pierwiastek(n, dokladnosc).ToString(), "Wynik pierwiastkowania", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox35_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',') { e.KeyChar = ','; return; }
            if (e.KeyChar == 8) return;

            if (e.KeyChar < '0' || e.KeyChar > '9' || e.KeyChar == '-')
                e.Handled = true;
        }

        private void textBox37_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 13 || e.KeyChar == '-') return;
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;
        }

        private void textBox37_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 8 || e.KeyValue == 13 || e.KeyValue == '-') return;
            wczytajWspolczynniki(wsp, textBox37, label30);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (textBox38.Text.Length < 1) return;
            x = int.Parse(textBox38.Text);
            MessageBox.Show(
            wieIte(x, wsp).ToString(),
            "Wartość wielomianu",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
            );
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (textBox38.Text.Length < 1) return;
            x = int.Parse(textBox38.Text);
            MessageBox.Show(
            wieRek(x, wsp.Count - 1, wsp).ToString(),
            "Wartość wielomianu",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }

        private void textBox39_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (textBox39.Text.Length < 1 || textBox40.Text.Length < 1) return;
            a = Int32.Parse(textBox39.Text);
            n = Int32.Parse(textBox40.Text);
            MessageBox.Show(a.ToString() + "^" + n.ToString() + " = " + potIteracja(a, n).ToString(),
                "Wynik potęgowania", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (textBox39.Text.Length < 1 || textBox40.Text.Length < 1) return;
            a = Int32.Parse(textBox39.Text);
            n = Int32.Parse(textBox40.Text);
            MessageBox.Show(a.ToString() + "^" + n.ToString() + " = " + potRekurencja(a,n),
                "Wynik potęgowania", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox41_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 13 || e.KeyChar == '-') return;
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (textBox41.Text.Length < 1 || textBox42.Text.Length < 1 || textBox43.Text.Length < 1) return;
            float a = float.Parse(textBox41.Text),
                b = float.Parse(textBox42.Text),
                d = float.Parse(textBox43.Text),
                sAB = (a + b) / 2;

            float x1 = mejscaZerowe(a, sAB, d);
            float x2 = mejscaZerowe(sAB, b, d);
            int n = textBox43.Text.Length - 2;
            MessageBox.Show("x1=" + x1.ToString("F" + n.ToString()) + ", x2=" + x2.ToString("F" + n.ToString()), "Szukane " +
                "miejsca zerowe", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (textBox44.Text.Length < 1
                || textBox45.Text.Length < 1
                || textBox46.Text.Length < 1) return;
            float a = float.Parse(textBox44.Text),
                  b = float.Parse(textBox45.Text);
            int n = int.Parse(textBox46.Text);
            MessageBox.Show(
                        mProstokatow(a, b, n).ToString(),
                        "Wartość pola (met. prostokątów):",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
        }

        private void textBox44_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 13 || e.KeyChar == '-') return;
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;
        }

        private void textBox46_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (textBox44.Text.Length < 1
                            || textBox45.Text.Length < 1
                            || textBox46.Text.Length < 1) return;
            float a = float.Parse(textBox44.Text),
                  b = float.Parse(textBox45.Text);
            int n = int.Parse(textBox46.Text);
            MessageBox.Show(
                            mTrapez(a, b, n).ToString(),
                            "Wartośc pola (met. trapezow):",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                            );
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (textBox47.Text.Length < 1) return;
            if (czyPalindrom(textBox47.Text))
                MessageBox.Show(
                    "Podane słowo jest palindromem",
                    "Czy palindrom?",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            else MessageBox.Show(
                    "Podane słowo nie jest palindromem",
                    "Czy palindrom?",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
        }

        private void button38_Click(object sender, EventArgs e)
        {
            if (textBox47.Text.Length < 1 || textBox48.Text.Length < 1) return;
            if (czyAnagram(textBox47.Text, textBox48.Text))
                MessageBox.Show(
                    "Podane słowa są anagramami",
                    "Czy anagram?",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            else MessageBox.Show(
                    "Podane słowo nie są anagramami",
                    "Czy anagram?",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
        }

        private void button39_Click(object sender, EventArgs e)
        {
            wczytajDane_i_Sortuj_A_Z(lista1, textBox49);
            textBox50.Clear();
            //wypisz posortowane dane
            foreach (String slowo in lista1)
                textBox50.AppendText(slowo + Environment.NewLine);
        }

        private void button40_Click(object sender, EventArgs e)
        {
            wczytajDane_i_Sortuj_Z_A(lista1, textBox49);
            textBox50.Clear();
            //wypisz posortowane dane
            foreach (String slowo in lista1)
                textBox50.AppendText(slowo + Environment.NewLine);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            szukajWzorca(textBox51.Text, textBox52.Text, textBox53);
        }

        private void button42_Click(object sender, EventArgs e)
        {
            string onp = textBox54.Text;
            stos.Clear();
            for (int i = 0; i < onp.Length; i++)
            {
                if (cyfra(onp[i]))
                {
                    float liczba = dajLiczbe(onp, i);
                    stos.Push(liczba);
                    i += liczba.ToString().Length;
                }
                else
                    if (dzialanie(onp[i]))
                {
                    if (stos.Count < 2)
                    {
                        MessageBox.Show("To nie jest wyrażenie ONP",
                                        "Komunikat",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }
                    float b = (float)stos.Peek();
                    stos.Pop();
                    float a = (float)stos.Peek();
                    stos.Pop();
                    stos.Push(oblicz(a, b, onp[i]));
                }

            }
            MessageBox.Show(((float)stos.Peek()).ToString(),
                            "Wynik",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void button44_Click(object sender, EventArgs e)
        {
            textBox56.Clear();
            for (int i = 0; i < textBox55.Text.Length; i++)
            {
                String kodMorsea = "";
                for (int j = 0; j < 60; j++)
                {
                    if (textBox55.Text.Substring(i, 1).ToUpper() == alfabet[j, 0])
                    {
                        kodMorsea = alfabet[j, 1];
                        //pokaz zakodowany znak
                        textBox56.AppendText(kodMorsea + " ");
                        //daj dzwiek
                        znakDzwiek(kodMorsea, _f, _t);
                        break;
                    }
                    else
                        if (textBox55.Text.Substring(i, 1).ToUpper() == " ")
                    {
                        //wpisz znak separatora końca słowa
                        textBox56.AppendText("|");
                        Thread.Sleep(3 * _t);
                        break;
                    }
                }

            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            String znak = "";
            textBox57.Clear();
            for (int i = 0; i < textBox56.Text.Length; i++)
            {
                if (textBox56.Text.Substring(i, 1) != " "
                   && textBox56.Text.Substring(i, 1) != "|")
                    znak += textBox56.Text.Substring(i, 1);
                else for (int j = 0; j < 60; j++)
                        if (znak == alfabet[j, 1])
                        {
                            textBox57.AppendText(alfabet[j, 0]);
                            znak = "";
                            break;
                        }
                if (textBox56.Text.Substring(i, 1) == "|")
                    textBox57.AppendText(" ");
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            Console.Beep(1000, 200);
            Thread.Sleep(400);
            Console.Beep(1000, 600);
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
