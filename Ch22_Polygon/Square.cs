using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch22_Polygon
{
    internal class Square : Polygon // Square 클래스는 Polygon 클래스를 기반으로 하는 파생 클래스이다.
    {
        // Size 속성은 정사각형의 한 변의 길이를 나타내는 실수형 속성이다.
        public float Size { get; set; }

        public Square(float size) : base(4) // 정사각형은 항상 4개의 변을 가지므로 NumberOfSides 속성을 4로 설정한다.
        {
            Size = size;
            // NumberOfSides = 4; // 정사각형은 항상 4개의 변을 가지므로 NumberOfSides 속성을 4로 설정한다.
        }
    }
}
