using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pasekPostepu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 100){
                timer1.Stop();
                return;
            }
            progressBar1.Increment(1);
            label1.Text = (progressBar1.Value*0.01f).ToString("P0");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            progressBar1.Value = 0;
            label1.Text = (progressBar1.Value * 0.01f).ToString("P0");
        }
    }
}
