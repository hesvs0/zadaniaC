using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kolorDialog18
{
    public partial class Form1 : Form
    {
        int a, r, g, b;
        Color kolor = new Color();

        void Uaktualnij()
        {
            kolor = Color.FromArgb(a, r, g, b);
            pictureBox1.BackColor = kolor;
            trackBar1.Value = a;
            groupBox2.Text = "Kanał alfa: " + trackBar1.Value.ToString();
            trackBar2.Value = r;
            groupBox3.Text = "Składowa czerwona: " + trackBar2.Value.ToString();
            trackBar3.Value = g;
            groupBox4.Text = "Składowa zielona: " + trackBar3.Value.ToString();
            trackBar4.Value = b;
            groupBox5.Text = "Składowa niebieska: " + trackBar4.Value.ToString();
            toolStripStatusLabel1.Text = "Kanał alfa= " + a.ToString() +
                                ", czerwony= " + r.ToString() +
                                ", zielony= " + g.ToString() +
                                ", niebieski= " + b.ToString();
            panel3.BackColor = Color.FromArgb(255, r, 0, 0);
            panel4.BackColor = Color.FromArgb(255, 0, g, 0);
            panel5.BackColor = Color.FromArgb(255, 0, 0, b);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            a = 255;
            r = 128;
            g = 128;
            b = 128;
            Uaktualnij();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            Uaktualnij();
        }

        private void TrackBar2_Scroll(object sender, EventArgs e)
        {
            r = trackBar2.Value;
            Uaktualnij();
        }

        private void TrackBar3_Scroll(object sender, EventArgs e)
        {
            g = trackBar3.Value;
            Uaktualnij();
        }

        private void TrackBar4_Scroll(object sender, EventArgs e)
        {
            b = trackBar4.Value;
            Uaktualnij();
        }

        private void Panel6_Click(object sender, EventArgs e)
        {
            Uaktualnij();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult wynik = colorDialog1.ShowDialog();
            if (wynik == DialogResult.OK)
            {
                kolor = colorDialog1.Color;
                a = kolor.A;
                r = kolor.R;
                g = kolor.G;
                b = kolor.B;
                Uaktualnij();
            };
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
         
            Color k = panel2.BackColor;
            groupBox2.Text = "Kanał alfa: "+trackBar1.Value.ToString();
            a = trackBar1.Value;
            k = Color.FromArgb(a, k.R, k.G, k.B);
            panel2.BackColor = k;
            Uaktualnij();
        }

        
        public Form1()
        {
            InitializeComponent();
        }
    }
}
