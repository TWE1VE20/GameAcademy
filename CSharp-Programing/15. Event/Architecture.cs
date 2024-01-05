using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14._Event
{
    internal class Architecture
    {
        /****************************************************************
         * 이벤트의 사용의미
         * 
         * 이벤트를 사용할 경우 클래스의 개방폐쇄원칙을 지킬 수 있으며
         * 일련의 사건이 발생한 타이밍에만 연산을 진행할 수 있음
         ****************************************************************/

        public class Call
        {
            // <Call 방식>
            // 일련의 사건이 발생한 순간에 대상의 함수를 호출하여 진행
            // 장점 : 불필요한 연산 없이 일련의 사건이 발생한 타이밍에 처리 가능
            // 단점 : 추가 기능 개발시 클래스를 수정해야하는 개방폐쇄의 원칙을 위반함

            public class Player
            {
                public int hp = 100;

                public UI ui;

                public void Hit(int damage)
                {
                    hp -= damage;
                    Console.WriteLine($"플레이어가 데미지를 받아 체력이 {hp} 이 되었습니다.");

                    // event를 사용하지 않고 여기에 바로 만들어주면 event를 사용하지 않았을때의 문제점이 없을것이며
                    // 힘들게 event를 만들지 안아도 되게 된다.
                    // 하지만
                    // 클래스에서 연관된 기능들을 직접 호출해야함
                    // 만약 새로운 기능이 추가되는 경우 계속해서 수정될 부분
                    // 즉 협업에서 이러한 부분을 이 클래스를 잘 모르는 사람이 다 알고 바꾸기가 힘들어진다.
                    ui.SetHP(hp);
                }
            }

            public class UI
            {
                public void SetHP(int hp)
                {
                    Console.WriteLine($"UI의 체력표시를 {hp} 으로 변경합니다.");
                }
            }
        }


        public class Polling
        {
            // <Polling 방식>
            // 대상에서 일련의 사건 발생을 확인하기 위해 계속해서 변경사항을 확인
            // 장점 : 추가 기능 개발시에도 클래스를 수정하지 않아 개방폐쇄의 원칙을 준수함
            // 단점 : 변경사항이 없는 경우에도 계속 확인해야하는 불필요한 연산이 발생

            public class Player
            {
                public int hp = 100;

                public void Hit(int damage)
                {
                    hp -= damage;
                    Console.WriteLine($"플레이어가 데미지를 받아 체력이 {hp} 이 되었습니다.");
                }
            }

            public class UI
            {
                public Player player;

                // UI를 갱신하기 위해 주기적으로 실행해야함
                // 갱신이 늦을 경우 UI에서 확인하는 내용이 실제 데이터와 다를 수 있음
                public void CheckHP()
                {
                    Console.WriteLine($"UI의 체력표시를 {player.hp} 으로 변경합니다.");
                }
            }

            public Update() 
            {
                CheckHP()
            }

            public void CheckHP() 
            {
                Console.WriteLine("플레이어 HP 확인");
            }
        }
        // 플레이어의 위치와 같이 몬스터나 아이템이나 이를 계속 실시간으로 봐야하는 사건이나 속도 방향 과 같은 실시간으로 변경상항을
        // 확인해야 하는 방식이 필요할 경우 pulling을 사용. Unity에서는 Update를 사용

        public class Event
        {
            // <Event 방식>
            // 일련의 사건이 발생했을 때 반응할 대상을 참조하고 사건 발생시 호출하여 진행
            // 장점 : 개방폐쇄의 원칙이 지켜지며, 불필요한 연산을 필요로 하지 않음
            // 단점 : 이벤트를 구성하기 위한 추가적인 소스를 작성해야 함

            public class Player
            {
                public int hp = 100;

                public event Action<int> OnChangeHP;

                public void Hit(int damage)
                {
                    hp -= damage;
                    Console.WriteLine($"플레이어가 데미지를 받아 체력이 {hp} 이 되었습니다.");

                    // 사건이 발생한 시점에 이벤트를 등록한 객체들의 함수를 호출
                    // 이벤트로 구성할 경우 새로운 기능이 추가되어도 수정할 필요가 없음
                    if (OnChangeHP != null)
                        OnChangeHP(hp);     //OnChangeHP.Invoke(hp)
                }
            }

            public class UI
            {
                // 이벤트 발생 시점에 호출당할 함수
                // 이벤트 발생 시점에 반드시 호출당하기 때문에 주기적인 실행이 필요없음
                public void SetHP(int hp)
                {
                    Console.WriteLine($"UI의 체력표시를 {hp} 으로 변경합니다.");
                }
            }
            // 매번 확인할것이 아닌 그떄 그때 확인할 일의 경우 Event를 사용하는것이 적합하다.

        }
    }
}
