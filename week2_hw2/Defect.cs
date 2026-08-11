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
        private int minX, maxX, minY, maxY; // 결함 박스의 좌우상하 경계 픽셀 좌표
        private DefectType defectType; // 결함의 종류

        // 중심좌표(x, y)와 크기(width, height)를 전달받아, 경계 좌표(min/max)로 변환해 저장하는 생성자
        public Defect(int x, int y, int width, int height, DefectType defectType)
        {
            this.minX = x - width / 2;
            this.maxX = x + width / 2;
            this.minY = y - height / 2;
            this.maxY = y + height / 2;
            this.defectType = defectType;
        }

        // minX Get 메서드
        public int GetMinX()
        {
            return minX;
        }

        // maxX Get 메서드
        public int GetMaxX()
        {
            return maxX;
        }

        // minY Get 메서드
        public int GetMinY()
        {
            return minY;
        }

        // maxY Get 메서드
        public int GetMaxY()
        {
            return maxY;
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
