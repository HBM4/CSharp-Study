using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1_hw2
{
    /*
    create_chip chipID chipWidth chipHeight
    remove_chip chipID
    add_defect chipID x y defectWidth defectHeight defectType
    remove_defect chipID index
    print chipID
    exit
    */

    internal class Program
    {
        static Chip[] chips = new Chip[100];
        static int chipCount = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("\n> ");
                string text = Console.ReadLine();
                string[] words = text.Split(' ');

                if (words[0] == "create_chip")
                    CreateChip(words);
                else if (words[0] == "remove_chip")
                    RemoveChip(words);
                else if (words[0] == "add_defect")
                    AddDefect(words);
                else if (words[0] == "remove_defect")
                    RemoveDefect(words);
                else if (words[0] == "print")
                    Print(words);
                else if (words[0] == "exit")
                    break;
            }

            Console.WriteLine("Log: 프로그램 종료.");
        }

        // chipID로 칩을 찾는 메서드 (없으면 null 반환)
        static Chip FindChip(string chipID)
        {
            for (int i = 0; i < chipCount; i++)
            {
                if (chips[i].GetChipID() == chipID)
                {
                    return chips[i];
                }
            }

            return null;
        }

        // > create_chip chipID chipWidth chipHeight
        // chipID, chipWidth, chipHeight를 전달받아 칩 생성
        static void CreateChip(string[] words)
        {
            string chipID = words[1];
            double chipWidth = Convert.ToDouble(words[2]);
            double chipHeight = Convert.ToDouble(words[3]);

            chips[chipCount] = new Chip(chipID, chipWidth, chipHeight);
            chipCount++;

            Console.WriteLine($"Log: {chipID} 칩을 생성함. (Width={chipWidth}, Height={chipHeight})");
        }

        // > remove_chip chipID
        // chipID에 해당하는 칩 제거
        static void RemoveChip(string[] words)
        {
            string chipID = words[1];

            int index = -1;
            for (int i = 0; i < chipCount; i++)
            {
                if (chips[i].GetChipID() == chipID)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine("Error: 삭제 실패. 존재하지 않는 chipID입니다.");
                return;
            }

            // 칩 제거 후 배열을 재정렬
            for (int i = index; i < chipCount - 1; i++)
            {
                chips[i] = chips[i + 1]; // 한 칸씩 앞으로 이동
            }

            chips[chipCount - 1] = null; // 마지막 요소를 null로 설정
            chipCount--;

            Console.WriteLine($"Log: {chipID} 칩을 제거함.");
        }

        // > add_defect chipID x y defectWidth defectHeight defectType
        // chipID에 해당하는 칩에 결함 추가
        static void AddDefect(string[] words)
        {
            string chipID = words[1];
            Chip chip = FindChip(chipID);

            if (chip == null)
            {
                Console.WriteLine("Error: 추가 실패. 존재하지 않는 chipID입니다.");
                return;
            }

            double x = Convert.ToDouble(words[2]); // 결함 박스 중앙 x 좌표
            double y = Convert.ToDouble(words[3]); // 결함 박스 중앙 y 좌표
            double defectWidth = Convert.ToDouble(words[4]); // 결함 박스 width
            double defectHeight = Convert.ToDouble(words[5]); // 결함 박스 height
            DefectType type; // 결함 타입

            switch (words[6]) // 결함 타입 문자열을 DefectType enum으로 변환
            {
                case "Pit":
                    type = DefectType.Pit;
                    break;
                case "Discolor":
                    type = DefectType.Discolor;
                    break;
                case "Scratch":
                    type = DefectType.Scratch;
                    break;
                case "Void":
                    type = DefectType.Void;
                    break;
                case "Crack":
                    type = DefectType.Crack;
                    break;
                case "Particle":
                    type = DefectType.Particle;
                    break;
                case "Short":
                    type = DefectType.Short;
                    break;
                default:
                    Console.WriteLine("Error: 추가 실패. 유효하지 않은 DefectType입니다.");
                    return;
            }

            Defect defect = new Defect(x, y, defectWidth, defectHeight, type);
            chip.AddDefect(defect); // 칩에 결함 추가
        }

        // > remove_defect chipID index
        // chipID에 해당하는 칩에서 index 번째 결함 제거
        static void RemoveDefect(string[] words)
        {
            string chipID = words[1];
            Chip chip = FindChip(chipID);

            if (chip == null)
            {
                Console.WriteLine("Error: 삭제 실패. 존재하지 않는 chipID입니다.");
                return;
            }

            chip.RemoveDefect(Convert.ToInt32(words[2])); // index 번째 결함 제거
        }

        // > print chipID
        // chipID에 해당하는 칩의 정보 출력
        static void Print(string[] words)
        {
            string chipID = words[1];
            Chip chip = FindChip(chipID);

            if (chip == null)
            {
                Console.WriteLine("Error: 조회 실패. 존재하지 않는 chipID입니다.");
                return;
            }

            chip.PrintChipInfo(); // 칩 정보 출력
        }
    }
}