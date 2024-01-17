using System.Drawing;

namespace AssignmentPriority
{
    internal class Program
    {
        static public int Assignmentpriority(int num, List<int> time, List<int> point)
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            int total = 0;

            for (int i = time.Max(); i > 0; i--) 
            {
                for (int j = 0; j < num; j++)
                {
                    if (time[j] == i)
                    {
                        pq.Enqueue(point[j], -(point[j]));
                    }
                }
                if (pq.Count != 0)
                    total += pq.Dequeue();
            }
            return total;
        }

        static void Main(string[] args)
        {
            List<int> time = new List<int>();
            List<int> point = new List<int>();

            //Console.Write("과제 갯수 : ");
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                //Console.Write($"{i+1}번 과제의 남은 시간과 점수 : ");
                string input = Console.ReadLine();
                time.Add(int.Parse((input.Split(" "))[0]));
                point.Add(int.Parse((input.Split(" "))[1]));
            }

            /*
            for (int i = 0; i < num; i++)
            {
                Console.Write($"{time[i]} ");
                Console.WriteLine(point[i]);
            }
            */

            Console.WriteLine(Assignmentpriority(num, time, point));
        }
    }
}
