namespace ATM
{
    internal class Program
    {
        static int Atm(int Max, int loop, int prvnum, List<int> time) 
        {
            int now = prvnum + time[loop];
            if (loop == Max-1)
                return now;
            return now + Atm(Max, loop+1, now, time);
        }

        static void Main(string[] args)
        {
            List<int> time = new List<int>();
            string input = Console.ReadLine();
            int num = int.Parse(input);

            input = Console.ReadLine();
            for(int i = 0; i < num; i++)
                time.Add(int.Parse(input.Split(" ")[i]));
            time.Sort();
            Console.WriteLine(Atm(num, 0, 0, time));
        }
    }
}
