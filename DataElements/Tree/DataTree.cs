using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    abstract class DataTree
    {
        public abstract void left();
        public abstract void right();
        public abstract Student getData();
        public abstract bool isEmpty();
        public abstract void setToRoot();
        public abstract bool hasRight();
        public abstract bool hasLeft();
        public abstract void add(Student student);      

    }
}
