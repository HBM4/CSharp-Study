using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch25_Generics
{
    internal class List
    {
        private object[] objects;

        public List()
        {
            objects = new object[0];
        }

        public void AddObject(object newObject)
        {
            // 여기에 크기가 기존보다 약간 더 큰 새 배열을 만들고,
            // 객체를 추가하는 코드를 작성합니다.
            int newSize = objects.Length + 1;
            object[] newArray = new object[newSize];

            // 기존 배열의 내용을 새 배열로 복사
            for (int i = 0; i < objects.Length; i++)
            {
                newArray[i] = objects[i];
            }

            objects = newArray; // 기존 배열을 새 배열로 교체
            objects[objects.Length - 1] = newObject; // 새 객체를 마지막 위치에 추가
        }

        public object GetObject(int index)
        {
            return objects[index];
        }
    }
}
