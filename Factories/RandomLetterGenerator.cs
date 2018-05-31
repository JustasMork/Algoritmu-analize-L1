using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    class RandomLetterGenerator
    {
        public static char getRandomLetter(Random random)
        {
            return (char) ('a' + random.Next(0, 26));
        }
    }
}
