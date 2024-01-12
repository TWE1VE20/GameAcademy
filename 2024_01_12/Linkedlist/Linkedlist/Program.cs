using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Xml.Linq;

namespace Linkedlist
{
    internal class Program
    {
        static void PrintLinkedList(LinkedList<int> LL) 
        {
            if(LL.First is null) return;
            Console.WriteLine(string.Join(",", LL));
        }

        static void Main(string[] args)
        {
            LinkedList<int> ints = new LinkedList<int>();

            while (true) {
                int num;
                string input;
                do
                {
                    Console.Write("숫자 입력 : ");
                    input = Console.ReadLine();
                    if (input == "e" || input == "E")
                        Environment.Exit(0);
                }
                while (!(int.TryParse(input, out num)));

                if (ints.First == null) { ints.AddFirst(num); PrintLinkedList(ints); continue; }
                if (num == ints.First.Value) { PrintLinkedList(ints); continue; }
                if (num == ints.Last.Value) { PrintLinkedList(ints); continue;}
                if (ints.First == ints.Last) { ints.AddLast(num); PrintLinkedList(ints); continue; }
                if (ints.First.Value > num) { ints.AddFirst(num); PrintLinkedList(ints); continue; }
                if (ints.Last.Value < num) { ints.AddLast(num); PrintLinkedList(ints); continue; }
                for (LinkedListNode<int> node = ints.First; node != null; node = node.Next)
                {
                    if (node.Value == num)
                        break;
                    else if (node.Value < num && node.Next.Value > num)
                        ints.AddAfter(node, num);
                }

                PrintLinkedList(ints);
            }
        }
    }
}
