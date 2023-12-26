using System.Numerics;
using System.Security.Cryptography;
using System.Linq;
using System.Collections;
using System.Xml.Linq;

namespace SlidePuzzle
{
    internal class Program
    {
        public enum MoveDirection { Left, Right, Up, Down, Cheat, None}

        static void Main(string[] args)
        {
            int x = 4, y = 4;
            int[,] board = new int[5,5];
            int Buf = 0;
            bool Done = false;
            board = ReBoard();
            MoveDirection Move = MoveDirection.None;

            while (!Done) {
                ShowBoard(board);
                Console.WriteLine("\n\n ← : 왼쪽 / → : 오른쪽 / ↑ : 위쪽 / ↓ : 아래쪽");
                Move = Next_Move();
                switch (Move)
                {
                    case MoveDirection.Left:
                        if (x != 0)
                        {
                            Buf = board[y, --x];
                            board[y, x] = 0;
                            board[y, x + 1] = Buf;
                        }
                        break;
                    case MoveDirection.Right:
                        if (x != 4)
                        {
                            Buf = board[y, ++x];
                            board[y, x] = 0;
                            board[y, x - 1] = Buf;
                        }
                        break;
                    case MoveDirection.Up:
                        if (y != 0)
                        {
                            Buf = board[--y, x];
                            board[y, x] = 0;
                            board[y + 1, x] = Buf;
                        }
                        break;
                    case MoveDirection.Down:
                        if (y != 4)
                        {
                            Buf = board[++y, x];
                            board[y, x] = 0;
                            board[y - 1, x] = Buf;
                        }
                        break;
                    case MoveDirection.Cheat:
                        board = UseCheat();
                        break;
                    default:
                        break;
                }
                if (Done = IsDone(board))
                    break;
            }
            ShowBoard(board);
            Console.WriteLine("\n\n **** 퍼즐을 완성하셨습니다! ****");

        }

        static int[,] ReBoard() {
            int[] intArray = new int[25];
            int[,] Board = new int[5, 5];
            Random rand = new Random();

            for (int i = 0; i < 24; i++)
            {
                int randNumber = rand.Next(1, 25);

                if (intArray.Contains(randNumber))
                    i--;
                else
                    intArray[i] = randNumber;
            }
            intArray[24] = 0;

            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++)
                    Board[i, j] = intArray[(5*i) + j];
            }

            return Board;
        }

        static int[,] UseCheat() {
            int[,] Board = new int[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    Board[i, j] = (5 * i) + j;
            }
            return Board;
        }

        static void ShowBoard(int[,] board) {
            int count = 0;
            int before = 0;
            Console.Clear();
            foreach (int element in board)
            {
                if (count == 5)
                {
                    Console.Write("\n\n\n\n");
                    count = 0;
                }
                if (count == 0)
                {
                    Console.Write($"{element}");
                    count++;
                    before = element;
                    continue;
                }
                Console.Write($"\t{element}");
                count++;
                before = element;
            }
        }

        static bool IsDone(int[,] board)
        {
            int count = 0;
            foreach (int element in board)
            {
                if (element != count) return false;
                count++;
            }
            return true;
        }

        static MoveDirection Next_Move()
        {
            ConsoleKeyInfo input;
            MoveDirection player;
            input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.LeftArrow:
                    player = MoveDirection.Left;
                    break;
                case ConsoleKey.RightArrow:
                    player = MoveDirection.Right;
                    break;
                case ConsoleKey.UpArrow:
                    player = MoveDirection.Up;
                    break;
                case ConsoleKey.DownArrow:
                    player = MoveDirection.Down;
                    break;
                case ConsoleKey.C:
                    player = MoveDirection.Cheat;
                    break;
                default:
                    player = MoveDirection.None;
                    break;
            }
            return player;
        }
    }
}
