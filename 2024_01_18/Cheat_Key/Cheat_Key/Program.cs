namespace Cheat_Key
{
    internal class Program
    {
        public class CheatKey
        {
            private Dictionary<string, Action> cheatDic = new Dictionary<string, Action>(2);

            public CheatKey()
            {
                cheatDic.Add("ShowMeTheMoney", ShowMeTheMoney);
                cheatDic.Add("ThereIsNoCowLevel", ThereIsNoCowLevel);
            }

            public void Run(string cheatkey)
            {
                if (cheatDic.TryGetValue(cheatkey, out Action cheat))
                    cheat.Invoke();
            }

            public void ShowMeTheMoney()
            {
                Console.WriteLine("골드를 늘려주는 치트키 발동!");
            }

            public void ThereIsNoCowLevel()
            {
                Console.WriteLine("바로 승리하는 치트키 발동!");
            }
        }


        static void Main(string[] args)
        {
            CheatKey Cheats = new CheatKey();
            string? input;

            while (true)
            {
                Console.Write("코드를 입력해보거나 (E로 Exit) : ");
                input = Console.ReadLine();
                if (input == "e" || input == "E")
                    Environment.Exit(0);
                else if (input != null)
                    Cheats.Run(input);
            }
        }
    }
}
