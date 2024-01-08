using System;
using System.Runtime.Intrinsics.Arm;
using static ShopGame.Program;

namespace ShopGame
{
    internal class Program
    {

        public class Item
        {
            protected string name = "";
            protected int price = 0;
            protected string Desc = "";
            protected int state;
            protected int hp;
            protected int ap;
            protected int dp;

            public int Ap()
            {
                return ap;
            }

            public int Dp()
            {
                return dp;
            }

            public int Hp()
            {
                return hp;
            }

            public int State()
            {
                return state;
            }

            public string Name()
            {
                return name;
            }

            public int Price()
            {
                return price;
            }

            public void Descrive(int num) {
                Console.WriteLine($"{num}.{name}\n가격 : {price}\n설명 : {Desc}");
            }
            //public abstract void Use();
        }

        public class Longsword : Item
        {
            public Longsword() 
            {
                name = "롱소드";
                price = 450;
                Desc = "기본적인 검이다.";
                state = 1;
                ap = 15;
            }
        }

        public class Lether_Armer : Item
        {
            public Lether_Armer() 
            {
                name = "천갑옷";
                price = 450;
                Desc = "얇은 갑옷이다.";
                state = 2;
                dp = 10;
            }
        }

        public class Goddess_tears : Item
        {
            public Goddess_tears() 
            {
                name = "여신의 눈물";
                price = 800;
                Desc = "희미하게 푸른빛을 품고 있는 보석이다.";
                state = 3;
                hp = 10;
            }
        }

