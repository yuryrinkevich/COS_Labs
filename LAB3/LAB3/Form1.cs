using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {

        private static double GS_RED = 0.25;
        private static double GS_GREEN = 0.58;
        private static double GS_BLUE = 0.17;

        public Form1()
        {
            InitializeComponent();
        }
        int Width;
        int Height;
        Bitmap picture;

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "bmp|*.bmp";
            openFileDialog1.ShowDialog();
            picture = (Bitmap)Image.FromFile(openFileDialog1.FileName);
            pictureBox1.Image = picture;
            pictureBox1.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int percent_noize;
            percent_noize = Convert.ToInt32(textBox1.Text);
            Random rand = new Random();
            for (int i = 0; i < ((picture.Width - 1) * (picture.Height - 1) * percent_noize / 100); i++)
            {
                picture.SetPixel(rand.Next(picture.Width), rand.Next(picture.Height), Color.White);
            }
            pictureBox2.Image = picture;
            pictureBox2.Invalidate();

        }



        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void black_white(int[,] blackpicture)
        {
            Color color;
            int red, blue, green, black;

            for (int i = 0; i < picture.Width; i++)
                for (int j = 0; j < picture.Height; j++)
                {
                    color = picture.GetPixel(i, j);
                    red = Convert.ToInt32(color.R);
                    green = Convert.ToInt32(color.G);
                    blue = Convert.ToInt32(color.B);
                    black = (int)(red * GS_RED + green * GS_GREEN + blue * GS_BLUE);
                    blackpicture[i, j] = black;

                    picture.SetPixel(i, j, Color.FromArgb(black, black, black));
                }
        }

        void stolb(int[,] blackpicture, int N)
        {
            for (int i = 0; i < picture.Height; i++)
                for (int j = 0; j < picture.Width;)
                {
                    int[] mas = new int[N];
                    for (int k = 0; k < N; k++)
                    {
                        if (j <= picture.Width - N)
                        {
                            mas[k] = blackpicture[k + j, i];
                        }
                    }
                    Array.Sort(mas);
                    int koef = mas[N / 2];
                    for (int k = 0; k < N; k++)
                    {
                        if (j >= picture.Width - N)
                            break;
                        picture.SetPixel(k + j, i, Color.FromArgb(koef, koef, koef));
                    }
                    j += N;
                }
        }

        void strok(int[,] blackpicture, int N)
        {
            for (int i = 0; i < picture.Width; i++)
                for (int j = 0; j < picture.Height;)
                {
                    int[] mas = new int[N];
                    for (int k = 0; k < N; k++)
                    {
                        if (j <= picture.Height - N)
                        {
                            mas[k] = blackpicture[i, k + j];
                        }
                    }
                    Array.Sort(mas);
                    int koef = mas[N / 2];
                    for (int k = 0; k < N; k++)
                    {
                        if (j >= picture.Height - N)
                            break;
                        picture.SetPixel(i, k + j, Color.FromArgb(koef, koef, koef));
                    }
                    j += N;
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[,] blackpicture = new int[picture.Width, picture.Height];
            int N = Convert.ToInt32(textBox2.Text);

            black_white(blackpicture);
            stolb(blackpicture, N);

            pictureBox3.Image = picture;
            pictureBox3.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[,] blackpicture = new int[picture.Width, picture.Height];
            int N = Convert.ToInt32(textBox2.Text);

            black_white(blackpicture);
            strok(blackpicture, N);

            pictureBox3.Image = picture;
            pictureBox3.Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int[,] blackpicture = new int[picture.Width, picture.Height];
            int N = Convert.ToInt32(textBox2.Text);

            black_white(blackpicture);
            stolb(blackpicture, N);
            strok(blackpicture, N);

            pictureBox3.Image = picture;
            pictureBox3.Invalidate();
        }
    }


}

          
