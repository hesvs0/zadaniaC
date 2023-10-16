using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wieleOkien
{
    public partial class Form6 : Form
    {
        
        private static Form6 instancja;
        public static Form6 Instancja
        {
            get
            {
                if (instancja == null) instancja = new Form6();
                return instancja;
            }
        }
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            instancja = null;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form7.Instancja.a = (float)Convert.ToDouble(textBox1.Text);
            Form7.Instancja.b = (float)Convert.ToDouble(textBox2.Text);
            Form7.Instancja.MdiParent = this.MdiParent;
            Form7.Instancja.Text = "Okno III otwarte z okna II";
            Form7.Instancja.Dodawanie();
            Form7.Instancja.Show();
            Form7.Instancja.Activate();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            float a = (float)Convert.ToDouble(textBox1.Text);
            float b = (float)Convert.ToDouble(textBox2.Text);
            Form7.Instancja.MdiParent = this.MdiParent;
            Form7.Instancja.Text = "Okno III otwarte z okna II";
            Form7.Instancja._label2.Text= a.ToString() + "*" + b.ToString() + "=" + (a * b).ToString();
            Form7.Instancja.Show();
            Form7.Instancja.Activate();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
