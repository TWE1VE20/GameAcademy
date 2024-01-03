namespace Calculator
{
    internal class Program
    {
        public class Calculator
        {
            public delegate double Operator(double x, double y);

            static double Plus(double left, double right) { return left + right; }
            static double Minus(double left, double right) { return left - right; }
            static double Multi(double left, double right) { return left * right; }
            static double Divide(double left, double right) { return left / right; }

            static double left_num = 0f;
            static double right_num = 0f;

            Operator operating = new Operator(Plus);

            public void SetCommand(double left, char oper, double right)
            {
                // 계산금지
                left_num = left;
                right_num = right;
                switch (oper) {
                    case '+':
                        operating = Plus;
                        break;
                    case '-':
                        operating = Minus;
                        break;
                    case '*':
                        operating = Multi;
                        break;
                    case '/':
                        operating = Divide;
                        break;
                    default: 
                        throw new ArgumentException();
                }
            }

            public double Equal()
            {
                // 조건문 쓰기 금지
                return operating(left_num, right_num);
            }
        }

        public static void Main()
        {
            Calculator cal = new Calculator();
            cal.SetCommand(2.5, '+', 3.2);
            double result = cal.Equal();
            // 결과가 5.7이 나오도록 구현
            Console.WriteLine(result);
            cal.SetCommand(2.5, '-', 3.2);
            result = cal.Equal();
            Console.WriteLine(result);
            cal.SetCommand(2.5, '*', 3.2);
            result = cal.Equal();
            Console.WriteLine(result);
            cal.SetCommand(2.5, '/', 3.2);
            result = cal.Equal();
            Console.WriteLine(result);
        }

    }
}
