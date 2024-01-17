using System.Collections.Generic;

namespace MinMeetingRoom
{
    internal class Program
    {
        static int MeetingRoom(int num, List<int> Stime, List<int> Etime) 
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            List<int> start = Stime;
            List<int> end = Etime;
            int time = 0;
            int index;
            int room = 0;
            int count = 0;

            for (int i = num; i > 0; i--) 
            {
                List<int> indexs = new List<int>();
                if (start.Count != 0)
                    room++;
                time = 0;
                for (int j = 0; j < start.Count; j++)
                    pq.Enqueue(j, start[j]);
                while (pq.Count != 0)
                {
                    if (time <= pq.Peek())
                    {
                        index = pq.Dequeue();
                        time = end[index];
                        indexs.Add(index);
                        Console.WriteLine(time);
                    }
                    else
                    {
                        pq.Dequeue();
                    }
                }
                count = 0;
                foreach (int indx in indexs)
                {
                    Console.Write($"[{start[indx - count]} {end[indx - count]}]");
                    start.RemoveAt(indx-count);
                    end.RemoveAt(indx-count);
                    count++;
                }
                Console.WriteLine();
            }
            return room;
        }

        static void Main(string[] args)
        {
            List<int> Stime = new List<int>();
            List<int> Etime = new List<int>();

            Console.Write("회의실 갯수 : ");
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                Console.Write($"{i+1}번 회의의 시작시간 끝나는 시간 : ");
                string input = Console.ReadLine();
                Stime.Add(int.Parse((input.Split(" "))[0]));
                Etime.Add(int.Parse((input.Split(" "))[1]));
            }

            for (int i = 0; i < num; i++)
            {
                Console.Write($"{Stime[i]} ");
                Console.WriteLine(Etime[i]);
            }

            Console.WriteLine(MeetingRoom(num, Stime, Etime));
        }
    }
}
