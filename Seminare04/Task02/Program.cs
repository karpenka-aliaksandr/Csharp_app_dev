using System.Linq;

namespace Task02
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    //Дан список целых чисел(числа не последовательны), в котором некоторые числа повторяются.
        //    //Выведите список чисел на экран, расположив их в порядке возрастания частоты повторения

        //    List<int> ints = new List<int> { 1, 2, 2, 2, 2, 4, 4, 5, 5, 5, 5, 6, 7, 0 };
        //    Dictionary<int, int> dic = new Dictionary<int, int>();
        //    foreach (int i in ints)
        //    {
        //        if (dic.ContainsKey(i))
        //        {
        //            dic[i]++;
        //        }
        //        else dic.Add(i, 1);
        //    }


        //    // {1,1} {2,4} {4,2} {5,4} {6,1} {7,1} {0,1}
        //    PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
        //    foreach (var el in dic)
        //    {
        //        pq.Enqueue(el.Key, el.Value);
        //    }
        //    while (pq.Count > 0)
        //    {
        //        Console.WriteLine(pq.Dequeue());
        //    }
        //}

        //Задача: У вас есть список студентов.
        //fullname, birthday
        //Необходимо отфильтровать студентов старше 20 лет и отсортировать их по алфавиту.
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            Student student = new Student();
            student.FullName = "Karpenka Viktor";
            student.Age = 40;
            list.Add(student);
            student = new Student();
            student.FullName = "Karpenka Aliaksandr";
            student.Age = 42;
            list.Add(student);
            student = new Student();
            student.FullName = "Fanip Viktor";
            student.Age = 16;
            list.Add(student);
            student = new Student();
            student.FullName = "Fanip Aktor";
            student.Age = 18;
            list.Add(student);
            student = new Student();
            student.FullName = "Fil Viktor";
            student.Age = 16;
            list.Add(student);
            student = new Student();
            student.FullName = "Fil Aktor";
            student.Age = 16;
            list.Add(student);
            student = new Student();
            student.FullName = "Fil Qktor";
            student.Age = 26;
            list.Add(student);

            list = list.Skip(3).Take(5).Where(x => x.Age >= 18).OrderBy(x => x.FullName).ToList();
            foreach (var item in list)
            {
                Console.WriteLine("Name: " + item.FullName + " Age=" + item.Age);
            }
        }
        class Student
        {
            public string FullName { get; set; }
            public int Age { get; set; }

        }

    }
}
