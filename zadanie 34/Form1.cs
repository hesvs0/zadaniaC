using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24FormatCzasuZegarCyfrowy
{
    public partial class Form1 : Form
    {
        bool fDwukropek = false;
        public Form1()
        {
            InitializeComponent();
        }
        string czas()
        {
            return DateTime.Now.ToString("T");
        }
        void mrugajDwukropkiem()
        {
            if (fDwukropek) {
                pictureBox3.Image = imageList1.Images[10];
                pictureBox6.Image = imageList1.Images[10];
            }
            else
            {
                pictureBox3.Image = imageList1.Images[11];
                pictureBox6.Image = imageList1.Images[11];
            }
            fDwukropek = !fDwukropek;
        }

        void wstawCyfry()
        {
            int id=0;
            string t = czas();
            for(int i = 0; i < t.Length; i++)
            {
               
                if (t[i] != ':') id = Convert.ToInt16(t[i])-48;
                switch (i)
                {
                    case 0: pictureBox1.Image = imageList1.Images[id];break;
                    case 1: pictureBox2.Image = imageList1.Images[id]; break;
                    case 3: pictureBox4.Image = imageList1.Images[id]; break;
                    case 4: pictureBox5.Image = imageList1.Images[id]; break;
                    case 6: pictureBox7.Image = imageList1.Images[id]; break;
                    case 7: pictureBox8.Image = imageList1.Images[id]; break;
                }
            }
            mrugajDwukropkiem();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            toolStripStatusLabel1.Text = czas();
            wstawCyfry();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wstawCyfry();
        }
    }
}
