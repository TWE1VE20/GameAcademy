using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Additional_training
{
    internal class Parameter
    {
        /*
            <매개변수 ref>
            public static void Swap<일반화>(left, right) 함수
            어떤 자료형이 들어오더라도 두 매개변수를 원본을 교체하는 함수
         */
        public static void Swap<T>(ref T left, ref T right) 
        {
            T buf = left;
            left = right;
            right = buf;
        }


        static void Main(string[] args)
        {
            int left1 = 10;
            int right1 = 20;
            string left2 = "왼쪽";
            string right2 = "오른쪽";

            Swap<int>(ref left1, ref right1);
            Console.WriteLine($"{left1}, {right1}");

            Swap<string>(ref left2, ref right2);
            Console.WriteLine($"{left2}, {right2}");
        }
    }
}
