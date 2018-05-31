using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    class MyDataArray : DataArray
    {
        char[] array;

        public MyDataArray(int n, int seed) {
            Random random = new Random(seed);
            this.array = new char[n];
            length = n;

            for (int i = 0; i < n; i++)
            {
                array[i] = RandomLetterGenerator.getRandomLetter(random);
            }
        }

        public MyDataArray(int n)
        {
            array = new char[n];
            length = n;
        }

        public override char this[int index]
        {
            get
            {
                return array[index];
            }
        }

        public override void set(int index, char value)
        {
            array[index] = value;          
        }

        public override void Swap(int i, int j, char a, char b)
        {
            array[i] = b;
            array[j] = a;
        }
    }
}
