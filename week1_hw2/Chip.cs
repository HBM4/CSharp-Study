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
        private Defect[] defects; // 칩에 존재하는 결함들을 저장하는 배열
        private int defectCount; // 현재 칩에 존재하는 결함의 수

        // chipID, width, height를 전달받아 초기화하는 생성자
        public Chip(string chipID, double width, double height)
        {
            this.chipID = chipID;
            this.width = width;
            this.height = height;
            defects = new Defect[100]; // 최대 100개의 결함을 저장할 수 있는 배열 (나중에 무한 확장 가능하게 가능?)
            defectCount = 0;
        }

        // 현재 미사용: chipID 받아서 초기화하는 생성자 (나중에 File I/O 관련 배우면 활용 가능?)
        public Chip(string chipID)
        {
            this.chipID = chipID;
            // width, height는 자동으로 설정하는 코드
            defects = new Defect[100];
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

        // width & height Get, Set 메서드
        public (double, double) GetDimensions()
        {
            return (width, height);
        }

        public void SetDimensions(double width, double height) // File I/O 이후엔 필요 없을 듯?
        {
            this.width = width;
            this.height = height;
        }

        // Chip에 Defect 추가하는 메서드
        public void AddDefect(Defect defect)
        {
            // 결함 중심점 좌표가 칩 경계를 벗어나는지 확인
            double x, y;
            (x, y) = defect.GetCoordinates();

            if (x < 0 || x > width || y < 0 || y > height)
            {
                Console.WriteLine("Error: 추가 실패. 결함 좌표가 칩 경계를 벗어남.");
                return;
            }

            // 그려지는 결함 박스가 칩 경계를 벗어나는지 확인
            double w, h;
            (w, h) = defect.GetSize();

            if (x - w / 2 < 0 || x + w / 2 > width || y - h / 2 < 0 || y + h / 2 > height)
            {
                Console.WriteLine("Error: 추가 실패. 결함 박스가 칩 경계를 벗어남.");
                return;
            }

            // DefectType이 유효한 값인지 확인
            // Enum.GetValues(typeof(DefectType))는 { Pit, Discolor, Scratch, Void, Crack, Particle, Short }를 담은 배열을 반환함
            bool isValidType = false;
            foreach (DefectType type in Enum.GetValues(typeof(DefectType)))
            {
                if (type == defect.GetDefectType())
                {
                    isValidType = true;
                    break;
                }
            }

            if (!isValidType)
            {
                Console.WriteLine("Error: 추가 실패. 유효하지 않은 DefectType을 입력함.");
                return;
            }

            // 결함을 배열에 추가 및 최대 결함 수 초과 확인 (무한 배열일 시 수정 필요)
            if (defectCount >= defects.Length)
            {
                Console.WriteLine($"Error: 추가 실패. 추가 가능한 결함 수를 초과함. (최대 {defects.Length}개)");
                return;
            }

            defects[defectCount] = defect;
            defectCount++;

            Console.WriteLine($"Log: {chipID}에 {defectCount}번째 결함을 추가함. (Type={defect.GetDefectType()}, Coordinates=({x}, {y}), Size=({w}, {h}))");)
        }

        // index에 해당하는 결함을 반환하는 메서드
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
            Console.WriteLine($"Chip Dimensions: {width} x {height}");
            Console.WriteLine($"Number of Defects: {defectCount}");

            for (int i = 0; i < defectCount; i++)
            {
                var defect = defects[i];
                var (x, y) = defect.GetCoordinates();
                var (w, h) = defect.GetSize();
                Console.WriteLine($"└ Defect {i}: Type={defect.GetDefectType()}, Coordinates=({x}, {y}), Size=({w}, {h})");
            }
            Console.WriteLine("========================");
        }
    }
}