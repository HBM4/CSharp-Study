using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch22_Polygon
{
    internal class Polygon
    {
        // NumberOfSides 속성은 다각형의 변의 수를 나타내는 정수형 속성이다.
        protected int NumberOfSides { get; set; }

        public Polygon()
        {
            NumberOfSides = 0;
        }

        public Polygon(int numberOfSides)
        {
            NumberOfSides = numberOfSides;
        }
    }
}
