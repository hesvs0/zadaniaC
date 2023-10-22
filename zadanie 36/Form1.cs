using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tablicaJednowymiarowa_cz1
{
    public partial class Form1 : Form
    {
        int[] tabZad1 = new int[10] { 99, 3, 5, 18, 21, 45, 67, 34, 98, 41 };
        int[] tabZad2 = new int[100];
        Random los = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            
            for (int i = 0; i < 10;i++)
                textBox1.AppendText(
                         tabZad1[i].ToString() 
                         + Environment.NewLine);

            textBox1.AppendText(
                     "To samo ale z odczytem rozmiaru liczności tablicy"
                     + Environment.NewLine);
            for (int i = 0; i < tabZad1.Length; i++)
                textBox1.AppendText(
                         tabZad1[i].ToString()
                         + Environment.NewLine);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < tabZad2.Length; i++)
                tabZad2[i]=los.Next(500)+1;
            textBox1.Text = "";
            for (int i = 0; i < tabZad2.Length; i++)
                textBox1.AppendText(
                         tabZad2[i].ToString()
                         + Environment.NewLine);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
            int min = tabZad2[0],
                id =0;
            for (int i = 1; i < tabZad2.Length; i++)
            {
                if (tabZad2[i] < min)
                {
                    min = tabZad2[i];
                    id = i;
                }
            }
            MessageBox.Show(
                 "Minimum to: " + min.ToString() + Environment.NewLine
                 +"Indeks minimum " +id.ToString(),
                 "Komunikat",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
                 );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
            long suma = 0;
            for (int i = 1; i < tabZad2.Length; i++)
                suma += tabZad2[i];
            MessageBox.Show(
                 "Suma elemntów wynosi "+suma.ToString(),
                 "Komunikat",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
                 );
        }
    }
}
