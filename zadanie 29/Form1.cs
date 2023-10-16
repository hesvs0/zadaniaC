using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zegar17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Random los = new Random();
            float i = los.Next(1, 100);
            i=i % 6 + 1;
            toolStripStatusLabel1.Text = "Wylosowano wartość: "+i.ToString();
            pictureBox1.Image = imageList1.Images[(int)(i - 1)];
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int interwal = Convert.ToInt16(textBox1.Text)*1000;
            timer1.Interval = interwal;
            timer1.Enabled = !timer1.Enabled;
            if (timer1.Enabled) button2.Text = "Zatrzymaj";
            else
            {
                button2.Text = "Losuj z zegara co:";
                pictureBox1.Image = null;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Random los = new Random();
            float i = los.Next(1, 100);
            i = i % 6 + 1;
            toolStripStatusLabel1.Text = "Wylosowano wartość: " + i.ToString();
            pictureBox1.Image = imageList1.Images[(int)(i-1)];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
