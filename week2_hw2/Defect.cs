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
        Particle, // 고립된 형태의 구형 이물질 (Particle)
        Open, // 회로 패턴 끊어짐
        Bridge // 회로 패턴 붙음
    }

    internal class Defect
    {
        public int X1 { get; } // 결함 박스의 첫 번째 꼭짓점 x 좌표
        public int Y1 { get; } // 결함 박스의 첫 번째 꼭짓점 y 좌표
        public int X2 { get; } // 결함 박스의 두 번째 꼭짓점 x 좌표
        public int Y2 { get; } // 결함 박스의 두 번째 꼭짓점 y 좌표
        public DefectType Type { get; } // 결함의 종류

        // 결함 박스의 두 꼭짓점 좌표((x1,y1), (x2,y2))와 종류를 전달받아 저장하는 생성자
        // 생성 이후에는 값이 바뀌지 않으므로 읽기 전용 프로퍼티로 선언함
        public Defect(int x1, int y1, int x2, int y2, DefectType type)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            Type = type;
        }
    }
}
