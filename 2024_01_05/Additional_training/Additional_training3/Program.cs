namespace Additional_training3
{
    internal class Program
    {
        /*
         *  <Property 속성>
            class Player 를 만들어주고
            체력이라고 하는 변수를 외부에서 읽을 수는 있지만, 변경할 수 없도록
            체력관련 프로퍼티(Hp) 구현
         * 
         */
        public class Player
        {
            public event Action<int> OnChangeHp;

            public int hp = 100;

            public int HP 
            {
                get { return hp; }
                private set { hp = value; OnChangeHp?.Invoke(hp); }
            }

            public void takeDamage() 
            {
                Console.WriteLine("데미지를 받았습니다.");
                HP -= 10;
            }
        }

        public class UI
        {
            public void Ui_Hp(int hp) 
            {
                Console.WriteLine($"플레이어 HP : {hp}");
            }
        }


        static void Main(string[] args)
        {
            Player player = new Player();
            UI ui = new UI();

            player.takeDamage();
            player.OnChangeHp += ui.Ui_Hp;
            player.takeDamage();

        }
    }
}
