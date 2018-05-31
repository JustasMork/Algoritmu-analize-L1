
using System;

namespace L1
{
    class SelectionSort
    {
        private static int arrayLength = 10;

        private static string longLine = "------------------------------";

        public static void testOP(int seed)
        {

            Console.WriteLine("\n\n SELECTION SORT DATA ARRAY ");
            Console.WriteLine(longLine);
            MyDataArray dataArray = new MyDataArray(arrayLength, seed);
            dataArray.Print(arrayLength);

            Console.WriteLine(longLine);
            Sort(dataArray);
            dataArray.Print(arrayLength);

            Console.WriteLine("\n\n SELECTION SORT DATA LIST");
            Console.WriteLine(longLine);
            MyDataList dataList = new MyDataList(arrayLength, seed);
            dataList.Print(arrayLength);

            Console.WriteLine(longLine);
            Sort(dataList);
            dataList.Print(arrayLength);

        }

        public static void testArrayTimes(int seed)
        {

            int[] numElementsArray = { 200, 400, 800, 1600, 3200, 6400, 12800 };

            foreach (int numberOfElements in numElementsArray) {
                Console.Write("\nElements: " + numberOfElements);
                MyDataArray dataArray = new MyDataArray(numberOfElements, seed);
                var watch = System.Diagnostics.Stopwatch.StartNew();
                Sort(dataArray);
                watch.Stop();
                Console.Write(" Data array time:"+watch.ElapsedMilliseconds);
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

        public static void testD(int seed)
        {
            string filename = "@mydataarray.dat";

            MyFileArray fileArray = new MyFileArray(filename, arrayLength, seed);
            using (fileArray.fs = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite))
            {
                Console.WriteLine("\n\n SELECTION SORT FILE ARRAY");
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
                Console.WriteLine("\n\n SELECTION SORT FILE LIST ");
                Console.WriteLine(longLine);
                fileList.Print(arrayLength);

                Console.WriteLine(longLine);
                Sort(fileList);
                fileList.Print(arrayLength);
            }

        }

        public static void Sort(DataArray items)
        {
            char minVal;
            int minIndex;
            for (int i = 0; i < items.Length - 1 ; i++) {
                minVal = items[i];
                minIndex = i;
                for (int j = i; j < items.Length; j++) {
                    if (minVal > items[j])
                    {
                        minVal = items[j];
                        minIndex = j;
                    }
                }
                items.Swap(i, minIndex, items[i], minVal);
            }
        }

        public static void Sort(DataList items)
        {
            
            char minVal;
            int minIndex;
            for (int i = 0; i < items.Length - 1; i++) {
                minVal = items.Head();
                minIndex = i;
                int counter = 0;

                while (counter < i)
                {
                    minVal = items.Next();
                    counter++;
                }

                char currentElement = minVal;

                for (int j = i + 1; j < items.Length && items.hasNext(); j++)
                {
                    char tempVal = items.Next();
                    if (minVal > tempVal)
                    {
                        minVal = tempVal;
                        minIndex = j;
                    }
                }
                items.Swap(i, minIndex, currentElement, minVal);
            }
        }
    }
}
