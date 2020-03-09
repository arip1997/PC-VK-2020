using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgProc1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pbOutput_Click(object sender, EventArgs e)
        {

        }

        private void bukaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog bukaFile = new OpenFileDialog();
            bukaFile.Filter = "Image File (*.bmp, *.jpg, *.jpeg)|*.bmp;*.jpg;*.jpeg";
            if (DialogResult.OK == bukaFile.ShowDialog())
            {
                this.pbInput.Image = new Bitmap(bukaFile.FileName);
                toolStripStatusLabel1.Text = Path.GetFullPath(bukaFile.FileName);
                toolStripStatusLabel2.Text = "Lebar: " + pbInput.Width + " px. Tinggi:" + pbInput.Height + " px.";
            }
        }

        private void simpanSebagaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbOutput.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan disimpan");
            }
            else
            {
                SaveFileDialog simpanFile = new SaveFileDialog();
                simpanFile.Title = "Simpan File Citra";
                simpanFile.Filter = "Image File (*.bmp, *.jpg, *.jpeg)|*.bmp;*.jpg;*.jpeg";
                if (DialogResult.OK == simpanFile.ShowDialog())
                    this.pbOutput.Image.Save(simpanFile.FileName);
            }

        }

        private void keluarAplikasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Bitmap copy = new Bitmap((Bitmap)this.pbInput.Image);
            olahCitra.keBrightness(copy);
            this.pbOutput.Image = copy;*/

            if (pbInput.Image == null)
            {
                MessageBox.Show("Tidak ada citra yang diolah");
            }
            else
            {
                contrast frm2 = new contrast();
                if (frm2.ShowDialog() == DialogResult.OK)
                {
                    Bitmap b = new Bitmap((Bitmap)this.pbInput.Image);
                    int nilaiBrightness = Convert.ToInt16(frm2.tbBrightness.Text);
                    int nilaiContrast = Convert.ToInt16(frm2.tbContrast.Text);
                    ProgressBar1.Visible = true;
                    for (int i = 0; i < b.Width; i++)
                    {
                        for (int j = 0; j < b.Height; j++)
                        {
                            Color c1 = b.GetPixel(i, j);
                            int r1 = c1.R + nilaiBrightness;
                            int g1 = c1.G + nilaiBrightness;
                            int b1 = c1.B + nilaiBrightness;
                            int r2 = truncate(r1);
                            int g2 = truncate(g1);
                            int b2 = truncate(b1);
                            b.SetPixel(i, j, Color.FromArgb(r2, g2, b2));


                            Color d1 = b.GetPixel(i, j);
                            int x1 = (d1.R + 259 * (nilaiContrast + 255) / 255 * (259 - nilaiContrast)) * ((d1.R - 128) + 128);
                            int y1 = (d1.G + 259 * (nilaiContrast + 255) / 255 * (259 - nilaiContrast)) * ((d1.G - 128) + 128);
                            int z1 = (d1.B + 259 * (nilaiContrast + 255) / 255 * (259 - nilaiContrast)) * ((d1.B - 128) + 128);
                            int x2 = truncate(x1);
                            int y2 = truncate(y1);
                            int z2 = truncate(z1);
                            b.SetPixel(i, j, Color.FromArgb(x2, y2, z2));
                        }
                        ProgressBar1.Value = Convert.ToInt16(100 * (i + 1) / b.Width);
                    }
                    ProgressBar1.Visible = false;
                    this.pbOutput.Image = b;
                }
            }
        }

        private void rGBToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tentangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tentang t = new Tentang();
            t.Show();
            this.Hide();
        }

        private static int truncate(int x)
        {
            if (x > 255) x = 255;
            else if (x < 0) x = 0;
            return x;
        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
