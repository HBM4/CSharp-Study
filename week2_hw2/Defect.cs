using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2_hw2
{
    public enum DefectType { Pit, Discolor, Scratch, Void, Crack, Particle, Short } // 결함의 종류

    internal class Defect
    {
        public int MinX { get; } // 결함 박스의 좌측 경계 x 좌표
        public int MaxX { get; } // 결함 박스의 우측 경계 x 좌표
        public int MinY { get; } // 결함 박스의 하단 경계 y 좌표
        public int MaxY { get; } // 결함 박스의 상단 경계 y 좌표
        public DefectType Type { get; } // 결함의 종류

        // 결함 박스의 경계 좌표(min/max)와 종류를 전달받아 저장하는 생성자
        // 생성 이후에는 값이 바뀌지 않으므로 읽기 전용 프로퍼티로 선언함
        public Defect(int minX, int maxX, int minY, int maxY, DefectType type)
        {
            MinX = minX;
            MaxX = maxX;
            MinY = minY;
            MaxY = maxY;
            Type = type;
        }
    }
}
