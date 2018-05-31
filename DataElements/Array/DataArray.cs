using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    abstract class DataArray 
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract char this[int index] { get; }
        public abstract void set(int index, char value);
        public abstract void Swap(int i, int j, char a, char b);
        public void Print(int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(" {0} ", this[i]);
            Console.WriteLine();
        }
    }
}
