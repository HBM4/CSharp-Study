using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2_hw2
{
    internal class Die
    {
        private string dieID; // 다이의 ID (사용자 마음대로)|
        private int dieWidth, dieHeight; // 다이 이미지의 가로, 세로 픽셀 크기
        private Defect[] defects; // 다이 이미지에 존재하는 결함들을 저장하는 배열 (Defect 클래스 인스턴스들)
        private int defectCount; // 현재 다이 이미지에 존재하는 결함의 수

        // dieID, dieWidth, dieHeight를 전달받아 초기화하는 생성자
        // 추후 File I/O나 이미지 처리 가능하면 dieWidth, dieHeight 자동 처리로 수정
        public Die(string dieID, int width, int height)
        {
            this.dieID = dieID;
            this.dieWidth = width;
            this.dieHeight = height;
            defects = new Defect[100]; // 다이 당 최대 100개의 결함 저장 (나중에 무한 확장 가능?)
            defectCount = 0;
        }

        // dieID Get 메서드
        public string GetDieID()
        {
            return dieID;
        }

        // dieID Set 메서드
        public void SetDieID(string dieID)
        {
            this.dieID = dieID;
        }

        // dieWidth Get 메서드
        public int GetWidth()
        {
            return dieWidth;
        }

        // dieHeight Get 메서드
        public int GetHeight()
        {
            return dieHeight;
        }

        // dieWidth, dieHeight Set 메서드
        public void SetSize(int width, int height)
        {
            this.dieWidth = width;
            this.dieHeight = height;
        }

        // Die에 Defect 추가하는 메서드
        public void AddDefect(Defect defect)
        {
            // 결함 박스가 다이 경계를 벗어나는지 확인
            int minX = defect.GetMinX();
            int maxX = defect.GetMaxX();
            int minY = defect.GetMinY();
            int maxY = defect.GetMaxY();

            if (minX < 0 || maxX > dieWidth || minY < 0 || maxY > dieHeight)
            {
                Console.WriteLine("Error: 추가 실패. 결함 박스가 다이 경계를 벗어남.");
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

            Console.WriteLine($"Log: {dieID}에 {defectCount}번째 결함을 추가함. (Type={defect.GetDefectType()}, X=[{minX}, {maxX}], Y=[{minY}, {maxY}])");
        }

        // Die에 Defect 조회하는 메서드
        public Defect GetDefect(int index)
        {
            if (index < 0 || index >= defectCount)
            {
                Console.WriteLine("Error: 조회 실패. 유효하지 않은 결함 인덱스를 입력함.");
                return null;
            }

            return defects[index];
        }

        // Die에 Defect 제거하는 메서드
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

        // 다이에 존재하는 결함의 수를 반환하는 메서드
        public int GetDefectCount()
        {
            return defectCount;
        }

        // Die 정보 출력하는 메서드
        public void PrintDieInfo()
        {
            Console.WriteLine("========================");
            Console.WriteLine($"Die ID: {dieID}");
            Console.WriteLine($"Die Size: {dieWidth} x {dieHeight}");
            Console.WriteLine($"총 결함 수: {defectCount}");

            for (int i = 0; i < defectCount; i++)
            {
                Defect defect = defects[i];
                int minX = defect.GetMinX();
                int maxX = defect.GetMaxX();
                int minY = defect.GetMinY();
                int maxY = defect.GetMaxY();
                Console.WriteLine($"└ Defect {i}: Type={defect.GetDefectType()}, X=[{minX}, {maxX}], Y=[{minY}, {maxY}]");
            }
            Console.WriteLine("========================");
        }
    }
}
