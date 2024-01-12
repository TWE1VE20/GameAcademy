namespace BalloonPop
{
    internal class Program
    {

        static void Main(string[] args)
        {
            LinkedList<int> ints = new LinkedList<int>();
            List<int> balloons = new List<int>();
            List<int> result = new List<int>();

            int length;
            int del;
            string input;
            do
            {
                Console.Write("풍선의 갯수 입력 : ");
                input = Console.ReadLine();
            }
            while (!(int.TryParse(input, out length)));
            for (int i = 1; i <= length; i++) balloons.Add(i);

            for (int i = 0; i < length; i++)
            {
                do
                {
                    Console.Write($"{i + 1}번쨰 풍선 내 숫자 입력 : ");
                    input = Console.ReadLine();
                }
                while (!(int.TryParse(input, out del)));
                if (Math.Abs(del) > length || Math.Abs(del) == 0) i--;
                ints.AddLast(del);
            }
            Console.WriteLine(string.Join(",", ints));

            del = 1;
            LinkedListNode<int> node = ints.First;
            LinkedListNode<int> bufnode = ints.First;

            while (ints.First != null)
            {
                if (del > 0)
                {
                    for (int i = del - 1; i > 0; i--)
                        if (node != ints.Last) node = node.Next;
                        else node = ints.First;
                    result.Add(node.Value);
                    if (node != ints.Last) node = node.Next;
                    else node = ints.First;
                    ints.Remove(result[result.Count - 1]);
                }
                else
                {
                    for (int i = del - 1; i > 0; i--)
                        if (node != ints.First) node = node.Previous;
                        else node = ints.Last;
                    result.Add(node.Value);
                    if (node != ints.First) node = node.Previous;
                    else node = ints.Last;
                    ints.Remove(result[result.Count - 1]);
                }
            }

            Console.WriteLine(string.Join(",", result));
        }
    }
}

