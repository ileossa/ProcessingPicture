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
            Bitmap result ;

            //load picture
            pictureBox1.Image = Image.FromFile(path);


            IProcessing p = new Processing(path);
            result = p.grayScaleProcessing();


            //load grayscale image in picture 2 box
            pictureBox2.Image = result;

            //write grayscale image
            result.Save(saveGrayScale);
        }

        
    }
}
