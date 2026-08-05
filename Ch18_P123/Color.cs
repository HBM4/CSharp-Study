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


/*
<Color 클래스>
- 컴퓨터에서 색상은 일반적으로 빨간색(red), 녹색(green), 파란색(blue), 알파(alpha, 투명도) 값으로 표현되며, 보통 0에서 255 사이의 범위를 가집니다. 이 값들을 인스턴스 변수로 추가하세요.
- 빨간색, 녹색, 파란색, 알파 값을 매개변수로 받는 생성자.
- 빨간색, 녹색, 파란색만 매개변수로 받으며, 알파 값은 기본적으로 255(불투명)로 설정되는 생성자.
- Color 인스턴스에서 빨간색, 녹색, 파란색, 알파 값을 가져오고(get) 설정하는(set) 메서드.
- 색상의 그레이스케일(grayscale, 회색조) 값을 가져오는 메서드. 그레이스케일 값은 빨간색, 녹색, 파란색 값의 평균입니다.
*/