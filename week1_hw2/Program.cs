using System;

namespace week1_hw2
{
    /*
    create chipID width height
    add chipID x y w h type
    remove chipID index
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

                if (words[0] == "create")
                    Create(words);
                else if (words[0] == "add")
                    Add(words);
                else if (words[0] == "remove")
                    Remove(words);
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

        // > create chipID width height
        static void Create(string[] words)
        {
            string chipID = words[1];
            double width = Convert.ToDouble(words[2]);
            double height = Convert.ToDouble(words[3]);

            chips[chipCount] = new Chip(chipID, width, height);
            chipCount++;

            Console.WriteLine($"Log: {chipID} 칩을 생성함. (Width={width}, Height={height})");
        }

        // > add chipID x y w h type
        static void Add(string[] words)
        {
            string chipID = words[1];
            Chip chip = FindChip(chipID);

            double x = Convert.ToDouble(words[2]); // x 좌표
            double y = Convert.ToDouble(words[3]); // y 좌표
            double w = Convert.ToDouble(words[4]); // 결함 박스 width
            double h = Convert.ToDouble(words[5]); // 결함 박스 height
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
                default:
                    type = DefectType.Short;
                    break;
            }

            Defect defect = new Defect(x, y, w, h, type);
            chip.AddDefect(defect); // 칩에 결함 추가
        }

        // > remove chipID index
        static void Remove(string[] words)
        {
            string chipID = words[1];
            Chip chip = FindChip(chipID);

            chip.RemoveDefect(Convert.ToInt32(words[2])); // index 번째 결함 제거
        }

        // > print chipID
        static void Print(string[] words)
        {
            string chipID = words[1];
            Chip chip = FindChip(chipID);

            chip.PrintChipInfo(); // 칩 정보 출력
        }
    }
}
