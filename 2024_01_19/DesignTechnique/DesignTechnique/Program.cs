using System.Text;

namespace DesignTechnique
{
    internal class NANDM
    {
        static void NandM(int N, int M, StringBuilder print, int[] ints) 
        {
            if (M == 0)
            {
                print.AppendLine(string.Join(" ", ints));
                return;
            }
            else if (ints == null)
            {
                ints = new int[M];
                NandM(N, M, print, ints);
            }
            else
            {
                for (int i = 0; i < N; i++) 
                {
                    ints[ints.Length - M] = i+1;
                    NandM(N, M - 1, print, ints);
                }
            }
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder print = new StringBuilder();
            NandM(int.Parse(input.Split(" ")[0]),int.Parse(input.Split(" ")[1]), print, null);
            Console.WriteLine(print);
        }
    }
}