        static void Main(string[] args)
        {
            int Screen = 0;
            string input;

            int gold = 10000;
            int AP = 0;
            int DP = 0;
            int HP = 0;
            List<Item> inventory = new List<Item>();

            Longsword longsword = new Longsword();
            Lether_Armer lether_armer = new Lether_Armer();
            Goddess_tears god_tears = new Goddess_tears();

            while (true)
            {
                switch (Screen)
                {
                    case 0:
                        Title();
                        input = Console.ReadLine();
                        if (input == "1" || input == "2" || input == "3")
                        {
                            Screen = int.Parse(input);
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Screen = 0;
                            Console.Clear();
                            break;
                        }
                    case 1:
                        Shop(gold);
                        longsword.Descrive(1); State(longsword); Console.WriteLine();
                        lether_armer.Descrive(2); State(lether_armer); Console.WriteLine();
                        god_tears.Descrive(3); State(god_tears); Console.WriteLine();
                        Console.Write("구매할 아이템을 선택하세요 (취소 0) : ");
                        input = Console.ReadLine();
                        if ((input == "1" || input == "2" || input == "3") && inventory.Count < 6)
                        {
                            if (input == "1")
                            {
                                inventory.Add(longsword);
                                Console.WriteLine($"{longsword.Name()}를 구매합니다.");
                                Console.WriteLine($"플레이어의 공격력이 {longsword.Ap()} 상승하여 {AP += longsword.Ap()}이 됩니다.");
                                Console.WriteLine($"보유한 골드가 {gold}G 감소하여 {gold -= longsword.Price()}가 됩니다.");
                            }
                            else if (input == "2")
                            {
                                inventory.Add(lether_armer);
                                Console.WriteLine($"{lether_armer.Name()}를 구매합니다.");
                                Console.WriteLine($"플레이어의 방어력이 {lether_armer.Dp()} 상승하여 {DP += lether_armer.Dp()}이 됩니다.");
                                Console.WriteLine($"보유한 골드가 {gold}G 감소하여 {gold -= lether_armer.Price()}가 됩니다.");
                            }
                            else
                            {
                                inventory.Add(god_tears);
                                Console.WriteLine($"{god_tears.Name()}를 구매합니다.");
                                Console.WriteLine($"플레이어의 체력이 {god_tears.Hp()} 상승하여 {HP += god_tears.Hp()}이 됩니다.");
                                Console.WriteLine($"보유한 골드가 {gold}G 감소하여 {gold -= god_tears.Price()}가 됩니다.");
                            }
                            Screen = 0;
                            Continue();
                            break;
                        }
                        else if (input == "0")
                        {
                            Screen = 0;
                            Console.Clear();
                            break;
                        }
                        else if ((input == "1" || input == "2" || input == "3") && inventory.Count >= 6)
                        {
                            Console.WriteLine("인벤토리가 가득찼습니다.");
                            Continue();
                            Screen = 0;
                            break;
                        }
                        else
                        {
                            Screen = 0;
                            Console.Clear();
                            break;
                        }
                        break;
                    case 2:
                        SellShop(gold);
                        if (inventory.Count == 0)
                        {
                            Console.WriteLine("판매할 물건이 없습니다.");
                            Continue();
                            Screen = 0;
                            break;
                        }
                        int count = 0;
                        foreach (Item inv in inventory)
                        {
                            count++;
                            inv.Descrive(count); State(inv); Console.WriteLine();
                        }
                        Console.Write("판매할 아이템을 선택하세요 (취소 0) : ");
                        input = Console.ReadLine();
                        int value;
                        if (int.TryParse(input, out value))
                        {
                            if (value <= inventory.Count && value > 0)
                            {
                                Console.WriteLine($"{inventory[value-1].Name()}를 판매합니다.");
                                State2(inventory[value-1], ref AP, ref DP, ref HP, ref gold);
                                inventory.RemoveAt(value-1);
                            }
                            Screen = 0;
                        }
                        else if (input == "0")
                        {
                            Screen = 0;
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Screen = 0;
                            Console.Clear();
                            break;
                        }
                        break;
                    case 3:
                        current(inventory, gold, AP, DP, HP);
                        Screen = 0;
                        break;
                    default:
                        Screen = 0;
                        break;
                }
            }

            static void Title()
            {
                for (int i = 0; i < 37; i++) Console.Write("*"); Console.WriteLine();
                for (int i = 0; i < 12; i++) Console.Write("*");
                Console.Write(" 아이템 상점 ");
                for (int i = 0; i < 12; i++) Console.Write("*"); Console.WriteLine();
                for (int i = 0; i < 37; i++) Console.Write("*"); Console.WriteLine();
                Console.WriteLine(); Console.WriteLine();

                for (int i = 0; i < 9; i++) Console.Write("=");
                Console.Write(" 상점 메뉴 ");
                for (int i = 0; i < 9; i++) Console.Write("="); Console.WriteLine();

                Console.WriteLine("1. 아이템 구매"); Console.WriteLine("2. 아이템 판매"); Console.WriteLine("3. 아이템 확인");
                Console.Write("메뉴를 선택하세요 : ");

            }

            static void Shop(int gold)
            {
                for (int i = 0; i < 9; i++) Console.Write("=");
                Console.Write(" 아이템 구매 ");
                for (int i = 0; i < 9; i++) Console.Write("="); Console.WriteLine();
                Console.WriteLine($"보유한 골드 : {gold}G\n");
            }

            static void SellShop(int gold)
            {
                for (int i = 0; i < 9; i++) Console.Write("=");
                Console.Write(" 아이템 판매 ");
                for (int i = 0; i < 9; i++) Console.Write("="); Console.WriteLine();
                Console.WriteLine($"보유한 골드 : {gold}G\n");
            }

            static void Continue() 
            {
                Console.Write("\n계속하려면 아무키나 입력하세요"); Console.ReadKey();
                Console.Clear();
            }

            static void State(Item item)
            {
                switch (item.State()) {
                    case 1:
                        Console.WriteLine($"공격력 상승 : {item.Ap()}");
                        break;
                    case 2:
                        Console.WriteLine($"방어력 상승 : {item.Dp()}");
                        break;
                    case 3:
                        Console.WriteLine($"체력 상승 : {item.Hp()}");
                        break;
                }
            }
            static void State2(Item item, ref int AP, ref int DP, ref int HP, ref int gold)
            {
                switch (item.State())
                {
                    case 1:
                        Console.WriteLine($"플레이어의 공격력이 {item.Ap()} 감소하여 {AP -= item.Ap()}이 됩니다.");
                        Console.WriteLine($"보유한 골드가 {gold}G 상승하여 {gold += item.Price()}가 됩니다.");
                        break;
                    case 2:
                        Console.WriteLine($"플레이어의 공격력이 {item.Dp()} 감소하여 {DP -= item.Dp()}이 됩니다.");
                        Console.WriteLine($"보유한 골드가 {gold}G 상승하여 {gold += item.Price()}가 됩니다.");
                        break;
                    case 3:
                        Console.WriteLine($"플레이어의 공격력이 {item.Hp()} 감소하여 {DP -= item.Hp()}이 됩니다.");
                        Console.WriteLine($"보유한 골드가 {gold}G 상승하여 {gold += item.Price()}가 됩니다.");
                        break;
                }
                Continue();
            }

            static void current(List<Item> inv, int gold, int Ap, int Dp, int Hp) 
            {
                for (int i = 0; i < 9; i++) Console.Write("=");
                Console.Write(" 아이템 확인 ");
                for (int i = 0; i < 9; i++) Console.Write("="); Console.WriteLine();
                Console.WriteLine($"플레이어 골드 보유량 : {gold}");
                Console.WriteLine($"플레이어 공격력 상승량 : {Ap}");
                Console.WriteLine($"플레이어 방어력 상승량 : {Dp}");
                Console.WriteLine($"플레이어 체력 상승량 : {Hp}"); Console.WriteLine();
                if (inv.Count == 0)
                {
                    Console.WriteLine("\n인벤토리가 비었습니다.");
                    Continue();
                    return;
                }
                int count = 0;
                foreach (Item inventory in inv) 
                {
                    count++;
                    inventory.Descrive(count); State(inventory); Console.WriteLine();
                }
                Continue();
            }
        }
    }
}
