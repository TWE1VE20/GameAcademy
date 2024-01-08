using System;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BullsAndCows
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            int turn = 1;
            int strike = 0;
            int ball = 0;
            string player;
            string com;
            List<int> list = new List<int>();

            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                int randNumber = rand.Next(1, 10);
                if (list.Contains(randNumber))
                    i--;
                else
                    list.Add(randNumber);
            }
            com = string.Join("", list);
            // Cheat
            Console.Write(string.Join("", list)); Console.WriteLine();

            Title();
            while (turn < 11) 
            {
                Turn(turn);
                Console.Write("숫자를 입력하세요 : ");
                player = Console.ReadLine();
                strike = Strike(player, com);
                if (strike == 4) 
                {
                    Console.WriteLine("Home run!");
                    break;
                }
                ball = Ball(player, com);
                Console.WriteLine($"Strike : {strike} Ball : {ball}");
                Console.WriteLine();
                turn++;
            }
            if (turn >= 11)
            {
                Console.WriteLine("패배했습니다...");
                return;
            }
            Console.WriteLine("승리했습니다!");
        }

        static void Title() {
            for (int i = 0; i < 35; i++) Console.Write("*"); Console.WriteLine();
            for (int i = 0; i < 12; i++) Console.Write("*");
            Console.Write(" 숫자 야구 ");
            for (int i = 0; i < 12; i++) Console.Write("*"); Console.WriteLine();
            for (int i = 0; i < 35; i++) Console.Write("*"); Console.WriteLine();
            Console.WriteLine(); Console.WriteLine();
        }

        static void Turn(int num) {
            for (int i = 0; i < 11; i++) Console.Write("=");
            Console.Write($" {num} 번째 기회");
            for (int i = 0; i < 11; i++) Console.Write("="); Console.WriteLine();
        }

        static int Strike(string player_num, string com_num) 
        {
            int strike = 0;
            for (int i = 0; i < 4; i++) {
                if (player_num[i] == com_num[i])
                    strike++;
            }
            return strike;
        }

        static int Ball(string player_num, string com_num)
        {
            int ball = 0;
            foreach (char num in player_num) 
            {
                for (int i = 0; i < 4; i++)
                    if (num == com_num[i])
                        ball++;
            }
            return ball;
        }
    }
}
