using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1_hw2
{
    /*
    create_die dieID dieWidth dieHeight
    remove_die dieID
    add_defect dieID x y defectWidth defectHeight defectType
    remove_defect dieID index
    print dieID
    exit
    */

    internal class Program
    {
        static Die[] dies = new Die[100];
        static int dieCount = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("\n> ");
                string text = Console.ReadLine();
                string[] words = text.Split(' ');

                if (words[0] == "create_die")
                    CreateDie(words);
                else if (words[0] == "remove_die")
                    RemoveDie(words);
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

        // dieID로 다이를 찾는 메서드 (없으면 null 반환)
        static Die FindDie(string dieID)
        {
            for (int i = 0; i < dieCount; i++)
            {
                if (dies[i].GetDieID() == dieID)
                {
                    return dies[i];
                }
            }

            return null;
        }

        // > create_die dieID dieWidth dieHeight
        // dieID, dieWidth, dieHeight를 전달받아 다이 생성
        static void CreateDie(string[] words)
        {
            string dieID = words[1];
            double dieWidth = Convert.ToDouble(words[2]);
            double dieHeight = Convert.ToDouble(words[3]);

            dies[dieCount] = new Die(dieID, dieWidth, dieHeight);
            dieCount++;

            Console.WriteLine($"Log: {dieID} 다이를 생성함. (Width={dieWidth}, Height={dieHeight})");
        }

        // > remove_die dieID
        // dieID에 해당하는 다이 제거
        static void RemoveDie(string[] words)
        {
            string dieID = words[1];

            int index = -1;
            for (int i = 0; i < dieCount; i++)
            {
                if (dies[i].GetDieID() == dieID)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine("Error: 삭제 실패. 존재하지 않는 dieID입니다.");
                return;
            }

            // 다이 제거 후 배열을 재정렬
            for (int i = index; i < dieCount - 1; i++)
            {
                dies[i] = dies[i + 1]; // 한 칸씩 앞으로 이동
            }

            dies[dieCount - 1] = null; // 마지막 요소를 null로 설정
            dieCount--;

            Console.WriteLine($"Log: {dieID} 다이를 제거함.");
        }

        // > add_defect dieID x y defectWidth defectHeight defectType
        // dieID에 해당하는 다이에 결함 추가
        static void AddDefect(string[] words)
        {
            string dieID = words[1];
            Die die = FindDie(dieID);

            if (die == null)
            {
                Console.WriteLine("Error: 추가 실패. 존재하지 않는 dieID입니다.");
                return;
            }

            double x = Convert.ToDouble(words[2]); // 결함 박스 중앙 x 좌표
            double y = Convert.ToDouble(words[3]); // 결함 박스 중앙 y 좌표
            double defectWidth = Convert.ToDouble(words[4]); // 결함 박스 width
            double defectHeight = Convert.ToDouble(words[5]); // 결함 박스 height
            DefectType type; // 결함 타입

            switch (words[6]) // 결함 타입 문자열을 DefectType enum으로 변환
            {
                case "Bright":
                    type = DefectType.Bright;
                    break;
                case "Dark":
                    type = DefectType.Dark;
                    break;
                case "Stain":
                    type = DefectType.Stain;
                    break;
                case "Scratch":
                    type = DefectType.Scratch;
                    break;
                case "Particle":
                    type = DefectType.Particle;
                    break;
                case "Open":
                    type = DefectType.Open;
                    break;
                case "Bridge":
                    type = DefectType.Bridge;
                    break;
                default:
                    Console.WriteLine("Error: 추가 실패. 유효하지 않은 DefectType입니다.");
                    return;
            }

            Defect defect = new Defect(x, y, defectWidth, defectHeight, type);
            die.AddDefect(defect); // 다이에 결함 추가
        }

        // > remove_defect dieID index
        // dieID에 해당하는 다이에서 index 번째 결함 제거
        static void RemoveDefect(string[] words)
        {
            string dieID = words[1];
            Die die = FindDie(dieID);

            if (die == null)
            {
                Console.WriteLine("Error: 삭제 실패. 존재하지 않는 dieID입니다.");
                return;
            }

            die.RemoveDefect(Convert.ToInt32(words[2])); // index 번째 결함 제거
        }

        // > print dieID
        // dieID에 해당하는 다이의 정보 출력
        static void Print(string[] words)
        {
            string dieID = words[1];
            Die die = FindDie(dieID);

            if (die == null)
            {
                Console.WriteLine("Error: 조회 실패. 존재하지 않는 dieID입니다.");
                return;
            }

            die.PrintDieInfo(); // 다이 정보 출력
        }
    }
}
