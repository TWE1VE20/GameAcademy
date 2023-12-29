using System.Xml.Linq;

namespace Monsters2
{
    internal class Program
    {
        // Monster Class

        class Monster
        {
            protected string name = "";
            protected int hp;
            public int damage;

            public string Name()
            {
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
                if (hp <= 0)
                {
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

        // Hero Class

        class Hero
        {
            public int hp = 100;
            int damage = 35;
            Skill qSkill;
            Skill wSkill;
            Skill eSkill;
            Item item;

            public int Heal(int healing) {
                hp += healing;
            }

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

            public void SetSkill(int qwe123, Skill skill)
            {
                switch (qwe123) {
                    case 1:
                        this.qSkill = skill;
                        break;
                    case 2:
                        this.wSkill = skill;
                        break;
                    case 3:
                        this.eSkill = skill;
                        break;
                }
            }

            public void UseQSkill()
            {
                qSkill.Execute();
            }
            public void UseESkill()
            {
                eSkill.Execute();
            }
            public void UseWSkill()
            {
                wSkill.Execute();
            }

            public void SetItem(Item sitem) {
                this.item = sitem;
            }

            public void UseItem() {
                if (item != null) {
                    item.Use();
                    return;
                }
                Console.WriteLine("설정된 아이템이 없습니다.");
            }
        }

        // Skill Class

        class Skill
        {
            protected int cooltime;

            public virtual void Execute()
            {
                Console.WriteLine("설정된 스킬이 없습니다.");
            }
        }

        class FireBall : Skill
        {
            public FireBall() 
            {
                cooltime = 20;
            }

            public override void Execute()
            {
                Console.WriteLine("스킬 재사용 대기시간을 진행시킴");
                Console.WriteLine("전방에 화염구를 날림니다.");
            }
        }

        class Heal : Skill
        {
            public Heal()
            {
                cooltime = 30;
            }

            public override void Execute()
            {
                Console.WriteLine("스킬 재사용 대기시간을 진행시킴");
                Console.WriteLine("자신을 힐 합니다.");
            }
        }

        // Item Class

        abstract class Item
        {
            public abstract void Use();
        }

        class Potion : Item
        {
            public override void Use()
            {
                Console.WriteLine("포션을 사용할 대상을 지정하지 못하였습니다.");
            }

            public void Use(Hero hero)
            {
                hero.Heal(10);
                Console.WriteLine("포션을 사용하여 체력을 회복합니다.");
            }
        }

        class Herb : Item
        {
            public override void Use()
            {
                Console.WriteLine("해독초를 사용하여 독을 해제합니다.");
            }
        }

        // Main

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
