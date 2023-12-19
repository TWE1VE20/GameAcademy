namespace Charactor_Selection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int level;
            int hp;

            Console.WriteLine("<캐릭터 생성창>\n");

            Console.Write("이름을 입력하세요: ");
            string name = Console.ReadLine();
            Console.Write("직업을 입력하세요: ");
            string job = Console.ReadLine();
            Console.Write("레벨을 입력하세요: ");
            level = int.Parse(Console.ReadLine());
            Console.Write("체력을 입력하세요: ");
            hp = int.Parse(Console.ReadLine());
            
            /*
            Console.Write("레벨을 입력하세요: ");
            while (!(int.TryParse(Console.ReadLine(), out level)))
                Console.Write("숫자가 아닙니다. 레벨을 다시 입력하세요: ");
            Console.Write("체력을 입력하세요: ");
            while (!(int.TryParse(Console.ReadLine(), out hp)))
                Console.Write("숫자가 아닙니다. 체력을 다시 입력하세요: ");
            */

            Console.WriteLine($"\n선택하신 캐릭터는\n이름 : {name}");
            Console.WriteLine($"직업 : {job}");
            Console.WriteLine($"레벨 : {level}");
            Console.WriteLine($"체력 : {hp}");
        }
    }
}
