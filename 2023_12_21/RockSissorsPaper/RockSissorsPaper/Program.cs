namespace RockSissorsPaper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int pWin = 0;
            int cWin = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("** * * * * * * * **");
                Console.WriteLine("* 가위바위보 게임 *");
                Console.WriteLine("* * * * * * * * * *");
                Thread.Sleep(300);
                Console.Clear();
                Console.WriteLine("* * * * * * * * * *");
                Console.WriteLine("* 가위바위보 게임 *");
                Console.WriteLine("** * * * * * * * **");
                Thread.Sleep(300);
                Console.Clear();
            }

            while (true)
            {
                Console.Write("\n뭘 내실건가요? (가위:S, 바위:R, 보:P) : ");
                string player = Console.ReadLine();
                Console.Clear();

                //컴퓨터
                Random rand = new Random();
                int cpu = CpuChoice(rand.Next(1, 99));

                Console.WriteLine("\n가위!");
                Thread.Sleep(300);
                Console.Clear();
                Console.WriteLine("\n바위!");
                Thread.Sleep(300);
                Console.Clear();
                Console.WriteLine("\n보!");
                Thread.Sleep(300);
                Console.Clear();

                switch (player)
                {
                    case "S":
                    case "s":
                        Console.WriteLine($"\n플래이어 : 가위       컴퓨터 : {Cpu_char(cpu)}");
                        if (DidWin(0, cpu) == 1)
                        {
                            count++;
                            Console.WriteLine($"이겼습니다! {++pWin} 대 {cWin}");
                        }
                        else if (DidWin(0, cpu) == 2)
                        {
                            count++;
                            Console.WriteLine($"졌습니다~ {pWin} 대 {++cWin}");
                        }
                        else
                        {
                            Console.WriteLine($"비겼습니다 다시한번~ {pWin} 대 {cWin}");
                        }
                        break;
                    case "R":
                    case "r":
                        Console.WriteLine($"\n플래이어 : 바위       컴퓨터 : {Cpu_char(cpu)}");
                        if (DidWin(1, cpu) == 1)
                        {
                            count++;
                            Console.WriteLine($"이겼습니다! {++pWin} 대 {cWin}");
                        }
                        else if (DidWin(1, cpu) == 2)
                        {
                            count++;
                            Console.WriteLine($"졌습니다~ {pWin} 대 {++cWin}");
                        }
                        else
                        {
                            Console.WriteLine($"비겼습니다 다시한번~ {pWin} 대 {cWin}");
                        }
                        break;
                    case "P":
                    case "p":
                        Console.WriteLine($"\n플래이어 : 보         컴퓨터 : {Cpu_char(cpu)}");
                        if (DidWin(2, cpu) == 1)
                        {
                            count++;
                            Console.WriteLine($"이겼습니다! {++pWin} 대 {cWin}");
                        }
                        else if (DidWin(2, cpu) == 2)
                        {
                            count++;
                            Console.WriteLine($"졌습니다~ {pWin} 대 {++cWin}");
                        }
                        else
                        {
                            Console.WriteLine($"비겼습니다 다시한번~ {pWin} 대 {cWin}");
                        }
                        break;
                }
                Thread.Sleep(500);
                if (pWin == 3 || cWin == 3)
                    break;
            }

            if (pWin == 3)
                Console.WriteLine("\n가위바위보 게임에서 승리하셨습니다!");
            else
                Console.WriteLine("\n가위바위보 게임에서 졌습니다.");
        }

        static int CpuChoice(int num) {
            if (num < 33)
                return 0;
            else if (num >= 33 && num < 66)
                return 1;
            else
                return 2;
        }

        static string Cpu_char(int num) {
            if (num == 0)
                return ("가위");
            else if (num == 1)
                return ("바위");
            else
                return ("보");
        }

        static short DidWin(int p, int c) {
            if (p == c)
                return (0);
            else if (c == p + 1 || (c == 0 && p == 2))
                return (2);
            else
                return (1);
        }
    }
}
