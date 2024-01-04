namespace Event
{
    internal class Program
    {
        public class Player
        {
            protected int hp = 100;
            public event Action OnGetCoin;
            public event Action OnDamaged;

            public void Died()
            {
                Console.WriteLine("플레이어가 죽었습니다.");
            }

            public void GetCoin()
            {
                Console.WriteLine("플레이어가 코인을 얻음.");

                if (OnGetCoin != null)
                    OnGetCoin();
            }

            public void Equip(Equipment equipment)
            {
                equipment.Equip(this);
            }

            public void UnEquip(Equipment equipment)
            {
                if (equipment.Durability() == 0)
                {
                    equipment = null;
                    Console.WriteLine("방어구가 파괴되었습니다...");
                }
            }

            public void TakeDamage(int damage)
            {
                Console.WriteLine("플레이어가 데미지를 받음.");

                if (OnDamaged != null) 
                {
                    OnDamaged();
                    return;
                }
                this.hp -= damage;
                Console.WriteLine($"플레이어 HP: {hp}");
            }

        }

        public class Equipment
        {
            Player owner;
            private int durability;

            /*~Equipment() 
            {
                System.Diagnostics.Trace.WriteLine("Equipment's finalizer is called");
            }*/

            public int Durability() {
                return durability;
            }

            public void Equip(Player owner)
            {
                Console.WriteLine("방어구를 착용하셨습니다.");
                this.owner = owner;
                durability = 10;
                owner.OnDamaged += this.OnDamage;
            }

            public void UnEquip()
            {
                Console.WriteLine("방어구가 해제되었습니다.");
                owner.OnDamaged -= this.OnDamage;
                this.owner.UnEquip(this);
            }

            public void OnDamage()
            {
                durability -= 1;
                Console.WriteLine($"방어구 내구도: {durability}");
                if (durability <= 0)
                    this.UnEquip();
            }
        }


        static void Main()
        {
            Player player = new Player();
            UI ui = new UI();
            SFX sfx = new SFX();
            VFX vfx = new VFX();
            Equipment equip = new Equipment();

            player.OnGetCoin += ui.UpdateUI;
            player.OnGetCoin += sfx.CoinSound;
            player.OnGetCoin += vfx.CoinEffect;
            player.GetCoin();

            equip.Equip(player);
            for(int i = 0; i < 10; i++)
                player.TakeDamage(1);
            player.TakeDamage(10);

            try
            {
                Console.WriteLine();
                Console.Write("숫자를 2개 입력하세요: ");
                string[] nums = Console.ReadLine().Split(" ");
                Console.WriteLine($"{int.Parse(nums[0])} 나누기 {int.Parse(nums[1])}의 결과는 {int.Parse(nums[0]) / int.Parse(nums[1])}입니다.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("잘못된 정보를 입력하셨습니다.");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("현제 숫자를 0으로 나눌 수 없습니다.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("예기치 못한 문제가 발생하였습니다.");
            }
        }

        public class UI
        {
            public void UpdateUI() { Console.WriteLine("UI에 코인수를 갱신"); }
        }

        public class SFX
        {
            public void CoinSound() { Console.WriteLine("코인을 얻는 효과음 재생"); }
        }

        public class VFX
        {
            public void CoinEffect() { Console.WriteLine("코인을 얻는 반짝거리는 효과"); }
        }
    }
}
