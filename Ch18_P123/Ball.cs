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