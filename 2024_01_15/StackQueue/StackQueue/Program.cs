using System.Linq;

namespace StackQueue
{
    internal class Program
    {
        static public bool BracketChecker(string check) 
        {
            if (check == null)
                return true;
            Stack<char> stack1 = new Stack<char>();
            foreach (char str in check)
            {
                switch (str)
                {
                    case '(':
                    case '[':
                    case '{':
                        stack1.Push(str);
                        break;
                    case ')':
                        if (stack1.Count != 0 && stack1.Pop() != '(') return false;
                        break;
                    case ']':
                        if (stack1.Count != 0 && stack1.Pop() != '[') return false;
                        break;
                    case '}':
                        if (stack1.Count != 0 && stack1.Pop() != '{') return false;
                        break;
                    default:
                        break;
                }
            }
            return true;
        }

        static public int[] Process(int[] check) {
            Queue<int> queue = new Queue<int>();
            List<int> list = new List<int>();
            int buf = 0; int work = -1;
            foreach (int time in check)
                queue.Enqueue(time);
            while (true) {
                for (int quota = 0; quota < 8; quota++) 
                {
                    if (buf == 0)
                    {
                        work += 1;
                        if (queue.Count == 0) 
                            return list.ToArray();
                        buf = queue.Dequeue();
                    }
                    buf -= 1;
                }
                list.Add(work);
            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("[]{}()를 이용해 입력해주세요");
            string input = Console.ReadLine();

            if (BracketChecker(input)) Console.WriteLine("완성되어 있습니다.");
            else Console.WriteLine("미완성입니다.");

            List<int> schedule = new List<int>();

            Console.WriteLine("스캐줄을 입력해주세요");
            input = Console.ReadLine();
            foreach (string ints in input.Split(" "))
                schedule.Add(int.Parse(ints));
            Console.Write(string.Join(", ", Process(schedule.ToArray())));
        }
    }
}
