using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    class MyDataList : DataList
    {
        MyLinkedListNode headNode;
        MyLinkedListNode currentNode;

        public MyDataList(int n, int seed)
        {
            length = n;
            Random random = new Random(seed);

            headNode = new MyLinkedListNode(RandomLetterGenerator.getRandomLetter(random));
            currentNode = headNode;
            for (int i = 0; i < n; i++)
            {
                currentNode.nextNode = new MyLinkedListNode(RandomLetterGenerator.getRandomLetter(random));
                currentNode = currentNode.nextNode;
            }

            currentNode.nextNode = null;
        }

        public override char Head()
        {
            currentNode = headNode;
            return currentNode.data;
        }

        public override char Next()
        {
            currentNode = currentNode.nextNode;

            return currentNode.data;
        }

        public override bool hasNext()
        {
            if (currentNode.nextNode != null)
                return true;
            return false;
        }

        public override void Swap(int i, int j, char firstElement, char secondElement)
        {
            if (i == j)
                return;

            int currentPosition = 0;
            for (MyLinkedListNode node = headNode; node != null; node = node.nextNode)
            {
                if (currentPosition == i)
                    node.data = secondElement;

                if (currentPosition == j)
                    node.data = firstElement;

                if ((i <= j && currentPosition == j) || (j <= i && currentPosition == i))
                    break;

                currentPosition++;
            }
        }

        public override void setCurrent(char value)
        {
            currentNode.data = value;
        }

        class MyLinkedListNode
        {
            public MyLinkedListNode nextNode { get; set; }

            public char data { get; set; }

            public MyLinkedListNode(char data)
            {
                this.data = data;
            }
        }
    }


}
