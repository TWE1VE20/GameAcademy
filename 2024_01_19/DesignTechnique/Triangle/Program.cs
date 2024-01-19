namespace Triangle
{
    internal class Program
    {
        static void MAX_num(int[,] num, int x, int y, int hight, int sum, ref int MAX) 
        {
            if (y == hight)
            {
                if (sum > MAX) MAX = sum;
                return;
            }
            MAX_num(num, x, y + 1, hight, sum + num[y, x], ref MAX);
            MAX_num(num, x + 1, y + 1, hight, sum + num[y, x], ref MAX);
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int num = int.Parse(input);
            int[,] number = new int[num, num];
            int MAX = 0;

            for (int i = 0; i < num; i++)
            {
                input = Console.ReadLine();
                for (int j = 0; j < i+1; j++)
                    number[i, j] = int.Parse(input.Split(" ")[j]);
            }
            MAX_num(number, 0, 0, num, 0, ref MAX);
            Console.WriteLine(MAX);
        }
    }
}
