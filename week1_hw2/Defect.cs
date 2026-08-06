using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1_hw2
{
    public enum DefectType { Pit, Discolor, Scratch, Void, Crack, Particle, Short } // 결함의 종류

    internal class Defect
    {
        private double x, y; // 결함 중심의 X, Y 좌표
        private double width, height; // 결함 박스의 가로, 세로 크기
        private DefectType defectType;


        // x, y, width, height, type을 모두 전달받아 초기화하는 생성자
        public Defect(double x, double y, double width, double height, DefectType defectType)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.defectType = defectType;
        }

        public DefectType GetDefectType()
        {
            return defectType;
        }

        public void SetDefectType(DefectType defectType)
        {
            // DefectType 존재하지 않는 것 입력 시 오류 메세지 출력
            foreach(DefectType type in Enum.GetValues(typeof(DefectType)))
            {
                if (type == defectType)
                {
                    this.defectType = defectType;
                    return;
                }
            }

            Console.WriteLine("Error: Invalid DefectType");
        }

        public (double, double) GetCoordinates()
        {
            return (x, y);
        }

        public void SetCoordinates(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public (double, double) GetSize()
        {
            return (width, height);
        }

        public void SetSize(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
    }
}