using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1_hw2
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
    } // 결함의 종류

    internal class Defect
    {
        private double x, y; // 결함 중심의 X, Y 좌표
        private double defectWidth, defectHeight; // 결함 박스의 가로, 세로 크기
        private DefectType defectType; // 결함의 종류


        // x, y, defectWidth, defectHeight, type을 모두 전달받아 초기화하는 생성자
        public Defect(double x, double y, double width, double height, DefectType defectType)
        {
            this.x = x;
            this.y = y;
            this.defectWidth = width;
            this.defectHeight = height;
            this.defectType = defectType;
        }

        // x 좌표 Get 메서드
        public double GetX()
        {
            return x;
        }

        // y 좌표 Get 메서드
        public double GetY()
        {
            return y;
        }

        // x & y 좌표 Set 메서드
        public void SetCoordinates(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // defectWidth Get 메서드
        public double GetWidth()
        {
            return defectWidth;
        }

        // defectHeight Get 메서드
        public double GetHeight()
        {
            return defectHeight;
        }
        
        // defectWidth & defectHeight Set 메서드
        public void SetSize(double width, double height)
        {
            this.defectWidth = width;
            this.defectHeight = height;
        }

        // defectType Get 메서드
        public DefectType GetDefectType()
        {
            return defectType;
        }

        // defectType Set 메서드
        public void SetDefectType(DefectType defectType)
        {
            this.defectType = defectType;
        }
    }
}