using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    class CountingSort
    {
        private static int arrayLength = 10;
        private static string longLine = "-------------------------------";


        public static void testOP(int seed)
        {
            Console.WriteLine("\n\n COUNTING SORT DATA ARRAY");
            Console.WriteLine(longLine);
            MyDataArray dataArray = new MyDataArray(arrayLength, seed);
            dataArray.Print(arrayLength);

            Console.WriteLine(longLine);
            Sort(dataArray);
            dataArray.Print(arrayLength);


            Console.WriteLine("\n\n COUNTING SORT DATA LIST");
            Console.WriteLine(longLine);
            MyDataList dataList = new MyDataList(arrayLength, seed);
            dataList.Print(arrayLength);

            Console.WriteLine(longLine);
            Sort(dataList);
            dataList.Print(arrayLength);

        }

        public static void testD(int seed)
        {
            string filename = "@mydataarray.dat";

            MyFileArray fileArray = new MyFileArray(filename, arrayLength, seed);
            using (fileArray.fs = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite))
            {
                Console.WriteLine("\n\n COUNTING SORT FILE ARRAY");
                Console.WriteLine(longLine);
                fileArray.Print(arrayLength);

                Console.WriteLine(longLine);
                Sort(fileArray);
                fileArray.Print(arrayLength);
            }

            filename = "@mydatalist.dat";

            MyFileList fileList = new MyFileList(filename, arrayLength, seed);
            using (fileList.fs = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite))
            {
                Console.WriteLine("\n\n COUNTING SORT FILE LIST ");
                Console.WriteLine(longLine);
                fileList.Print(arrayLength);

                Console.WriteLine(longLine);
                Sort(fileList);
                fileList.Print(arrayLength);
            }
        }

        public static void testArrayTimes(int seed)
        {
            int[] numElementsArray = { 12800, 25600, 51200, 102400, 204800, 409600};

            foreach (int numberOfElements in numElementsArray)
            {
                Console.Write("\nElements: " + numberOfElements);
                MyDataArray dataArray = new MyDataArray(numberOfElements, seed);
                var watch = System.Diagnostics.Stopwatch.StartNew();
                Sort(dataArray);
                watch.Stop();
                Console.Write(" Data array time:" + watch.ElapsedMilliseconds);
                string filename = "@mydataarraytimes.dat";
                MyFileArray fileArray = new MyFileArray(filename, numberOfElements, seed);
                using (fileArray.fs = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite))
                {
                    watch = System.Diagnostics.Stopwatch.StartNew();
                    Sort(fileArray);
                    watch.Stop();
                    Console.Write(" File array:" + watch.ElapsedMilliseconds);
                }
            }
        }


        public static void Sort(DataArray items)
        {
            MyDataArray copy = new MyDataArray(items.Length);
            for (int i = 0; i < items.Length; i++)
            {
                copy.set(i, items[i]);
            }

            if (items.Length == 0)
                return;

            int minValue = items[0];
            int maxValue = minValue;

            for (int i = 0; i < items.Length; i++)
            {
                if (minValue > items[i])
                    minValue = (int)items[i];

                if (maxValue < items[i])
                    maxValue = (int)items[i];
            }

            int[] frequency = new int[maxValue - minValue + 1];

            for (int i = 0; i < items.Length; i++)
            {
                frequency[(int)items[i] - minValue]++;
            }

            frequency[0]--;
            for (int i = 1; i < frequency.Length; i++)
            {
                frequency[i] = frequency[i] + frequency[i - 1];
            }

            for (int i = copy.Length - 1; i >= 0; i--)
            {
                items.set(frequency[copy[i] - minValue]--, copy[i]);
            }
        }

        public static void Sort(DataList items)
        {
            char[] copy = new char[items.Length];
            copy[0] = items.Head();
            for (int i = 1; items.hasNext() && i < copy.Length; i++)
            {
                copy[i] = items.Next();
            }

            int minValue = items.Head();
            int maxValue = minValue;

            while (items.hasNext())
            {
                int value = items.Next();

                if (minValue > value)
                    minValue = value;

                if (maxValue < value)
                    maxValue = value;
            }

            int[] frequency = new int[maxValue - minValue + 1];

            frequency[items.Head() - minValue]++;
            for(int i = 1; items.hasNext(); i++)
            {
                frequency[items.Next() - minValue]++;
            }

            frequency[0]--;
            for (int i = 1; i < frequency.Length; i++)
            {
                frequency[i] = frequency[i] + frequency[i - 1];
            }
            items.Head();
            for (int i = copy.Length - 1; i >= 0; i--)
            {               
                int j = 0;
                while (frequency[copy[i] - minValue] != j)
                {
                    items.Next();
                    j++;                  
                }

                frequency[copy[i] - minValue]--;
                items.setCurrent(copy[i]);

                items.Head();
            }
        }         
    }
}
