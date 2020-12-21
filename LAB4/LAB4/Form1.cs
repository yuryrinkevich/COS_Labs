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
        Bitmap picture;

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "bmp|*.bmp";
            openFileDialog1.ShowDialog();
            picture = (Bitmap)Image.FromFile(openFileDialog1.FileName);
            pictureBox1.Image = picture;
            pictureBox1.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Sobel(int N)
        {
            int width = picture.Width;
            int height = picture.Height;
            int[,] gx = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] gy = new int[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

            int[,] allPixR = new int[width, height];
            int[,] allPixG = new int[width, height];
            int[,] allPixB = new int[width, height];

            int limit = N * N;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    allPixR[i, j] = picture.GetPixel(i, j).R;
                    allPixG[i, j] = picture.GetPixel(i, j).G;
                    allPixB[i, j] = picture.GetPixel(i, j).B;
                }
            }

            int new_rx = 0, new_ry = 0;
            int new_gx = 0, new_gy = 0;
            int new_bx = 0, new_by = 0;
            int rc, gc, bc;
            for (int i = 1; i < picture.Width - 1; i++)
            {
                for (int j = 1; j < picture.Height - 1; j++)
                {

                    new_rx = 0;
                    new_ry = 0;
                    new_gx = 0;
                    new_gy = 0;
                    new_bx = 0;
                    new_by = 0;
                    rc = 0;
                    gc = 0;
                    bc = 0;
                    for (int wi = -1; wi < 2; wi++)
                    {
                        for (int hw = -1; hw < 2; hw++)
                        {
                            rc = allPixR[i + hw, j + wi];
                            new_rx += gx[wi + 1, hw + 1] * rc;
                            new_ry += gy[wi + 1, hw + 1] * rc;

                            gc = allPixG[i + hw, j + wi];
                            new_gx += gx[wi + 1, hw + 1] * gc;
                            new_gy += gy[wi + 1, hw + 1] * gc;

                            bc = allPixB[i + hw, j + wi];
                            new_bx += gx[wi + 1, hw + 1] * bc;
                            new_by += gy[wi + 1, hw + 1] * bc;
                        }
                    }
                    if (new_rx * new_rx + new_ry * new_ry > limit || new_gx * new_gx + new_gy * new_gy > limit || new_bx * new_bx + new_by * new_by > limit)
                        picture.SetPixel(i, j, Color.Black);
                    else
                        picture.SetPixel(i, j, Color.White);
                }
            }
        }

                private void button3_Click(object sender, EventArgs e)
        {
            int N = Convert.ToInt32(textBox2.Text);

            Sobel(N);

            pictureBox2.Image = picture;
            pictureBox2.Invalidate();
        }


    }

}

          
