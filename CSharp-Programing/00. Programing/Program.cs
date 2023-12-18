/*************************************************** 
 * 주석 (Comment)
 * 
 * 소스 코드에 영향을 주지 않는 텍스트
 * 소스 코드에 대한 의도를 설명하기 위한 용도로 사용
 ***************************************************/
// 당연히 namespace를 구분하지않고 같은 이름의 기능을 사용하면 오류를 낼수있기에 주의

namespace _00._Programing
{
    internal class Program
    {
        /// <param name="args">여기에는 매개변수 작성</param>
        // name속 parameter에 대한 설명 작성 가능


        Taek.Program p; // 다른 namespace에서 기능을 불러올때

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Hello, World!"); //옆처럼 빨강색을 띄워두면 여기서 디버깅중 멈춰서 상태확인 가능
            Console.WriteLine("Hello, World!");

        }
    }
}

namespace Taek
{
    internal class Program
    {

    }
}

namespace Network
{
    internal class IOCP { }
    internal class delay { }
}