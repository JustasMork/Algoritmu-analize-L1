using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    class Student: IComparable<Student>
    {
        private string name;
        private string group;
        private string faculty;
        private int uniqueNumber;

        public Student(string name, string group, string faculty, int uniqueNumber)
        {
            this.name = name;
            this.group = group;
            this.faculty = faculty;
            this.uniqueNumber = uniqueNumber;
        }

        public string getName()
        {
            return name;
        }

        public string getGroup()
        {
            return group;
        }

        public string getFaculty()
        {
            return faculty;
        }

        public int getUniqueNumber()
        {
            return uniqueNumber;
        }

        public string toString()
        {
            return String.Format("{0};{1};{2};{3}", name, group, faculty, uniqueNumber);
        }


        public int CompareTo(Student other)
        {
            if (other == null)
                return 1;

            if (this.uniqueNumber > other.uniqueNumber)
                return 1;
            if (this.uniqueNumber < other.uniqueNumber)
                return -1;
            return 0;
        }
    }
}
