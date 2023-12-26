using System.Numerics;

namespace RockSissorsPaper2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Opening();
            battle();
        }

        static void Opening() {
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
        }

        static void Battle_start() {
            Console.WriteLine("\n가위!");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("\n바위!");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("\n보!");
            Thread.Sleep(300);
            Console.Clear();
        }

        enum RSP { Rock = 1, Sissors = 2, Paper = 3 , none = -1}

        static RSP p_hand() {
            ConsoleKeyInfo input;
            RSP player;
            input = Console.ReadKey();
            switch (input.KeyChar)
            {
                case '1':
                    player = RSP.Rock;
                    break;
                case '2':
                    player = RSP.Sissors;
                    break;
                case '3':
                    player = RSP.Paper;
                    break;
                default:
                    player = RSP.none;
                    break;
            }
            return player;
        }

        static RSP CpuChoice(int num)
        {
            if (num < 33)
                return RSP.Rock;
            else if (num >= 33 && num < 66)
                return RSP.Sissors;
            else
                return RSP.Paper;
        }

        static void battle() {
            int count = 0;
            int pWin = 0;
            int cWin = 0;
            RSP player;

            Console.WriteLine("\n3번 먼저 인긴 쪽이 승리합니다.");
            Thread.Sleep(800);
            Console.Clear();

            while (true)
            {
                player = RSP.none;

                Console.Write("\n뭘 내실건가요? (가위:1, 바위:2, 보:3) : ");
                player = p_hand();
                while (player == RSP.none) {
                    Console.WriteLine("\n잘못 입력하셨습니다.");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.Write("\n뭘 내실건가요? (가위:1, 바위:2, 보:3) : ");
                    player = p_hand();
                };
                Console.Clear();

                //컴퓨터
                //가위 0, 바위 1, 보 2
                Random rand = new Random();
                RSP cpu = CpuChoice(rand.Next(1, 99));

                Battle_start();

                switch (player)
                {
                    case RSP.Rock:
                        Console.WriteLine($"\n플래이어 : 바위       컴퓨터 : {cpu}");
                        if (cpu == RSP.Sissors)
                        {
                            count++;
                            Console.WriteLine($"이겼습니다! {++pWin} 대 {cWin}");
                        }
                        else if (cpu == RSP.Rock)
                        {
                            count++;
                            Console.WriteLine($"졌습니다~ {pWin} 대 {++cWin}");
                        }
                        else
                        {
                            Console.WriteLine($"비겼습니다 다시한번~ {pWin} 대 {cWin}");
                        }
                        break;
                    case RSP.Sissors:
                        Console.WriteLine($"\n플래이어 : 가위       컴퓨터 : {cpu}");
                        if (cpu == RSP.Paper)
                        {
                            count++;
                            Console.WriteLine($"이겼습니다! {++pWin} 대 {cWin}");
                        }
                        else if (cpu == RSP.Rock)
                        {
                            count++;
                            Console.WriteLine($"졌습니다~ {pWin} 대 {++cWin}");
                        }
                        else
                        {
                            Console.WriteLine($"비겼습니다 다시한번~ {pWin} 대 {cWin}");
                        }
                        break;
                    case RSP.Paper:
                        Console.WriteLine($"\n플래이어 : 보         컴퓨터 : {cpu}");
                        if (cpu == RSP.Rock)
                        {
                            count++;
                            Console.WriteLine($"이겼습니다! {++pWin} 대 {cWin}");
                        }
                        else if (cpu == RSP.Sissors)
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
    }
}
