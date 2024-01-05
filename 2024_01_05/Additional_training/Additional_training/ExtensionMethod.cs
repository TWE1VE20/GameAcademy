namespace Additional_training
{
    internal static class ExtensionMethod
    {
        /*
         *  <확장메서드>
            int 또는 string 자료형에 확장메서드로 추가기능을 붙여보자
            int value = 3;				string str = “abc def ghi”;
            bool isEven = value.IsEven();   ->     int wordCount = str.WordCount();
         */

        public static int WordCount(this string str)
        {
            return str.Split(' ').Length;
        }

        public static bool isEven(this int num1, int num2)
        {
            return num1 == num2;
        }

        static void Main(string[] args)
        {
            string str = "hello world!";
            int num1 = 10;
            int num2 = 11;
            int num3 = 10;

            Console.WriteLine(WordCount(str));
            Console.WriteLine(str.WordCount());

            Console.WriteLine(num1.isEven(num2));
            Console.WriteLine(num1.isEven(num3));
        }
    }
}
