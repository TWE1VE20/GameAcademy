using System;
using System.Runtime.CompilerServices;

namespace Card
{
    internal class Program
    {
        static void Buildnum(int loop, List<int> ints, string num, HashSet<string> Hset)
        {
            if (loop-1 == 0)
            {
                if(!Hset.Contains(num))
                    Hset.Add(num);
                return;
            }
            for(int i = 0; i < ints.Count; i++)
            {
                List<int> inputint = ints.ToList();
                int this_num = inputint[i];
                inputint.RemoveAt(i);
                Buildnum(loop - 1, inputint, num + (Convert.ToString(this_num)), Hset);
            }
        }


        static void Main(string[] args)
        {
            HashSet<string> Hset = new HashSet<string>();
            string input;
            List<int> Cards = new List<int>();

            input = Console.ReadLine();
            int n = int.Parse(input);
            input = Console.ReadLine();
            int k = int.Parse(input);
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                Cards.Add( int.Parse(input));
            }
            for (int i = 0; i < Cards.Count; i++)
            {
                List<int> inputint = Cards.ToList();
                int this_num = inputint[i];
                inputint.RemoveAt(i);
                Buildnum(k, inputint, Convert.ToString(this_num), Hset);
            }
            Console.WriteLine(Hset.Count);
        }
    }
}
