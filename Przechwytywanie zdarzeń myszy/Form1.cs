using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Przechwytywanie_zdarzeń_myszy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = "x: "
                +  e.X.ToString()
                +" y: " + e.Y.ToString();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel2.Text = "Wciśnięto klawisz myszy: "
                + e.Button.ToString()
                + " wsp. x: "
                + e.X.ToString()
                + " y: "
                + e.Y.ToString();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel2.Text = "Zwolniono klawisz myszy: "
                + e.Button.ToString()
                + " wsp. x: "
                + e.X.ToString()
                + "  y: "
                + e.Y.ToString();
        }

        private void statusStrip1_MouseHover(object sender, EventArgs e)
        {
            statusStrip1.BackColor = Color.FromArgb(0, 255, 0);
        }
    }
}
