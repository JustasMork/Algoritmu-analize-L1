using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    class MyFileList : DataList
    {
        int currentNode;
        int nextNode;

        private string filename;

        public FileStream fs { get; set; }

        public MyFileList(string filename, int n, int seed)
        {
            this.filename = filename;
            length = n;
            Random rand = new Random(seed);
            if (File.Exists(filename))
                File.Delete(filename);
            try {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
                {
                    writer.Write(4);
                    for (int j = 0; j < length; j++)
                    {
                        writer.Write(RandomLetterGenerator.getRandomLetter(rand));
                        writer.Write((j +  1) * 5 + 4);
                    }
                }
            } catch (IOException ex) {
                Console.WriteLine(ex.ToString());
            }
        }
        
        public override char Head()
        {
            Byte[] data = new Byte[5];
            fs.Seek(0, SeekOrigin.Begin);
            fs.Read(data, 0, 4);
            currentNode = BitConverter.ToInt32(data, 0);
            fs.Seek(currentNode, SeekOrigin.Begin);
            fs.Read(data, 0, 5);
            char result = Convert.ToChar(data[0]);
            nextNode = BitConverter.ToInt32(data, 1);
            return result;
        }

        public override char Next()
        {
            Byte[] data = new Byte[5];
            fs.Seek(nextNode, SeekOrigin.Begin);
            fs.Read(data, 0, 5);
            currentNode = nextNode;
            char result = Convert.ToChar(data[0]);
            nextNode = BitConverter.ToInt32(data, 1);
            return result;
        }

        public override bool hasNext()
        {
            fs.Seek(currentNode, SeekOrigin.Begin);
            if (fs.Position == fs.Length)
                return false;
            return true;
        }

        public override void Swap(int i, int j, char firstElement, char secondElement)
        {
            if (i == j)
                return;
            this.Head();
            for (int k = 0; k < length; k++)
            {
                if (k == i)
                { 
                    Byte[] valueBytes = BitConverter.GetBytes(secondElement);
                    fs.Seek(currentNode, SeekOrigin.Begin);
                    fs.Write(valueBytes, 0, 1);
                }

                if (k == j)
                {
                    Byte[] valueBytes = BitConverter.GetBytes(firstElement);
                    fs.Seek(currentNode, SeekOrigin.Begin);
                    fs.Write(valueBytes, 0, 1);
                }

                if ((i <= j && k == j) || (j <= i && k == i))
                    break;

                this.Next();
            }
            this.Head(); 
        }

        public override void setCurrent(char value)
        {
            Byte[] valueBytes = BitConverter.GetBytes(value);
            fs.Seek(currentNode, SeekOrigin.Begin);
            fs.Write(valueBytes, 0, 1);
        }
    }
}
