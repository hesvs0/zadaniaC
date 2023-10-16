using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rekurencja
{
    public partial class Form1 : Form
    {
        long silnia_rekurencyjnie(int n)
        {
            if (n == 0)
                return 1;
            else
                return n * silnia_rekurencyjnie(n - 1);
        }

        long silnia_iteracyjnie(int n)
        {
            int i = 1;
            long s = 1;
            while (i <= n)
            {
                s = s * i;
                i++;
            }
            return s;
        }

        int suma_rekurencyjnie(int n)
        {
            if (n == 0) return 0;
            return n + suma_rekurencyjnie(n - 1);
        }

        int suma_iteracyjnie(int n)
        {
            int s = 0;
            if(n==0) return 0;
            for (int i = 1; i <= n; i++)
                s = s + i;
            return s;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            int n=Convert.ToInt16(textBox1.Text);
            MessageBox.Show("Silnia rekurencyjnie = "
                            + silnia_rekurencyjnie(n).ToString(),
                            "Komunikat",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                            ); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int n = Convert.ToInt16(textBox1.Text);
            MessageBox.Show("Silnia iteracyjnie = "
                            + silnia_iteracyjnie(n).ToString(),
                            "Komunikat",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                            );
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            int n = Convert.ToInt16(textBox1.Text);
            MessageBox.Show("Suma rekurencyjnie = "
                            + suma_rekurencyjnie(n).ToString(),
                            "Komunikat",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                            );
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt16(textBox1.Text);
            MessageBox.Show("Suma iteracyjnie = "
                            + suma_iteracyjnie(n).ToString(),
                            "Komunikat",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                            );
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
