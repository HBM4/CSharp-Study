using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch34_OperatorOverloading
{
    internal class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        // 모든 연산자 오버로드는 public이면서, static이어야 한다.
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y);
        }

        public static Vector operator +(Vector v, double scalar)
        {
            return new Vector(v.X + scalar, v.Y + scalar);
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            // return (v1 == v2);로 쓰면 Vector 타입 비교가 되어 자기 자신을 무한 재귀 호출하게 된다.
            return ((v1.X == v2.X) && (v1.Y == v2.Y));
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return !(v1 == v2); // 그냥 == 연산자의 반대 결과를 반환합니다.
        }
    }
}
