using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2_hw2
{
    /*
    create_die dieID dieWidth dieHeight
    remove_die dieID
    add_defect dieID x1 y1 x2 y2 defectType
    remove_defect dieID index
    export dieID filePath
    exit
    */

    internal class Program
    {
        static List<Die> dies = new List<Die>(); // 다이 객체를 저장할 리스트

        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.Write("\n> ");
                    string text = Console.ReadLine();
                    string[] words = text.Split(' ');

                    try
                    {
                        if (words[0] == "create_die")
                            CreateDie(words);
                        else if (words[0] == "remove_die")
                            RemoveDie(words);
                        else if (words[0] == "add_defect")
                            AddDefect(words);
                        else if (words[0] == "remove_defect")
                            RemoveDefect(words);
                        else if (words[0] == "export")
                            ExportMask(words);
                        else if (words[0] == "exit")
                            break;
                        else
                            Logger.Log("Error", words[0], "존재하지 않는 명령어입니다.");
                    }
                    catch (FormatException)
                    {
                        Logger.Log("Error", words[0], "숫자를 입력해야 하는 자리에 숫자가 아닌 값이 입력됨.");
                    }
                    catch (OverflowException)
                    {
                        Logger.Log("Error", words[0], "입력한 숫자가 너무 크거나 작습니다.");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Logger.Log("Error", words[0], "명령어의 인자 개수가 부족함.");
                    }
                }

                Logger.Log("Log", "exit", "프로그램 종료.");
            }
            finally
            {
                Logger.Wait(); // 정상 종료든, 처리하지 못한 예외로 죽든 항상 실행되어 파일 쓰기를 마무리함
            }
        }

        // dieID로 다이를 찾는 메서드 (없으면 null 반환)
        static Die FindDie(string dieID)
        {
            foreach (Die die in dies)
            {
                if (die.DieID == dieID)
                {
                    return die;
                }
            }

            return null;
        }

        // > create_die dieID dieWidth dieHeight
        // dieID, dieWidth, dieHeight를 전달받아 다이 생성
        static void CreateDie(string[] words)
        {
            string dieID = words[1]; // 생성할 다이의 ID (dieID)
            int dieWidth = Convert.ToInt32(words[2]); // 생성할 다이의 너비 (dieWidth)
            int dieHeight = Convert.ToInt32(words[3]); // 생성할 다이의 높이 (dieHeight)

            Die die = new Die(dieID, dieWidth, dieHeight); // Die 객체 생성
            die.Notify += (sender, e) => Logger.Log(e.Type, e.Command, e.Message); // Die의 알림을 람다로 구독해서 로깅함

            dies.Add(die); // Add: 리스트에 다이 추가

            Logger.Log("Log", words[0], $"{dieID} 다이를 생성함. (Width={dieWidth}, Height={dieHeight})");
        }

        // > remove_die dieID
        // dieID에 해당하는 다이 제거
        static void RemoveDie(string[] words)
        {
            string dieID = words[1]; // 제거할 다이의 ID (dieID)

            int index = -1;
            for (int i = 0; i < dies.Count; i++)
            {
                if (dies[i].DieID == dieID)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Logger.Log("Error", words[0], "삭제 실패. 존재하지 않는 dieID입니다.");
                return;
            }

            dies.RemoveAt(index); // RemoveAt: 리스트에서 특정 인덱스의 요소 제거

            Logger.Log("Log", words[0], $"{dieID} 다이를 제거함.");
        }

        // > add_defect dieID x1 y1 x2 y2 defectType
        // dieID에 해당하는 다이에 결함 추가
        static void AddDefect(string[] words)
        {
            string dieID = words[1]; // 결함을 추가할 다이의 ID (dieID)
            Die die = FindDie(dieID);

            if (die == null)
            {
                Logger.Log("Error", words[0], "추가 실패. 존재하지 않는 dieID입니다.");
                return;
            }

            int x1 = Convert.ToInt32(words[2]); // 결함 박스 첫 번째 꼭짓점 x 좌표 (x1)
            int y1 = Convert.ToInt32(words[3]); // 결함 박스 첫 번째 꼭짓점 y 좌표 (y1)
            int x2 = Convert.ToInt32(words[4]); // 결함 박스 두 번째 꼭짓점 x 좌표 (x2)
            int y2 = Convert.ToInt32(words[5]); // 결함 박스 두 번째 꼭짓점 y 좌표 (y2)
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
                    Logger.Log("Error", words[0], "추가 실패. 유효하지 않은 DefectType입니다.");
                    return;
            }

            Defect defect = new Defect(x1, y1, x2, y2, type);
            die.AddDefect(defect, words[0]); // 다이에 결함 추가
        }

        // > remove_defect dieID index
        // dieID에 해당하는 다이에서 index 번째 결함 제거
        static void RemoveDefect(string[] words)
        {
            string dieID = words[1]; // 제거할 결함이 있는 다이의 ID (dieID)
            Die die = FindDie(dieID);

            if (die == null)
            {
                Logger.Log("Error", words[0], "삭제 실패. 존재하지 않는 dieID입니다.");
                return;
            }

            die.RemoveDefect(Convert.ToInt32(words[2]), words[0]); // index 번째 결함 제거
        }

        // > export dieID filePath
        // dieID에 해당하는 다이의 결함 박스 마스크를 filePath 파일로 저장
        static void ExportMask(string[] words)
        {
            string dieID = words[1]; // 저장할 결함 박스 마스크가 있는 다이의 ID (dieID)
            Die die = FindDie(dieID);

            if (die == null)
            {
                Logger.Log("Error", words[0], "저장 실패. 존재하지 않는 dieID입니다.");
                return;
            }

            string filePath = words[2]; // 저장할 파일 경로 (filePath)
            die.ExportDefectMask(filePath, words[0]); // 결함 박스 마스크 파일로 저장
        }
    }
}
