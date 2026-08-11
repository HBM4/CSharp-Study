using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch33_Events
{
    internal class Point
    {
        private double x;
        private double y;

        // NumberChanged 이벤트 정의
        public event EventHandler<NumberChangedEventArgs>? NumberChanged;

        public double X
        {
            get { return x; }
            set
            {
                double original = x; // 변경 전 값 저장
                x = value;

                // NumberChanged 이벤트 발생 (int로 캐스팅)
                OnNumberChanged((int)original, (int)value);
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                double original = y; // 변경 전 값 저장
                y = value;

                // NumberChanged 이벤트 발생 (int로 캐스팅)
                OnNumberChanged((int)original, (int)value);
            }
        }

        // 교재와 동일한 형태: NumberChanged 이벤트 발생 메서드
        public void OnNumberChanged(int oldValue, int newValue)
        {
            if (NumberChanged != null)
                NumberChanged(this, new NumberChangedEventArgs(oldValue, newValue));
            // this 의미: 현재 이벤트를 발생시키는 객체를 나타냅니다. 이벤트 핸들러에게 이벤트가 발생한 객체를 전달하기 위해 사용됩니다.
            // new 의미: 새로운 NumberChangedEventArgs 객체를 생성하여 이벤트 핸들러에게 전달합니다. 이 객체는 이벤트와 관련된 데이터를 포함합니다.
        }
    }
}
