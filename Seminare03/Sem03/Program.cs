using System.Runtime.InteropServices;

namespace Sem03
{
    internal class Program
    {
 
        static void Main(string[] args)
        {
            List<int> ints = new List<int> { 1, 2, 3, 4, 5 };
            List<int> reverseInts = ReverseList(ints);
            reverseInts.ForEach(Console.WriteLine);



            //Реализуйте класс с поддержкой IEnumerable<int> - CustomEnumerale который в случае использования его в следующем коде
            //foreach (var x in new CustomEmumerable())
            //        {
            //            Console.WriteLine(x);
            //        }
            //    Выведет на экран значения от 0 до 10. 
            //Подумайте, возможно вам придется реализовать не только IEnumerable но и IEnumerator
            foreach (var x in new CustomIEnumerable())
                {
                  Console.WriteLine(x);
               }


        }


        //Используя стек инвертируйте порядок следования элементов в спиcке
        //Пример списка
        //List<int> ints = new List<int> { 1, 2, 3, 4, 5 };
        //        Пример результата
        //        {5,4,3,2,1}
        static List<int> ReverseList (List<int> list)
        {
            Stack<int> stack = new ();
            foreach (int i in list) 
            {
                stack.Push(i);
            }
            List<int> result = [];
            while (stack.TryPop(out int elem)) 
            {
                result.Add (elem);
            }
            return result;
        }

    }
}
