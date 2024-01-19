namespace DesignTechnique
{
    internal class NANDM
    {
        static void NandM(int N, int M, List<int> print) 
        {
            if (M == 0)
            {
                Console.WriteLine(string.Join(",", print));
                return;
            }
            else
            {
                for (int i = 0; i < N; i++) 
                {
                    List<int> printist;
                    if (print == null) printist = new List<int>();
                    else printist = print.ToList();
                    printist.Add(i+1);
                    NandM(N, M - 1, printist);
                }
            }
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            NandM(int.Parse(input.Split(" ")[0]),int.Parse(input.Split(" ")[1]), null);
        }
    }
}
