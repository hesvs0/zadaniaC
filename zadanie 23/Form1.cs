using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mejMenu
{
    public enum DZIALANIE {BRAK,DODAWANIE,ODEJMOWANIE,MNOZENIE,DZIELENIE,CZYSC};
    public partial class Form1 : Form
    {
        private DZIALANIE dzialane = DZIALANIE.BRAK;
        float a=0, b=0, wynik=0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            switch (dzialane)
            {
                case DZIALANIE.DODAWANIE: wynik = a + b;break;
                case DZIALANIE.ODEJMOWANIE: wynik = a - b; break;
                case DZIALANIE.MNOZENIE: wynik = a * b; break;
                case DZIALANIE.DZIELENIE: wynik = a/b; break;
                case DZIALANIE.CZYSC: textBox1.Text = null; textBox2.Text = null; a = 0; b = 0;wynik = 0; break;
                default: return;
            }
            label3.Text = wynik.ToString();
        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text.Length > 0)
            {
                if (tb.Tag.ToString() == "podaj-a") a = (float)Convert.ToDouble(tb.Text);
                if (tb.Tag.ToString() == "podaj-b") b = (float)Convert.ToDouble(tb.Text);
                
            }
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ts = sender as ToolStripMenuItem;
            switch (ts.Tag)
            {
                case "+":dzialane = DZIALANIE.DODAWANIE;break;
                case "-": dzialane = DZIALANIE.ODEJMOWANIE; break;
                case "*": dzialane = DZIALANIE.MNOZENIE; break;
                case "/": dzialane = DZIALANIE.DZIELENIE; break;
                case "czysc": dzialane = DZIALANIE.CZYSC; break;
                default: dzialane = DZIALANIE.BRAK;break;
            }
            toolStripStatusLabel1.Text = "Wybrano działanie " + ts.Tag;
            button1.Text = "Wykonaj " + ts.Tag;
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == ',') return;
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;
            if (e.KeyChar == '.') e.KeyChar = ',';
        }
    }
}
