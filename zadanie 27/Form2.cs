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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form1 f = (Form1)this.MdiParent;
            if (f.form3 == null) {
                f.form3 = new Form3();
                f.RobOkno(f.form3, "okno2");
            }
            else f.form3.Activate();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form1 f = (Form1)this.MdiParent;
            if (f.form4 == null)f.RobOkno(f.form4 = new Form4(), "okno3");
            else f.form4.Activate();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
