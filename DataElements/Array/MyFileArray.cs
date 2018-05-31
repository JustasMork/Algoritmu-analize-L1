using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    class MyFileArray : DataArray
    {
        public FileStream fs { get; set; }

        public MyFileArray(string filename, int n, int seed)
        {
            char[] data = new char[n];
            length = n;
            Random rand = new Random(seed);
            for (int i = 0; i < length; i++)
            {
                data[i] = RandomLetterGenerator.getRandomLetter(rand);
            }
            if (File.Exists(filename))
                File.Delete(filename);
            try {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
                {
                    for (int j = 0; j < length; j++)
                        writer.Write(data[j]);
                }
            } catch (IOException ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        public override char this[int index] {
            get {
                Byte[] data = new Byte[1];
                fs.Seek(1 * index, SeekOrigin.Begin);
                fs.Read(data, 0, 1);
                return Convert.ToChar(data[0]);
            }
        }

        public override void Swap(int i, int j, char firstElement, char secondElement)
        {
            Byte[] data1 = new Byte[1];
            Byte[] data2 = new Byte[1];
            
            byte[] copy1 = BitConverter.GetBytes(firstElement);
            byte[] copy2 = BitConverter.GetBytes(secondElement);
            data1[0] = copy1[0];
            data2[0] = copy2[0];
            fs.Seek(i , SeekOrigin.Begin);
            fs.Write(data2, 0, 1);
            fs.Seek(j, SeekOrigin.Begin);
            fs.Write(data1, 0, 1);
        }

        public override void set(int index, char value)
        {

            Byte[] data = new Byte[1];
            byte[] tempData = BitConverter.GetBytes(value);
            data[0] = tempData[0];
            fs.Seek(index * 1, SeekOrigin.Begin);
            fs.Write(data, 0, 1);
        }
    }
}
