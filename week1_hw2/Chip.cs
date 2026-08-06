using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1_hw2
{
    internal class Chip
    {
        private string chipID; // 칩의 고유 ID
        private double width, height; // 칩의 가로, 세로 크기
        private Defect[] defects;
        private int defectCount;

        // chipID, width, height를 전달받아 초기화하는 생성자
        public Chip(string chipID, double width, double height)
        {
            this.chipID = chipID;
            this.width = width;
            this.height = height;
            defects = new Defect[100]; // 최대 100개의 결함을 저장할 수 있는 배열 (나중에 무한 확장 가능하게 가능?)
            defectCount = 0;
        }

        // chipID 받아서 초기화하는 생성자 (나중에 File I/O나 이미지 관련 배우면 활용?)
        public Chip(string chipID)
        {
            this.chipID = chipID;
            defects = new Defect[100]; // 최대 100개의 결함을 저장할 수 있는 배열
            defectCount = 0;
        }

        // chipID Get, Set 메서드
        public string GetChipID()
        {
            return chipID;
        }

        public void SetChipID(string chipID)
        {
            this.chipID = chipID;
        }
    }
}
