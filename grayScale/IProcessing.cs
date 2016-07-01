using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grayScale
{
    interface IProcessing
    {

        Bitmap grayScaleProcessing();

        Bitmap sepiaProcessing();

        Bitmap negativProcessing();

        Bitmap blueProcessing();

        Bitmap redProcessing();

        Bitmap greenProcessing();

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
        Bitmap brightnessProcessing(int range = 100);

         
        Bitmap contrastProcessing(double range = 50);

        Bitmap resizeProcessing();
        
    }
}
