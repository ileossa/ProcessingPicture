﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grayScale
{
    class Processing : IProcessing
    {
        private Bitmap picture;
        private int width;
        private int height;

        public Processing(Bitmap picture)
        {
            transforme(picture);
        }

        public Processing(string path)
        {
            transforme(path);
        }

        private void transforme(string path)
        {
            //set picture
            Bitmap picture = new Bitmap(path);
            this.picture = picture;

            //get dimension
            width = picture.Width;
            height = picture.Height;
        }
        private void transforme(Bitmap picture)
        {
            //set picture
            this.picture = picture;

            //get dimension
            width = picture.Width;
            height = picture.Height;
        }

        Bitmap IProcessing.grayScaleProcessing()
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

        Bitmap IProcessing.sepiaProcessing()
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

        Bitmap IProcessing.negativProcessing()
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

        Bitmap IProcessing.blueProcessing()
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

        Bitmap IProcessing.redProcessing()
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

        Bitmap IProcessing.greenProcessing()
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
        Bitmap IProcessing.brightnessProcessing(int range = 100)
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
        Bitmap IProcessing.contrastProcessing(double range = 50)
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

        Bitmap IProcessing.resizeProcessing()
        {
            if (width != 0 && height != 0)
            {
                Bitmap temp = picture;
                Bitmap bmap = new Bitmap(width, height, temp.PixelFormat);

                double nWidthFactor = (double)temp.Width / (double)width;
                double nHeightFactor = (double)temp.Height / (double)height;

                double fx, fy, nx, ny;
                int cx, cy, fr_x, fr_y;
                Color color1 = new Color();
                Color color2 = new Color();
                Color color3 = new Color();
                Color color4 = new Color();
                byte nRed, nGreen, nBlue;

                byte bp1, bp2;

                for (int x = 0; x < bmap.Width; ++x)
                {
                    for (int y = 0; y < bmap.Height; ++y)
                    {

                        fr_x = (int)Math.Floor(x * nWidthFactor);
                        fr_y = (int)Math.Floor(y * nHeightFactor);
                        cx = fr_x + 1;
                        if (cx >= temp.Width) cx = fr_x;
                        cy = fr_y + 1;
                        if (cy >= temp.Height) cy = fr_y;
                        fx = x * nWidthFactor - fr_x;
                        fy = y * nHeightFactor - fr_y;
                        nx = 1.0 - fx;
                        ny = 1.0 - fy;

                        color1 = temp.GetPixel(fr_x, fr_y);
                        color2 = temp.GetPixel(cx, fr_y);
                        color3 = temp.GetPixel(fr_x, cy);
                        color4 = temp.GetPixel(cx, cy);

                        // Blue
                        bp1 = (byte)(nx * color1.B + fx * color2.B);

                        bp2 = (byte)(nx * color3.B + fx * color4.B);

                        nBlue = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Green
                        bp1 = (byte)(nx * color1.G + fx * color2.G);

                        bp2 = (byte)(nx * color3.G + fx * color4.G);

                        nGreen = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Red
                        bp1 = (byte)(nx * color1.R + fx * color2.R);

                        bp2 = (byte)(nx * color3.R + fx * color4.R);

                        nRed = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        bmap.SetPixel(x, y, System.Drawing.Color.FromArgb(255, nRed, nGreen, nBlue));
                    }
                }
            }
            return picture;
        }


       
    }



  
}
