namespace Button
{
    internal class Program
    {
        static void Jump() { Console.WriteLine("점프를 합니다."); }
        static void Dash() { Console.WriteLine("대쉬를 합니다."); }
        static void Exit() { Environment.Exit(0); }

        class Button
        {
            Action callback;

            public Button(Action callback)
            {
                this.callback = callback;
            }

            public void Click()
            {
                if (callback != null)
                    callback();
            }
        }

        static void Main()
        {
            Button jumpBtn = new Button(Jump);
            Button dashBtn = new Button(Dash);
            Button exit = new Button(Exit);

            jumpBtn.Click();
            dashBtn.Click();
            ConsoleKeyInfo input;
            while (true) 
            {
                input = Console.ReadKey(true);
                switch (input.Key) 
                {
                    case ConsoleKey.Spacebar:
                        jumpBtn.Click();
                        break;
                    case ConsoleKey.:
                        dashBtn.Click();
                        break;
                    case ConsoleKey.E:
                        exit.Click();
                        break;
                    default:
                        break;

                }
            }
        }
    }
}
