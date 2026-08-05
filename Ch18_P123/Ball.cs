using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch18_P123
{
    internal class Ball
    {
        private int size;
        private Color color;
        private int throwCount;

        public Ball(int size, Color color)
        {
            this.size = size;
            this.color = color;
            this.throwCount = 0;
        }
        
        public void Pop()
        {
            this.size = 0;
        }

        public void Throw()
        {
            if (this.size != 0)
            {
                this.throwCount++;
            }
        }

        public int getThrowCount()
        {
            return this.throwCount;
        }
    }
}

/*
<Ball 클래스>
- Ball 클래스는 크기(size)와 색상(color, 방금 만든 Color 클래스)을 위한 인스턴스 변수를 가져야 합니다. 또한 공을 던진 횟수를 추적하는 인스턴스 변수도 추가해 봅시다.
- 유용하다고 생각되는 생성자들을 생성하세요.
- 공의 크기를 0으로 변경하는 Pop 메서드를 만드세요.
- 공이 터지지 않은 경우(크기가 0이 아닌 경우)에만 던진 횟수에 1을 더하는 Throw 메서드를 만드세요.
- 공을 던진 횟수를 반환하는 메서드.
*/