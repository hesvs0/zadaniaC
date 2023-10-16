using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dialogZapisuOdczytuPliku16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ZamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ZapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Pliki tekstowe .txt|*.txt|Wszystkie pliki *.*|*.*";
            saveFileDialog1.Title = "Zapisz zawartość";
            saveFileDialog1.DefaultExt = "txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter plik = new StreamWriter(saveFileDialog1.FileName,false);
                plik.WriteLine(textBox1.Text);
                plik.Close();
                toolStripStatusLabel1.Text = saveFileDialog1.FileName;
            }
        }

        private void OtwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Pliki tekstowe .txt|*.txt|Wszystkie pliki *.*|*.*";
            openFileDialog1.Title = "Otwórz plik";
            openFileDialog1.DefaultExt = "txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = null;
                StreamReader plik = new StreamReader(openFileDialog1.FileName);
                string linia;
                while ((linia = plik.ReadLine()) != null)
                {
                    textBox1.AppendText(linia);
                }
                plik.Close();
                toolStripStatusLabel1.Text = openFileDialog1.FileName;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Pliki bmp .bmp|*.bmp|Pliki jpg .jpg|*.jpg| Pliki png .png|*.png| Pliki ikon .ico|*.ico";
            openFileDialog1.Title = "Otwórz plik obrazu";
            openFileDialog1.DefaultExt = "png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                toolStripStatusLabel1.Text = openFileDialog1.FileName;
            }
        }
    }
}
