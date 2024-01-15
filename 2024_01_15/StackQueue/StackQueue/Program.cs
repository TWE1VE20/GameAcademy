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
                    case ')':
                    case ']':
                    case '}':
                    default:
                        break;
                }
            }

            for (int i = 0; i < stack1.Count; i++)
                switch (stack1.Pop())
                {
                    case '(':
                        if (stack1.Pop() != ')') return false; break;
                    case '[':
                        if (stack1.Pop() != ']') return false; break;
                    case '{':
                        if (stack1.Pop() != '}') return false; break;
                    default:
                        return false;
                }
            return true;
        }

        static void Main(string[] args)
        {

            Console.WriteLine("[]{}()를 이용해 입력해주세요");
            string input = Console.ReadLine();

            if (BracketChecker(input)) { Console.WriteLine("완성되어 있습니다."); return; }
            Console.WriteLine("미완성입니다.");
        }
    }
}
