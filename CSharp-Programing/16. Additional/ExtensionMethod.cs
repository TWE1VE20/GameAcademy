using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._Additional
{
    internal static class ExtensionMethod
    {
        // <확장메서드>
        // 클래스의 원래 형식을 수정하지 않고도 기존 형식에 함수를 추가할 수 있음
        // 상속을 통하여 만들지 않고도 추가적인 함수를 구현 가능
        // 정적함수에 첫번째 매개변수를 this 키워드 후 확장하고자 하는 자료형을 작성

        public static int WordCount(this string str)    //this 를 넣음으로서 str의 함수처럼 다용되는 느낌으로 만들 수 있다.
        {
            return str.Split(' ').Length;
        }

        public static void Main1()
        {
            string str = "hello world!";

            // 확장메서드를 통하여 기본 string에 없는 함수를 사용 가능
            Console.WriteLine(WordCount(str));      // 정적함수 사용
            Console.WriteLine(str.WordCount());     // 확장메서드 표현
            // 위에 this를 뺴고 정적 함수로 사용하더라도 큰 문제는 없다.
        }
    }
}
