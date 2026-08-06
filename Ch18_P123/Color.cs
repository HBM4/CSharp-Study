using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch18_P123
{
    internal class Color
    {
        private int red;
        private int green;
        private int blue;
        private int alpha;

        public Color(int red, int green, int blue, int alpha)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = alpha;
        }

        public Color(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = 255;
        }

        public int getRed()
        {
            return this.red;
        }

        public void setRed(int red)
        {
            this.red = red;
        }

        public int getGreen()
        {
            return this.green;
        }
        public void setGreen(int green)
        {
            this.green = green;
        }

        public int getBlue()
        {
            return this.blue;
        }

        public void setBlue(int blue)
        {
            this.blue = blue;
        }

        public int getAlpha()
        {
            return this.alpha;
        }

        public void setAlpha(int alpha)
        {
            this.alpha = alpha;
        }

        public int getGrayscale()
        {
            return (this.red + this.green + this.blue) / 3;
        }
    }
}