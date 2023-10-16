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
    public partial class Form5 : Form
    {
        private static Form5 instancja;
        public static Form5 Instancja {
            get
            {
                if (instancja == null) instancja = new Form5();
                return instancja;
            }
        }
            

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            instancja = null;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form6.Instancja.MdiParent = this.MdiParent;
            Form6.Instancja.Text="Okno II otwarte z okna I";
            Form6.Instancja.Show();
            Form6.Instancja.Activate();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form7.Instancja.MdiParent = this.MdiParent;
            Form7.Instancja.Text = "Okno III otwarte z okna I";
            Form7.Instancja.Show();
            Form6.Instancja.Activate();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
