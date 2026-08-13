using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2_hw2
{
    // Die가 이벤트로 알림을 보낼 때 함께 전달하는 정보 (Logger.LogHandler와 같은 모양)
    internal class DieEventArgs : EventArgs
    {
        public string Type { get; } // "Log" 또는 "Error"
        public string Command { get; } // 이 알림을 발생시킨 명령어 (add_defect 등)
        public string Message { get; } // 알림 내용

        public DieEventArgs(string type, string command, string message)
        {
            Type = type;
            Command = command;
            Message = message;
        }
    }

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

        // Die 내부에서 결함 추가/제거, 마스크 Export 등의 작업이 일어날 때, 외부에서 이를 알 수 있도록 이벤트를 발생시킴.
        public event EventHandler<DieEventArgs> Notify;

        // Die 내부에서 Notify 이벤트를 발생시키는 메서드
        private void OnNotify(string type, string command, string message)
        {
            if (Notify != null)
                Notify(this, new DieEventArgs(type, command, message)); // DieEventArgs 객체를 생성하여 이벤트 핸들러에 전달
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
        public void AddDefect(Defect defect, string command)
        {
            // 결함 박스가 다이 경계를 벗어나는지 확인
            int x1 = defect.X1;
            int y1 = defect.Y1;
            int x2 = defect.X2;
            int y2 = defect.Y2;

            if (x1 > x2 || y1 > y2)
            {
                OnNotify("Error", command, "추가 실패. 결함 좌표 순서가 올바르지 않음.");
                return;
            }

            if (x1 < 0 || x2 >= Width || y1 < 0 || y2 >= Height)
            {
                OnNotify("Error", command, "추가 실패. 결함 박스가 다이 경계를 벗어남.");
                return;
            }

            defects.Add(defect); // Add: 리스트에 결함 추가

            OnNotify("Log", command, $"{DieID}에 {DefectCount}번째 결함을 추가함. (Type={defect.Type}, X1={x1}, Y1={y1}, X2={x2}, Y2={y2})");
        }

        // Die에 Defect 제거하는 메서드
        public void RemoveDefect(int index, string command)
        {
            if (index < 0 || index >= DefectCount)
            {
                OnNotify("Error", command, "삭제 실패. 유효하지 않은 결함 인덱스를 입력함.");
                return;
            }

            defects.RemoveAt(index); // RemoveAt: 리스트에서 특정 인덱스의 요소 제거

            OnNotify("Log", command, $"{index + 1}번째 결함을 제거함.");
        }

        // 결함 박스가 차지하는 픽셀을 1로, 나머지를 0으로 표시한 격자를 파일로 저장하는 메서드
        public void ExportDefectMask(string filePath, string command)
        {
            byte[,] mask = new byte[Height, Width]; // 값이 0/1뿐이므로 int 대신 byte 사용 (칸당 1바이트로 메모리 절약)

            foreach (Defect defect in defects)
            {
                for (int row = defect.Y1; row <= defect.Y2; row++)
                {
                    if (row < 0 || row >= Height) // 다이 경계를 벗어난 결함 박스는 무시
                        continue;

                    for (int col = defect.X1; col <= defect.X2; col++)
                    {
                        if (col < 0 || col >= Width)
                            continue;

                        // 박스의 맨 윗줄/맨 아랫줄/왼쪽 끝/오른쪽 끝(테두리)에 해당하는 픽셀만 1 표시
                        if (row == defect.Y1 || row == defect.Y2 || col == defect.X1 || col == defect.X2)
                            mask[row, col] = 1;
                    }
                }
            }

            // 한 줄(row)마다 픽셀 값을 탭 문자로 이어붙여서 파일에 쓸 문자열 배열 생성
            // 탭으로 구분해야 엑셀에 붙여넣었을 때 칸(cell)이 자동으로 나뉨 (쉼표는 한 셀에 통째로 들어감!)
            string[] lines = new string[Height];
            for (int row = 0; row < Height; row++)
            {
                string line = "";
                for (int col = 0; col < Width; col++)
                {
                    line += mask[row, col];
                    if (col < Width - 1)
                        line += "\t";
                }
                lines[row] = line;
            }

            File.WriteAllLines(filePath, lines);

            OnNotify("Log", command, $"{DieID}의 결함 박스 마스크를 {filePath}에 저장함.");
        }
    }
}
