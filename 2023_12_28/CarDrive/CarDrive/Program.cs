using System.Numerics;

namespace CarDrive
{
    internal class Program
    {
        public enum MoveDirection { mAccel, mBreak, End, None};

        class Car {
            int speed = 0;
            string name;

            public Car(string CarName){
                this.name = CarName;
            }

            public string Name() {
                return name;
            }

            public void SpeedUp() {
                this.speed += 10;
                Console.WriteLine($"속도: {this.speed}");
            }
            public void SpeedDown() {
                if(this.speed != 0) this.speed -= 10;
                Console.WriteLine($"속도: {this.speed}");
            }
        }

        class Driver {
            public void Accel(Car car){
                Console.WriteLine("액셀을 밟았습니다");
                car.SpeedUp();
            }
            public void Break(Car car) {
                Console.WriteLine("브레이크를 밟았습니다");
                car.SpeedDown();
            }
        }

        static void Main(string[] args)
        {
            Car F1 = new Car("F1");
            Driver Pro_Racer = new Driver();
            bool RaceOver = false;

            Console.WriteLine($"\n당신은 지금 {F1.Name()}에 타고있으며 위대한 경주를 하고 있습니다.\n");

            while (!RaceOver) {
                Console.WriteLine("다음 할 행동을 입력해 주세요 (↑,↓)");
                Console.WriteLine("E로 골인");
                ConsoleKeyInfo input;
                MoveDirection player;
                input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        player = MoveDirection.mAccel;
                        break;
                    case ConsoleKey.DownArrow:
                        player = MoveDirection.mBreak;
                        break;
                    case ConsoleKey.E:
                        player = MoveDirection.End;
                        break;
                    default:
                        player = MoveDirection.None;
                        break;
                }
                switch (player) {
                    case MoveDirection.mAccel:
                        Pro_Racer.Accel(F1);
                        break;
                    case MoveDirection.mBreak:
                        Pro_Racer.Break(F1);
                        break;
                    case MoveDirection.End:
                        RaceOver = true;
                        break;
                }
                Thread.Sleep(200);
            }

            Console.WriteLine("당신은 경주를 무사히 끝냈습니다.");
        }
    }
}
