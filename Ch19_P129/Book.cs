using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch19_P129
{
    internal class Book
    {
        private string title;
        private string author;
        private int pages;
        private int wordCount;

        // 자동 구현 프로퍼티
        public string Publisher { get; set; }

        public Book(string title, string author)
        {
            this.title = title;
            this.author = author;
        }

        public Book(string title, string author, int pages, int wordCount)
        {
            this.title = title;
            this.author = author;
            this.pages = pages;
            this.wordCount = wordCount;
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }

        public int Pages
        {
            get
            {
                return pages;
            }
            set
            {
                if (value < 0)
                    pages = 0;
                else
                    pages = value;
            }
        }

        public int WordCount
        {
            get
            {
                return wordCount;
            }
            // set을 작성하지 않으면 WordCount는 읽기 전용이 됩니다.
        }

        // WordCount를 계산하는 메서드
        public void AssignWordCountFromText(string text)
        {
            wordCount = text.Split(' ').Length;
        }
    }
}
