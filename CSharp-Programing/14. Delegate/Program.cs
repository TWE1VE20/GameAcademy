namespace _13._Delegate
{
    internal class Program
    {
        /****************************************************************
         * 대리자 (Delegate)
         * 
         * 특정 매개 변수 목록 및 반환 형식이 있는 함수에 대한 참조
         * 대리자 인스턴스를 통해 함수를 호출 할 수 있음
         ****************************************************************/

        // <델리게이트 정의>
        // delegate 반환형 델리게이트이름(매개변수들);
        public delegate float DelegateMethod1(float x, float y);
        public delegate void DelegateMethod2(string str);


        public float Plus(float left, float right) { return left + right; }
        public float Minus(float left, float right) { return left - right; }
        public float Multi(float left, float right) { return left * right; }
        public float Divide(float left, float right) { return left / right; }
        public void Message(string message) { Console.WriteLine(message); }


        // <델리게이트 사용>
        // 반환형과 매개변수가 일치하는 함수를 델리게이트 변수에 할당
        // 델리게이트 변수에 참조한 함수를 대리자를 통해 호출 가능
        void Main1()
        {
            DelegateMethod1 delegate1 = new DelegateMethod1(Plus);  // 델리게이트 인스턴스 생성
            DelegateMethod2 delegate2 = Message;                    // 간략한 문법의 델리게이트 인스턴스 생성

            // delegate는 class형이기에 Invoke를 통해 class를 부르듯 사용하는것도 가능하지만
            // 변수처럼 써도 같은 역할을 할 수 있도록 제작되어 있다.
            delegate1.Invoke(20, 10);   // Plus(20, 10);            // Invoke를 통해 참조되어 있는 함수를 호출
            delegate2("메세지");        // Message("메세지");       // 간략한 문법의 델리게이트 함수 호출

            delegate1 = Plus;
            Console.WriteLine(delegate1(20, 10));       // output : 30
            delegate1 = Minus;
            Console.WriteLine(delegate1(20, 10));       // output : 10
            delegate1 = Multi;
            Console.WriteLine(delegate1(20, 10));       // output : 200
            delegate1 = Divide;
            Console.WriteLine(delegate1(20, 10));       // output : 2

            // delegate2 = Plus;        // error : 반환형과 매개변수가 일치하지 않은 함수는 참조 불가
            // 반환형과 매개변수가 일치하는 함수만 참조가능
            // delegate는 실제 객체이기에 =을 사용했을때 실제로는 delegate delegate1 = Plus 는 delegate delegate1 = new delegate(PLUS)로 작동되고 있다고 볼 수 있다.
        }

        static void Main(string[] args)
        {

        }
    }
}
