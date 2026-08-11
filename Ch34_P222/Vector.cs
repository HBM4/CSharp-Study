using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch34_P222
{
    internal class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z {  get; set; }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        // 모든 연산자 오버로드는 public이면서, static이어야 한다.
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y, -v.Z);
        }

        // 벡터에 숫자(스칼라)를 곱합니다. 그러면 (1, 2, 3) * 4는 (4, 8, 12)가 되어야 합니다.
        public static Vector operator *(Vector v, double scalar)
        {
            return new Vector(v.X * scalar, v.Y * scalar, v.Z * scalar);
        }

        // 벡터를 숫자(스칼라)로 나눕니다. 그러면 (2, 4, 6) / 2는 (1, 2, 3)이 되어야 합니다.
        public static Vector operator /(Vector v, double scalar)
        {
            return new Vector(v.X / scalar, v.Y / scalar, v.Z / scalar);
        }
    }
}
