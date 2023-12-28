using System.Xml.Linq;

namespace Monsters
{
    internal class Program
    {
        class Monster
        {
            protected string name = "";
            protected int hp;
            public int damage;

            public string Name() {
                return this.name;
            }

            public void Move()
            {
                Console.WriteLine($"{name} 이/가 움직입니다.");
            }

            public void Attack(Hero hero)
            {
                Console.WriteLine($"{Name()} 이/가 용사를 공격했습니다!");
                hero.TakeHit(this);
            }

            public void TakeHit(int damage, Hero hero)
            {
                hp -= damage;
                Console.WriteLine($"{name} 이/가 {damage} 를 받아 체력이 {hp} 이 되었습니다.");
                if (hp <= 0) {
                    Console.WriteLine($"{name} 를/을 죽였습니다!");
                    return;
                }
                Attack(hero);
            }
        }

        class Dragon : Monster
        {
            public Dragon()
            {
                name = "드래곤";
                hp = 100;
                damage = 100;
            }

            public void Breath()
            {
                Console.WriteLine($"{name}이 브레스를 뿜습니다.");
            }
        }

        class Slime : Monster
        {
            public Slime()
            {
                name = "슬라임";
                hp = 5;
                damage = 5;
            }

            public void Split()
            {
                Console.WriteLine($"{name}이 분열합니다.");
            }
        }

        class Orc : Monster
        {
            public Orc()
            {
                name = "오크";
                hp = 50;
                damage = 25;
            }

            public void Rage()
            {
                Console.WriteLine($"{name}가 분노합니다.");
            }
        }

        class Hero
        {
            int hp = 100;
            int damage = 35;

            public void Attack(Monster monster)
            {
                Console.WriteLine($"용사가 {monster.Name()} 를/을 공격했습니다!");
                monster.TakeHit(damage, this);
            }

            public void TakeHit(Monster monster)
            {
                hp -= monster.damage;
                Console.WriteLine($"용사가 {monster.damage} 를 받아 체력이 {hp} 이 되었습니다.");
                if (hp <= 0)
                {
                    Console.WriteLine($"용사가 죽었습니다! 죽어버리다니 한심하군요!");
                }
            }
        }

        static void Main(string[] args)
        {
            Hero hero = new Hero();
            Orc orc = new Orc();
            Slime slime = new Slime();
            Dragon dragon = new Dragon();

            Console.WriteLine("용사가 위대한 모험을 시작했습니다.");

            slime.Move();
            slime.Split();
            hero.Attack(slime);
            orc.Move();
            hero.Attack(orc);
            orc.Rage();
            hero.Attack(orc);
            dragon.Move();
            dragon.Breath();
            hero.Attack(dragon);

        }
    }
}
