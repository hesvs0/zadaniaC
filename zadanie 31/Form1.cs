using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fontDialog19
{
    public partial class Form1 : Form
    {
        Font fontStary,
             fontNowy;
        bool fZmienNaStary = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fontStary = textBox1.Font;
            fontNowy = fontStary;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (fZmienNaStary)
            {
                button2.Text = "Zmień na nowy";
                textBox1.Font = fontStary;
            }
            else
            {
                button2.Text = "Zmień na stary";
                textBox1.Font = fontNowy;
            }
            textBox1.Focus();
            fZmienNaStary = !fZmienNaStary;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult wynik = fontDialog1.ShowDialog();
            if (wynik == DialogResult.OK)
            {
                fontNowy = fontDialog1.Font;
                textBox1.Font = fontNowy;
                textBox1.Focus();
                fZmienNaStary = !fZmienNaStary;
                button2.Text = "Zmień na stary";
            }
        }
    }
}
