using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    abstract class DataList
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract char Head();
        public abstract char Next();
        public abstract bool hasNext();
        public abstract void Swap(int i, int j, char firstElement, char secondElement);
        public abstract void setCurrent(char value);
        public void Print(int n)
        {
            Console.Write(" {0} ", Head());
            for (int i = 1; i < n; i++)
                Console.Write(" {0} ", Next());
            Console.WriteLine();
        }
    }
}
