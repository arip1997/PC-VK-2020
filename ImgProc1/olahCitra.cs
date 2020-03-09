using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgProc1
{
    class olahCitra
    {
        public static bool keBrightness(Bitmap b)
        {
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color c1 = b.GetPixel(i, j);
                    int r1 = c1.R + 255;
                    int g1 = c1.G + 255;
                    int b1 = c1.B + 255;
                    int r2 = truncate(r1);
                    int g2 = truncate(g1);
                    int b2 = truncate(b1);


                    b.SetPixel(i, j, Color.FromArgb(r2, g2, b2));
                }
            }
            return true;
        }
        private static int truncate(int x)
        {
            if (x > 255) x = 255;
            else if (x < 0) x = 0;
            return x;
        }
    }
}
