using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch23_SearchEngine
{
    internal abstract class SearchEngine // 추상 클래스 (abstract 키워드)
    {
        public abstract string[] Search(string findThis); // 추상 메서드 (본문 작성 불가)
    }
}
