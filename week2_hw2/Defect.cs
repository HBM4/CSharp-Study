using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2_hw2
{
    public enum DefectType
    {
        Bright, // 명불량 (주변보다 밝은 픽셀 - 이물, 반사체 등)
        Dark, // 암불량 (주변보다 어두운 픽셀 - 이물, Pit 등)
        Stain, // 넓은 영역의 완만한 명암/색상 편차 (Stain / Discolor)
        Scratch, // 선형 결함 (Aspect Ratio가 매우 큰 형태)
        Particle, // 고립된 형태의 구형/Blob 이물질 (Particle)
        Open, // 회로 패턴 끊어짐
        Bridge // 회로 패턴 맞붙음
    }

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
