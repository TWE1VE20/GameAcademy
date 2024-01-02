namespace Interface
{
    internal class Program
    {
        public interface IEnterable
        {
            void Enter();
        }

        public interface IOpenable
        {
            void Open();
        }

        public class Door : IEnterable, IOpenable
        {
            public void Enter()
            {
                Console.WriteLine("문에 들어갑니다.");
            }

            public void Open()
            {
                Console.WriteLine("문을 엽니다.");
            }
        }

        public class Town : IEnterable
        {
            public void Enter()
            {
                Console.WriteLine("마을에 들어갑니다.");
            }
        }

        public class Box : IOpenable
        {
            public void Open()
            {
                Console.WriteLine("상자를 엽니다.");
            }
        }

        public class Player
        {
            public void Enter(IEnterable enterable)
            {
                Console.WriteLine("플레이어가 대상에 들어가기 시도합니다.");
                enterable.Enter();
            }

            public void Open(IOpenable openable)
            {
                Console.WriteLine("플레이어가 대상을 열기 시도합니다.");
                openable.Open();
            }
        }

        public class Car : IEnterable, IOpenable
        {
            protected bool opend = false;

            public void Enter()
            {
                if (!opend)
                    Console.WriteLine("이 탈것은 아직 열려있지않습니다.");
                else
                    Console.WriteLine("탈것에 탑승하셨습니다.");
            }

            public void Open()
            {
                if (!opend)
                {
                    opend = true;
                    Console.WriteLine("탈것의 문을 열었습니다.");
                }
                else 
                    Console.WriteLine("이 탈것은 이미 열려있습니다.");
            }
        }

        abstract class Item : IComparable<Item>
        {
            protected string name = "";

            public int CompareTo(Item? other)
            {
                if (other.name == "") {
                    throw new NotImplementedException();
                }
                return string.Compare(this.name, other.name);
            }

            public string Name() {
                return name;
            }

            public abstract void Use();
        }

        class Potion : Item
        {
            public Potion()
            {
                name = "Potion";
            }

            public Potion(string Name)
            {
                name = Name;
            }

            public override void Use()
            {
                Console.WriteLine("포션을 사용합니다.");
            }
        }

        class Herb : Item
        {
            public Herb()
            {
                name = "Herb";
            }

            public Herb(string Name)
            {
                name = Name;
            }

            public override void Use()
            {
                Console.WriteLine("해독초를 사용합니다.");
            }
        }

        static void PrintItem(Item[] inventory) 
        {
            int count = 0;
            Console.Write("Inventory [ ");
            foreach (Item item in inventory)
            {
                if (count == 0)
                    count++;
                else
                    Console.Write(", ");
                Console.Write($"{item.Name()}");
            }
            Console.Write("]\n");
        }

        static void Main(string[] args)
        {
            Item[] inventory = new Item[5];

            Player player = new Player();

            Door door = new Door();
            Box box = new Box();
            Town town = new Town();
            Car car = new Car();

            Herb RedHerb = new Herb("Red Herb");
            Herb GreenHerb = new Herb("Green Herb");
            Herb YellowHerb = new Herb("Yellow Herb");
            Potion RedPotion = new Potion("Red Potion");
            Potion BluePotion = new Potion("Blue Potion");

            inventory[0] = RedHerb;
            inventory[1] = GreenHerb;
            inventory[2] = YellowHerb;
            inventory[3] = RedPotion;
            inventory[4] = BluePotion;

            player.Enter(door);
            player.Enter(town);

            player.Open(box);
            player.Open(door);

            player.Enter(car);
            player.Open(car);
            player.Open(car);
            player.Enter(car);

            PrintItem(inventory);
            Array.Sort(inventory);
            PrintItem(inventory);
        }
    }
}
