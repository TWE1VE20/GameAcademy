/*************************************************** 
 * 주석 (Comment)
 * 
 * 소스 코드에 영향을 주지 않는 텍스트
 * 소스 코드에 대한 의도를 설명하기 위한 용도로 사용
 ***************************************************/

// <주석 종류>
//  //      : 한줄 주석 : // 이후 텍스트를 주석으로 취급
//  /**/    : 범위 주석 : 시작(/*)에서 끝(*/)까지 텍스트를 주석으로 취급
//  ///     : 문서 주석 : 함수 또는 클래스 앞에서 /// 입력으로 자동완성 및 통합개발환경(IDE)에서 정보표시기능


/************************************************************* 
 * 네임스페이스 (Namespace)
 * 
 * 기능이나 구분이 비슷한 기능들을 하나의 이름 아래 묶는 기능
 * 수많은 클래스 사용에 혼란이 적도록 용도/분야 별로 정리
 *************************************************************/

/******************************************************
 * Using 지시문
 * 
 * 소스코드의 상단부에 위치하며 네임스페이스를 선언함
 * 선언 이후 소스코드에서 네임스페이스 안의 기능을 사용
 ******************************************************/

using System;

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

            // <표준 입출력>
            // 콘솔 : 컴퓨터와 사용자가 텍스트 형태로 소통하기 위한 수단
            // Console.WriteLine    : 콘솔에 출력하고 줄 바꿈
            // Console.Write        : 콘솔에 출력하고 줄 바꾸지 않음
            // Console.ReadLine     : 콘솔을 통해 한줄 입력받기
            // Console.ReadKey      : 콘솔을 통해 한키 입력받기

            Console.WriteLine("줄바꿈 있는 출력");
            Console.Write("줄 바꿈 없이 출력"); // 줄바꿈 없이 쓰기
            Console.WriteLine("\n 줄바꿈 \n");
            Console.WriteLine("줄바꿈 완료");

            Console.ReadLine();                 //콘솔을 통해 한줄 입력받기

            Console.Write("키를 입력하세요 : ");
            Console.ReadKey();                  //콘솔을 통해 한키 입력받기

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
    //예시 CLASS  무시할것
    internal class IOCP { }
    internal class delay { }
}