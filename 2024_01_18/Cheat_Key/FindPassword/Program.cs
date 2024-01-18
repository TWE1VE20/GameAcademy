using System.Drawing;

namespace FindPassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int input_num = int.Parse((input.Split(" "))[0]);
            Dictionary<string, string> Password = new Dictionary<string, string>(input_num);
            int pass_num = int.Parse(input);
            string output;
                
            for (int i = 0; i < input_num; i++)
            {
                input = Console.ReadLine();
                Password.Add(input.Split(" ")[0], input.Split(" ")[1]);
            }

            for (int i = 0; i < pass_num; i++)
            {
                input = Console.ReadLine();
                Password.TryGetValue(input, out output);
                Console.WriteLine(output);
            }

        }
    }
}
