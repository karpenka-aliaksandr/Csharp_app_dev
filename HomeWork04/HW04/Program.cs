namespace HW04
{
    internal class Program
    {
        //Дан массив и число. Найдите три числа в массиве сумма которых равна искомому числу.
        //Подсказка: если взять первое число в массиве, можно ли найти в оставшейся его части два числа равных по сумме первому.
        static void Main(string[] args)
        {
            int[] ints = { 1, 4, 34, -4, -236, -234, -6, -4, 235, 6, 45, 8, 456, 67, 3, 8, 2, 4, 38, 28, 56, 2 };
            int number = 230;
            PrintNumbersOfSum(ints, number);
            Console.WriteLine();
            PrintNumberForSum(ints, number);


        }
        static bool FindNumberForSum (int[] ints, int number, out int[] numbers) { 
            numbers = new int[3];
            for (int i = 0; i < ints.Length-2; i++)
            {
                for (int j = i + 1; j < ints.Length - 1; j++)
                {
                    for (int k = j + 1; k < ints.Length; k++)
                    {
                        if (ints[i] + ints[j] + ints[k] == number)
                        {
                            numbers[0] = ints[i];
                            numbers[1] = ints[j];
                            numbers[2] = ints[k];
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        static void PrintNumbersOfSum(int[] ints, int number)
        {   
            if (FindNumberForSum(ints, number, out int[] numbers))
            {
                Console.WriteLine($"{numbers[0]} + {numbers[1]} + {numbers[2]} = {number}");
            }
            else
                Console.WriteLine($"В массиве нет трех чисел, сумма которых равна {number}");
        }

        static void PrintNumberForSum(int[] ints, int number)
        {   
            bool hasResult = false;
            for (int i = 0; i < ints.Length - 2; i++)
            {
                int target = number - ints[i];
                var hs = new HashSet<int>();
                for (int j = i+1; j < ints.Length; j++)
                {
                    var x = target - ints[j];
                    if (hs.Contains(x))
                    {
                        Console.WriteLine($"{ints[i]} + {x} + {ints[j]} = {number}");
                        hasResult = true;
                    }
                    else
                        hs.Add(ints[j]);
                }
            }
            if ( !hasResult ) 
            { 
                Console.WriteLine($"В массиве нет трех чисел, сумма которых равна {number}"); 
            }
            
        }
    }
}
