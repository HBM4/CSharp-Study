using System;                       // System 네임스페이스 사용 선언: Console 등 기본 기능 제공
using System.Collections.Generic;   // 제네릭 컬렉션(List, Dictionary 등) 사용을 위한 선언
using System.Linq;                  // 데이터 쿼리(LINQ) 기능 사용을 위한 선언
using System.Text;                  // 문자열 처리 기능 사용을 위한 선언
using System.Threading.Tasks;       // 비동기 작업(Task) 기능 사용을 위한 선언

namespace Ch04_P21                  // 이 코드가 속한 네임스페이스(가장 큰 코드 그룹화 단위)
{
    internal class Program          // Program 클래스: 메서드들을 묶는 코드 단위
    {
        static void Main(string[] args)  // Main 메서드: 프로그램의 시작점, 여기서부터 실행됨
        {
            Console.WriteLine("Hello, World!");  // 콘솔 화면에 "Hello, World!" 문자열을 출력
        }   // Main 메서드 끝
    }   // Program 클래스 끝
}   // Ch04_P21 네임스페이스 끝