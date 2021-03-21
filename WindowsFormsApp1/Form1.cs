using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Bitmap image;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            image = new Bitmap(pictureBox1.Image);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {

            Color color = image.GetPixel(e.X, e.Y);

            textBox1.Text = color.R.ToString();
            textBox2.Text = color.G.ToString();
            textBox3.Text = color.B.ToString();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Color color = image.GetPixel(e.X, e.Y);

            textBox1.Text = color.R.ToString();
            textBox2.Text = color.G.ToString();
            textBox3.Text = color.B.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter= "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(dialog.FileName);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.ShowDialog();

                Bitmap OriginalImage = new Bitmap(dialog.FileName);

                Bitmap BlackAndWhiteImage = new Bitmap(OriginalImage.Width, OriginalImage.Height);
                pictureBox1.Image = BlackAndWhiteImage;

                Color c = Color.Black;
                Color v = Color.White;
                int av = 0;


                for (int i = 0; i < OriginalImage.Width; i++)
                {
                    for (int y = 0; y < OriginalImage.Height; y++)
                    {
                        c = OriginalImage.GetPixel(i, y);
                        av = ( int.Parse(c.R.ToString()) + int.Parse(c.B.ToString()) + int.Parse(c.G.ToString()) ) / 3;
                        v = Color.FromArgb(c.A, av, av, av);
                        BlackAndWhiteImage.SetPixel(i, y, v);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
