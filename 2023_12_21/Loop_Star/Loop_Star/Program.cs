namespace Loop_Star
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StarLoop1();
            StarLoop2();
            StarLoop3();
            StarLoop4();
            StarLoop5();
        }

        static void StarLoop1()
        {
            Console.Write("숫자를 입력하세요: ");
            int num = int.Parse(Console.ReadLine());
            Console.Write("\n");
            for (int i = 0; i < num; i++)
            {
                Console.Write("*");
            }
            Console.Write("\n");
        }

        static void StarLoop2()
        {
            Console.Write("숫자를 입력하세요: ");
            int num = int.Parse(Console.ReadLine());
            Console.Write("\n");
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        static void StarLoop3() {
            Console.Write("숫자를 입력하세요: ");
            int num = int.Parse(Console.ReadLine());
            Console.Write("\n");
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        static void StarLoop4()
        {
            Console.Write("숫자를 입력하세요: ");
            int num = int.Parse(Console.ReadLine());
            Console.Write("\n");
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num - i; j++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        static void StarLoop5()
        {
            Console.Write("숫자를 입력하세요: ");
            int num = int.Parse(Console.ReadLine());
            Console.Write("\n");
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num - i; j++)
                    Console.Write(" ");
                for (int j = 0; j <= i*2; j++)
                    Console.Write("*");
                Console.Write("\n");
            }
            for (int i = num; i >= 0; i--)
            {
                for (int j = 0; j < num - i; j++)
                    Console.Write(" ");
                for (int j = 0; j <= i * 2; j++)
                    Console.Write("*");
                Console.Write("\n");
            }
            Console.Write("\n");
        }
    }

}
