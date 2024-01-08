using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CS_Applications_Test
{
    internal class Program
    {
        public static int FindKeyIndex(string text, char key) 
        {
            int index = 0;
            foreach (char value in text)
            {
                if(value == key)
                    return index;
                index++;
            }
            return -1;
        }

        public static bool IsPrime(int number) 
        {
            if (number == 1)
                return false;
            for (int i = number-1; i > 1; i--) 
                if (number % i == 0)
                    return false;
            return true;
        }

        public static int SumOfDigits(int number)
        {
            int result = 0;
            string num = number.ToString();
            foreach(int value in num) 
                result += (value)-48;
            return result;
        }

        public static int[] FindCommonItems(int[] array1, int[] array2) 
        {
            List<int> result = new List<int>();
            for (int i = 0; i < array1.Length; i++) 
                for (int j = 0; j < array2.Length; j++)
                    if (array1[i] == array2[j] && !result.Contains(array1[i]))
                        result.Add(array1[i]);
            if (result.Count() == 0)
                return null;
            return result.ToArray();
        }

        public static int FindClosestNumber(int[] array, int number) 
        {
            int result = array[0];
            int howmuch1 = 0;
            int howmuch2 = 0;
            foreach (int value in array) {
                howmuch1 = Math.Abs(result - number);
                howmuch2 = Math.Abs(value - number);
                if (howmuch1 > howmuch2)
                    result = value;
            }
            return result;
        }

        public static int FindModeNumber(int[] array)
        {
            int result = -1;
            int MAX = 0;
            int count = 0;
            List<int> list = array.OrderBy(i => i).ToList();
            foreach(int value in list)
            {
                count = 0;
                if (value == result)
                    continue;
                foreach (int num in list) 
                    if (num == value)
                        count++;
                if (MAX < count) 
                {
                    result = value;
                    MAX = count;
                }
            }
            return result;
        }


        static void Main(string[] args)
        {
            Console.WriteLine(FindKeyIndex("abcdef", 'd'));
            Console.WriteLine(FindKeyIndex("Winner winner chicken dinner", 'c'));
            Console.WriteLine(FindKeyIndex("Not your lucky day", 'p'));
            Console.WriteLine();

            Console.WriteLine(IsPrime(7));
            Console.WriteLine(IsPrime(4));
            Console.WriteLine(IsPrime(1));
            Console.WriteLine();

            Console.WriteLine(SumOfDigits(18234));
            Console.WriteLine(SumOfDigits(3849));
            Console.WriteLine(SumOfDigits(12345));
            Console.WriteLine();

            
            int[] result1 = FindCommonItems([1, 5, 5, 10],[ 3, 5, 5, 10]);
            int[] result2 = FindCommonItems([3, 5, 7, 9], [7, 6, 5, 4]);
            int[] result3 = FindCommonItems([8, 7, 6, 5], [1, 2, 3, 4]);
            ArrayWrite(result1);
            ArrayWrite(result2);
            ArrayWrite(result3);
            Console.WriteLine();

            Console.WriteLine(FindClosestNumber([3, 10, 28], 20));
            Console.WriteLine(FindClosestNumber([10, 11, 12], 15));
            Console.WriteLine(FindClosestNumber([1, 2, 3, 4, 5], 3));
            Console.WriteLine();

            Console.WriteLine(FindModeNumber([1, 2, 3, 3, 3, 4]));
            Console.WriteLine(FindModeNumber([1, 99, 99, 55, 31, 14]));
            Console.WriteLine(FindModeNumber([11]));
        }

        public static void ArrayWrite(int[] array)
        {
            if (array != null) 
            {
                int loop = 0;
                Console.Write("{");
                List<int> list = array.ToList();
                Console.Write(string.Join(", ", list));
                Console.WriteLine("}"); 
                return;
            }
            Console.WriteLine("null");
        }
    }
}
