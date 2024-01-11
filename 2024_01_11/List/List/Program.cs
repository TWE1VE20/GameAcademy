using System.Globalization;

namespace List_assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length;
            string input;
            do
            {
                Console.Write("숫자 입력 : ");
                input = Console.ReadLine();
            }
            while (!(int.TryParse(input, out length)));

            List<int> list1 = new List<int>(length);
            for (int i = 0; i <= length; i++)
                list1.Add(i);

            PrintList(list1);
            list1.Remove(0);
            PrintList(list1);

            int target;
            input = null;
            do
            {
                Console.Write("숫자 입력 (없으면 추가 있으면 삭제): ");
                input = Console.ReadLine();
            }
            while (!(int.TryParse(input, out target)));

            AddORRemove(list1, target);
            PrintList(list1);
        }

        static void PrintList(List<int> list) 
        {
            Console.WriteLine(string.Join(",", list));
        }

        static void AddORRemove(List<int> list, int num)
        {
            if (list.Remove(num))
            {
                list.Add(num);
            }
        }



    }
}
