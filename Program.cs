using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    class Program
    {
        static void Main(string[] args)
        {
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

            SelectionSort.testOP(seed);
            SelectionSort.testD(seed);
            SelectionSort.testArrayTimes(seed);

            CountingSort.testOP(seed);
            CountingSort.testD(seed);
            CountingSort.testArrayTimes(seed);

            TreeSearch.testSearchMethod(seed);
            TreeSearch.testSearchTimes(seed);
        }



    }

}
