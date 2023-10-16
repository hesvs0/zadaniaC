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
    public partial class Form1 : Form
    {
        public Form2 form2;
        public Form3 form3;
        public Form4 form4;
        public Form1()
        {
            InitializeComponent();
        }

        private void ZamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Okno1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form2 == null)
            {
                form2 = new Form2();
                form2.MdiParent = this;
                form2.Tag = "okno1";
                form2.FormClosed += new FormClosedEventHandler(zwolnijUchwyt);
                form2.Show();
            }
            else form2.Activate();
        }
        public void RobOkno(Form f, string tag)
        {
            f.MdiParent = this;
            f.Tag = tag;
            f.FormClosed += new FormClosedEventHandler(zwolnijUchwyt);
            f.Show();
            f.Activate();
        }

        public void zwolnijUchwyt(object sender, FormClosedEventArgs e)
        {
            Form f =sender as Form;
            switch (f.Tag.ToString())
            {
                case "okno1": form2 = null; break;
                case "okno2": form3 = null; break;
                case "okno3": form4 = null; break;
            }
        }

        private void Okno2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form3 == null) RobOkno(form3 = new Form3(), "okno2");
            else form3.Activate();
        }

        private void Okno3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form4 == null) RobOkno(form4 = new Form4(), "okno3");
            else form4.Activate();
        }
        void RobOknoInstancji(Form f,string tag)
        {
            if(f==null)return;
            f.MdiParent = this;
            f.Tag = tag;
            f.Show();
            f.Activate();
        }

        private void OknoInstancja1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RobOknoInstancji(Form5.Instancja, "OknoInstancj1");
            Form5.Instancja.Text = "Okno Instancji 1";
        }

        private void OknoInstancja2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RobOknoInstancji(Form6.Instancja, "OknoInstancj2");
            Form6.Instancja.Text = "Okno Instancji 2";
            Form6.Instancja.Width = this.Width / 2;
            Form6.Instancja.Height = this.Height / 2;
        }

        private void OknoInstancja3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RobOknoInstancji(Form7.Instancja, "OknoInstancj3");
            Form7.Instancja.Text = "Okno Instancji 3";
            Form7.Instancja.Width = this.Width / 2;
            Form7.Instancja.Height = this.Height / 2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripButton1.Image = imageList1.Images[0];
        }

        public void zamknijNaTag(string tag)
        {
            switch (tag)
            {
                case "okno1": form2.Close(); break;
                case "okno2": form3.Close(); break;
                case "okno3": form4.Close(); break;
                case "OknoInstancj1": Form5.Instancja.Close();break;
            }
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripButton1.Checked = !toolStripButton1.Checked;
            if (toolStripButton1.Checked)
            {
                toolStripButton1.Image = imageList1.Images[1];
                if (form2 == null) RobOkno(form2 = new Form2(), "okno2");
                else form2.Activate();
            }
            else
            {
                toolStripButton1.Image = imageList1.Images[0];
                if (form2 != null) { form2.Close(); form2 = null; }
            }
            
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            toolStripButton2.Checked = !toolStripButton2.Checked;
            if (toolStripButton2.Checked)
            {
                toolStripButton2.Image = imageList1.Images[3];
            }
            else
            {
                toolStripButton2.Image = imageList1.Images[2];
            }
        }
    }
}
