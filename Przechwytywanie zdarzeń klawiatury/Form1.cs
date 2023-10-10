using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Przechwytywanie_zdarzeń_klawiatury
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            label1.Text = "Naciśnięto klawisz edycyjny: "
                + e.KeyChar + ". Pozycja znaku ASCII: "
                + Convert.ToInt16(e.KeyChar);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            label2.Text =  "Naciśnięto klawisz: "
                + e.KeyValue.ToString() + "Jego znaczenie: "
                + e.KeyCode.ToString();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            label3.Text = "Zwolniono klawisz: "
                + e.KeyValue.ToString()
                + " Jego znaczenie: "
                + e.KeyCode.ToString();

            if (e.KeyValue == 27)
            {
                DialogResult wynik = MessageBox.Show(
                    "Czy zamknąć aplikacje?",
                    "Komunikat",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (wynik == DialogResult.Yes)
                    this.Close();
                else return;
            }
        }
    }
}
