﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Przesylanie_komunikatu_zwrotnego
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "x: " + this.Left.ToString() + "; y:" + this.Top.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox1.Text + System.Environment.NewLine
                + " x: " + this.Left.ToString() + " y: "
                + this.Top.ToString(), "Komunikat",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}