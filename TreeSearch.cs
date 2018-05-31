using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    class TreeSearch
    {
        public static void testSearchMethod(int seed)
        {
            List<Student> students = RandomStudentGenerator.GenerateStudents(seed, 10);
            Shuffle(ref students);
            MyDataTree dataTree = new MyDataTree();

            foreach (Student student in students)
            {
                dataTree.add(student);
            }

            Random random = new Random();
            Student studentToFind = students[random.Next(students.Count)];
            Console.WriteLine("\n\nStudent to find: "+ studentToFind.toString());

            Student foundStudent = SearchTest(dataTree, studentToFind);
            if (foundStudent == null)
                Console.WriteLine("Student not found in tree");
            else
                Console.WriteLine("Student was found in tree: "+ foundStudent.toString());
        }

        public static void testSearchTimes(int seed)
        {
            Console.WriteLine("RED-BLACK tree search times\n");
            int[] numElementsArray = { 12800, 25600, 51200, 102400, 204800, 409600 };
            foreach (int numberOfElements in numElementsArray)
            {
                List<Student> students = RandomStudentGenerator.GenerateStudents(seed, numberOfElements);
                Student studentToFind = students[new Random().Next(students.Count)];
                MyDataTree dataTree = new MyDataTree();
                Shuffle(ref students);
                foreach (Student stud in students)
                    dataTree.add(stud);

                var watch = System.Diagnostics.Stopwatch.StartNew();
                SearchTest(dataTree, studentToFind);
                watch.Stop();
                Console.Write("\nNumber of elements: {0}, Runtime(ms): {1}, Ticks: {2}", numberOfElements, watch.Elapsed, watch.ElapsedTicks);
                
            }
        }

        private static void Shuffle(ref List<Student> list)
        {
            Random rnd = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                Student value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static Student SearchTest(DataTree students, Student studentToFind)
        {
            if (students.isEmpty() || studentToFind == null)
                return null;

            Student foundStudent = null;
            bool finished = false;
            students.setToRoot();

            while ((students.hasLeft() || students.hasRight()) && !finished)
            {
                if (students.getData().CompareTo(studentToFind) == 1)
                {
                    if (students.hasLeft())
                        students.left();
                    else
                        finished = true;
                }
                else if (students.getData().CompareTo(studentToFind) == -1)
                {
                    if (students.hasRight())
                        students.right();
                    else
                        finished = true;
                }

                if (students.getData().CompareTo(studentToFind) == 0)
                {
                    foundStudent = students.getData();
                    finished = true;
                }
            }
            return foundStudent;
        }
    }
}
