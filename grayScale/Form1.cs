using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grayScale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = "C:\\Users\\swip\\Documents\\visual studio 2015\\Projects\\grayScale\\grayScale\\pictures\\cliff_by_hangmoon-d82isea.jpg";
            string saveGrayScale = "C:\\Users\\swip\\Documents\\visual studio 2015\\Projects\\grayScale\\grayScale\\pictures\\Grayscale.bmp";

            // read Bitmap
            Bitmap bitmap = new Bitmap(path);
            Bitmap save = bitmap;

            //load picture
            pictureBox1.Image = Image.FromFile(path);

            //get dimension
            int width = bitmap.Width;
            int height = bitmap.Height;

            bitmap = contrastProcessing(save, width, height);


            //load grayscale image in picture 2 box
            pictureBox2.Image = bitmap;

            //write grayscale image
            bitmap.Save(saveGrayScale);
        }

        private Bitmap grayScaleProcessing(Bitmap picture, int width, int height)
        {
            //color of pixel
            Color p;

            //grayscale
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = picture.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //find average
                    int avg = (r + g + b) / 3;

                    //set new pixel value
                    picture.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                }
            }
            return picture;
        }

        private Bitmap sepiaProcessing(Bitmap picture, int width, int height)
        {
            //color of pixel
            Color p;

            //sepia
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = picture.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //calculate temp value
                    int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                    int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                    int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                    //set new RGB value
                    if (tr > 255)
                    {
                        r = 255;
                    }
                    else
                    {
                        r = tr;
                    }

                    if (tg > 255)
                    {
                        g = 255;
                    }
                    else
                    {
                        g = tg;
                    }

                    if (tb > 255)
                    {
                        b = 255;
                    }
                    else
                    {
                        b = tb;
                    }

                    //set the new RGB value in image pixel
                    picture.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            return picture;
        }

        private Bitmap negativProcessing(Bitmap picture, int width, int height)
        {
            //negative
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    Color p = picture.GetPixel(x, y);

                    //extract ARGB value from p
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //find negative value
                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;

                    //set new ARGB value in pixel
                    picture.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            return picture;
        }

        private Bitmap blueProcessing(Bitmap picture, int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    Color p = picture.GetPixel(x, y);

                    //extract ARGB value from p
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //set blue image pixel
                    picture.SetPixel(x, y, Color.FromArgb(a, 0, 0, b));

                }
            }
            return picture;
        }

        private Bitmap redProcessing(Bitmap picture, int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    Color p = picture.GetPixel(x, y);

                    //extract ARGB value from p
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //set red image pixel
                    picture.SetPixel(x, y, Color.FromArgb(a, r, 0, 0));
                    
                }
            }
            return picture;
        }

        private Bitmap greenProcessing(Bitmap picture, int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    Color p = picture.GetPixel(x, y);

                    //extract ARGB value from p
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //set green image pixel
                    picture.SetPixel(x, y, Color.FromArgb(a, 0, g, 0));
                                       
                }
            }
            return picture;
        }
        
        /// <summary>
        ///     Permet de changer la luminosité par défaut 100
        ///         0 < 255  penche vers le blanc
        ///         0 < -255 penche vers le noir
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        private Bitmap brightnessProcessing(Bitmap picture, int width, int height, int range = 100)
        {
            if (range < -255) range = -255;
            if (range > 255) range = 255;

            //color of pixel
            Color c;
            
            // Brightness filtre processing
            for (int i = 0; i < picture.Width; i++)
            {
                for (int j = 0; j < picture.Height; j++)
                {
                    c = picture.GetPixel(i, j);
                    int r = c.R + range;
                    int g = c.G + range;
                    int b = c.B + range;

                    if (r < 0) r = 1;
                    if (r > 255) r = 255;

                    if (g < 0) g = 1;
                    if (g > 255) g = 255;

                    if (b < 0) b = 1;
                    if (b > 255) b = 255;

                    picture.SetPixel(i, j, Color.FromArgb((byte)r, (byte)g, (byte)b));
                }
            }
            return picture;
        }

        /// <summary>
        ///     Permet de changer le contrast par défaut la moitié (50)
        ///         0 < 100   tends vers le foncé
        ///         0 < -100  tends vers le clair
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        private Bitmap contrastProcessing(Bitmap picture, int width, int height, double range = 50)
        {
            
            if (range < -100) range = -100;
            if (range > 100) range = 100;
            range = (100.0 + range) / 100.0;
            range *= range;
            Color c;
            for (int i = 0; i < picture.Width; i++)
            {
                for (int j = 0; j < picture.Height; j++)
                {
                    c = picture.GetPixel(i, j);
                    double r = c.R / 255.0;
                    r -= 0.5;
                    r *= range;
                    r += 0.5;
                    r *= 255;
                    if (r < 0) r = 0;
                    if (r > 255) r = 255;

                    double g = c.G / 255.0;
                    g -= 0.5;
                    g *= range;
                    g += 0.5;
                    g *= 255;
                    if (g < 0) g = 0;
                    if (g > 255) g = 255;

                    double b = c.B / 255.0;
                    b -= 0.5;
                    b *= range;
                    b += 0.5;
                    b *= 255;
                    if (b < 0) b = 0;
                    if (b > 255) b = 255;

                    picture.SetPixel(i, j, Color.FromArgb((byte)r, (byte)g, (byte)b));
                }
            }
            return picture;
        }
    
    }
}
