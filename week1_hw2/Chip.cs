using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1_hw2
{
    internal class Chip
    {
        private string chipID; // 칩의 ID (사용자 마음대로)
        private double chipWidth, chipHeight; // 칩의 가로, 세로 크기
        private Defect[] defects; // 칩에 존재하는 결함들을 저장하는 배열 (Defect 클래스 인스턴스들)
        private int defectCount; // 현재 칩에 존재하는 결함의 수

        // chipID, chipWidth, chipHeight를 전달받아 초기화하는 생성자
        // 추후 File I/O나 이미지 처리 가능하면 chipWidth, chipHeight 자동 처리로 수정
        public Chip(string chipID, double width, double height)
        {
            this.chipID = chipID;
            this.chipWidth = width;
            this.chipHeight = height;
            defects = new Defect[100]; // 칩 당 최대 100개의 결함 저장 (나중에 무한 확장 가능?)
            defectCount = 0;
        }

        // chipID Get 메서드
        public string GetChipID()
        {
            return chipID;
        }

        // chipID Set 메서드
        public void SetChipID(string chipID)
        {
            this.chipID = chipID;
        }

        // chipWidth Get 메서드
        public double GetWidth()
        {
            return chipWidth;
        }

        // chipHeight Get 메서드
        public double GetHeight()
        {
            return chipHeight;
        }

        // chipWidth, chipHeight Set 메서드
        public void SetSize(double width, double height)
        {
            this.chipWidth = width;
            this.chipHeight = height;
        }

        // Chip에 Defect 추가하는 메서드
        public void AddDefect(Defect defect)
        {
            // 결함 중심점 좌표가 칩 경계를 벗어나는지 확인
            double x = defect.GetX();
            double y = defect.GetY();

            if (x < 0 || x > chipWidth || y < 0 || y > chipHeight)
            {
                Console.WriteLine("Error: 추가 실패. 결함 좌표가 칩 경계를 벗어남.");
                return;
            }

            // 차지하는 결함 박스가 칩 경계를 벗어나는지 확인
            double w = defect.GetWidth();
            double h = defect.GetHeight();

            if (x - w / 2 < 0 || x + w / 2 > chipWidth || y - h / 2 < 0 || y + h / 2 > chipHeight)
            {
                Console.WriteLine("Error: 추가 실패. 결함 박스가 칩 경계를 벗어남.");
                return;
            }

            // 최대 결함 수 초과 확인 (무한 배열일 시 수정 필요)
            if (defectCount >= defects.Length)
            {
                Console.WriteLine($"Error: 추가 실패. 추가 가능한 결함 수를 초과함. (최대 {defects.Length}개)");
                return;
            }

            // 결함 배열에 추가
            defects[defectCount] = defect;
            defectCount++;

            Console.WriteLine($"Log: {chipID}에 {defectCount}번째 결함을 추가함. (Type={defect.GetDefectType()}, Coordinates=({x}, {y}), Size=({w}, {h}))");
        }

        // Chip에 Defect 조회하는 메서드
        public Defect GetDefect(int index)
        {
            if (index < 0 || index >= defectCount)
            {
                Console.WriteLine("Error: 조회 실패. 유효하지 않은 결함 인덱스를 입력함.");
                return null;
            }

            return defects[index];
        }

        // Chip에 Defect 제거하는 메서드
        public void RemoveDefect(int index)
        {
            if (index < 0 || index >= defectCount)
            {
                Console.WriteLine("Error: 삭제 실패. 유효하지 않은 결함 인덱스를 입력함.");
                return;
            }

            // 결함 제거 후 배열을 재정렬
            for (int i = index; i < defectCount - 1; i++)
            {
                defects[i] = defects[i + 1]; // 한 칸씩 앞으로 이동
            }

            defects[defectCount - 1] = null; // 마지막 요소를 null로 설정
            defectCount--;

            Console.WriteLine($"Log: {index + 1}번째 결함을 제거함.");
        }

        // 칩에 존재하는 결함의 수를 반환하는 메서드
        public int GetDefectCount()
        {
            return defectCount;
        }

        // Chip 정보 출력하는 메서드
        public void PrintChipInfo()
        {
            Console.WriteLine("========================");
            Console.WriteLine($"Chip ID: {chipID}");
            Console.WriteLine($"Chip Size: {chipWidth} x {chipHeight}");
            Console.WriteLine($"총 결함 수: {defectCount}");

            for (int i = 0; i < defectCount; i++)
            {
                Defect defect = defects[i];
                double x = defect.GetX();
                double y = defect.GetY();
                double w = defect.GetWidth();
                double h = defect.GetHeight();
                Console.WriteLine($"└ Defect {i}: Type={defect.GetDefectType()}, Coordinates=({x}, {y}), Size=({w}, {h})");
            }
            Console.WriteLine("========================");
        }
    }
}