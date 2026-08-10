using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch22_Polygon
{
    internal class Triangle : Polygon // Triangle 클래스는 Polygon 클래스를 기반으로 하는 파생 클래스이다.
    {
        public Triangle()
        {
            NumberOfSides = 3; // 삼각형은 항상 3개의 변을 가지므로 NumberOfSides 속성을 3으로 설정한다.
        }
    }
}
