using static System.Net.Mime.MediaTypeNames;
using System.Threading;

namespace GameCharClass
{
    internal class Program
    {
        class Operator {
            protected int Side;
            protected string name = "";
            protected string skill = "";
            protected int hp;
            protected bool Alive;

            public string Name() {
                return name;
            }

            public bool IsAlive(){
                return Alive;
            }

            public void TakeHit(int damage, Operator Shooting) {
                hp -= damage;
                if (hp <= 0)
                {
                    Alive = false;
                    Console.WriteLine($"\n{name} ㄱ {Shooting.Name()}\n");
                    return;
                }
                Console.WriteLine($"{this.Name()} HP {hp}");
            }

            public void Attack(int damage, Operator Hit){
                Hit.TakeHit(damage, this);
            }
        }

        class Sledge : Operator 
        {
            public Sledge() 
            {
                Side = 1;
                hp = 130;
                Alive = true;
                name = "슬레지";
                skill = "Breaching Hammer";
            }

            public void UseSkill()
            {
                Console.WriteLine("Remember. I take the doors.");
                Console.WriteLine("슬레지가 벽을 부셨습니다.\n");
            }
        }

        class Kapkan : Operator
        {
            public Kapkan()
            {
                Side = 2;
                hp = 130;
                Alive = true;
                name = "캅칸";
                skill = "Entry Denial Device";
            }

            public void UseSkill() {
                Console.WriteLine("EDD Mounted, Let them come.");
                Console.WriteLine("캅칸이 문틀에 EDD를 설치했습니다.\n");
            }
        }

        static void Main(string[] args)
        {
            Sledge Attacker1 = new Sledge();
            Kapkan Defenser1 = new Kapkan();

            Console.WriteLine($"공격측 {Attacker1.Name()}");
            Console.WriteLine($"방어측 {Defenser1.Name()}");

            Console.WriteLine("\n방어측 준비시간 입니다.");
            Defenser1.UseSkill();

            Console.WriteLine("\n게임 시작");
            Attacker1.UseSkill();

            Attacker1.Attack(50, Defenser1);
            Defenser1.Attack(50, Attacker1);
            Attacker1.Attack(50, Defenser1);
            Attacker1.Attack(50, Defenser1);

            Console.WriteLine("게임이 종료되었습니다.");
        }
    }
}
