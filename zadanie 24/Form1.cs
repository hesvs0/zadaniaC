using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21b_menuMyszki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show();
            }
        }

        private void element3ToolStripMenuItem_Click(object sender, 
                                                     EventArgs e)
        {
            Close();
        }

        private void element1ToolStripMenuItem_Click(object sender, 
                                                     EventArgs e)
        {
 
            Random los = new Random();
            byte skladowaCzerwona = (byte)los.Next(256);
            byte skladowaZielona = (byte)los.Next(256);
            byte skladowaNiebieska = (byte)los.Next(256);
            this.BackColor=Color.FromArgb(skladowaCzerwona,
                                          skladowaZielona,
                                          skladowaNiebieska);    
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
