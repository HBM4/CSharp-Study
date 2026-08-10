namespace Ch30_GetNumberFromUser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = GetNumberFromUser();
            Console.WriteLine($"사용자가 입력한 숫자: {number}");
        }

        static int GetNumberFromUser()
        {
            int usersNumber = 0;

            while (usersNumber < 1 || usersNumber > 10)
            {
                try
                {
                    Console.Write("1에서 10 사이의 숫자를 입력하세요: ");
                    string usersResponse = Console.ReadLine();

                    usersNumber = Convert.ToInt32(usersResponse);
                }
                catch (FormatException)
                {
                    Console.WriteLine("유효한 숫자를 입력하세요.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("int 범위로 입력하세요.");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"알 수 없는 예외 발생: {e.Message}");
                }
                finally
                {
                    Console.WriteLine("숫자 입력 시도 완료.");
                }
                // 순서대로 체크하므로 순서가 중요하다.
            }
            return usersNumber;
        }
    }
}
