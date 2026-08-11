using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2_hw2
{
    internal class Die
    {
        private List<Defect> defects; // 다이 이미지에 존재하는 결함들을 저장하는 리스트

        public string DieID { get; } // 다이의 ID (사용자 마음대로)
        public int Width { get; } // 다이 이미지의 가로 픽셀 크기
        public int Height { get; } // 다이 이미지의 세로 픽셀 크기
        public int DefectCount // 다이 이미지에 존재하는 결함의 개수
        { 
            get { return defects.Count; }
        } 

        // dieID, dieWidth, dieHeight를 전달받아 초기화하는 생성자
        // 추후 File I/O나 이미지 처리 가능하면 dieWidth, dieHeight 자동 처리로 수정
        public Die(string dieID, int width, int height)
        {
            DieID = dieID;
            Width = width;
            Height = height;
            defects = new List<Defect>(); // 결함 개수 제한 없이 저장
        }

        // Die에 Defect 추가하는 메서드
        public void AddDefect(Defect defect)
        {
            // 결함 박스가 다이 경계를 벗어나는지 확인
            int minX = defect.MinX;
            int maxX = defect.MaxX;
            int minY = defect.MinY;
            int maxY = defect.MaxY;

            if (minX < 0 || maxX > Width || minY < 0 || maxY > Height)
            {
                Console.WriteLine("Error: 추가 실패. 결함 박스가 다이 경계를 벗어남.");
                return;
            }

            defects.Add(defect); // Add: 리스트에 결함 추가

            Console.WriteLine($"Log: {DieID}에 {DefectCount}번째 결함을 추가함. (Type={defect.Type}, X=[{minX}, {maxX}], Y=[{minY}, {maxY}])");
        }

        // Die에 Defect 조회하는 메서드
        public Defect GetDefect(int index)
        {
            if (index < 0 || index >= DefectCount)
            {
                Console.WriteLine("Error: 조회 실패. 유효하지 않은 결함 인덱스를 입력함.");
                return null;
            }

            return defects[index];
        }

        // Die에 Defect 제거하는 메서드
        public void RemoveDefect(int index)
        {
            if (index < 0 || index >= DefectCount)
            {
                Console.WriteLine("Error: 삭제 실패. 유효하지 않은 결함 인덱스를 입력함.");
                return;
            }

            defects.RemoveAt(index); // RemoveAt: 리스트에서 특정 인덱스의 요소 제거

            Console.WriteLine($"Log: {index + 1}번째 결함을 제거함.");
        }

        // Die 정보 출력하는 메서드
        public void PrintDieInfo()
        {
            Console.WriteLine("========================");
            Console.WriteLine($"Die ID: {DieID}");
            Console.WriteLine($"Die Size: {Width} x {Height}");
            Console.WriteLine($"총 결함 수: {DefectCount}");

            for (int i = 0; i < DefectCount; i++)
            {
                Defect defect = defects[i];
                Console.WriteLine($"└ Defect {i}: Type={defect.Type}, X=[{defect.MinX}, {defect.MaxX}], Y=[{defect.MinY}, {defect.MaxY}]");
            }
            Console.WriteLine("========================");
        }
    }
}
