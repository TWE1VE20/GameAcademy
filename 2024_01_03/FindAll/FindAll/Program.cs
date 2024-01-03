using System.Reflection.Metadata.Ecma335;

namespace FindAll
{
    internal class Program
    {
        public static int[] FindALL(int[] array, Predicate<int> predicate) {
            int[] result = new int[array.Length];
            int loop = 0;
            for(int i = 0; i < array.Length; i++)
            {
                if (predicate(array[i])) 
                {
                    result[loop] = array[i];
                    loop++;
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] index = FindALL(array, x => x < 5);
            foreach (var value in index)
            {
                Console.Write(value);
            }
        }
    }
}
