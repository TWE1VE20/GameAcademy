namespace JosephusProblem
{
    internal class Program
    {

        static void Main(string[] args)
        {
            LinkedList<int> ints = new LinkedList<int>();
            List<int> result = new List<int>();

            int length;
            int del;
            string input;
            do
            {
                Console.Write("숫자 입력 : ");
                input = Console.ReadLine();
            }
            while (!(int.TryParse(input, out length)));
            do
            {
                Console.Write("제거 순서 숫자 입력 : ");
                input = Console.ReadLine();
            }
            while (!(int.TryParse(input, out del)));

            for (int i = 1; i <= length; i++) ints.AddLast(i);
            //Console.WriteLine(string.Join(",", ints));
            LinkedListNode<int> node = ints.First;

            while (ints.First != null)
            {
                for (int i = del - 1; i > 0; i--)
                    if (node != ints.Last) node = node.Next;
                    else node = ints.First;
                result.Add(node.Value);
                if (node != ints.Last) node = node.Next;
                else node = ints.First;
                ints.Remove(result[result.Count - 1]);
            }

            Console.WriteLine(string.Join(",", result));
        }
    }
}
