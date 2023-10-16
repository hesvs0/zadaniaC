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
    public partial class Form7 : Form
    {
        public float a, b;
        private static Form7 instancja;
        public static Form7 Instancja
        {
            get{
                if (instancja == null) instancja = new Form7();
                return instancja;
            }
        }
        public Label _label2 => label2;
        public void Dodawanie()
        {
            label2.Text = a.ToString()+"+"+b.ToString()+"="+(a + b).ToString();
        }
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
            instancja = null;
        }
    }
}
