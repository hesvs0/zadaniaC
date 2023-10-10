using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reakcja_na_zawarte_przyciski_w_oknie_dialogowym
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult wynik = MessageBox.Show("Czy zakończyc aplikacje?", "Komunikat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (wynik == DialogResult.Yes) { this.Close(); }
            else 
            {
                this.Text = "Rezygnacja z zamknięcia";
                MessageBox.Show("Zrezygnowano z zamknięcia",
                    "Komunikat",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }
    }
}
