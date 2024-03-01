namespace Labirint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] labirynth = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 0, 1, 0, 2, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {2, 1, 0, 0, 1, 0, 2 },
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 1, 1, 2, 1, 1, 1 }
        };
            int[,] labirynth1 = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 0, 0, 0, 2, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {2, 0, 0, 0, 1, 0, 2 },
            {1, 0, 0, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 1, 1, 2, 1, 1, 1 }
        };
            int countOfExit = CountOfExix(1, 1, labirynth);
            Console.WriteLine(countOfExit > 0 ? $"Найдено выходов: {countOfExit}": $"Выходов не найдено");
            Console.WriteLine();

            countOfExit = CountOfExix(1, 1, labirynth1);
            Console.WriteLine(countOfExit > 0 ? $"Найдено выходов: {countOfExit}" : $"Выходов не найдено");
        }

        static int CountOfExix(int startI, int startJ, int[,] labirinth) { 
            Queue<(int,int)> coords = new ();
            int count = 0;
            
            if (labirinth[startI, startJ] != 1) {
                coords.Enqueue((startI, startJ));
            }

            while (coords.Count > 0)
            {
                (int i, int j) = coords.Dequeue();
                if (labirinth[i, j] == 2)
                    count++;
                
                labirinth[i,j] = 1;
                if (i-1 >= 0 && labirinth[i-1,j] != 1) coords.Enqueue((i-1, j));
                if (i + 1 < labirinth.GetLength(0) && labirinth[i + 1, j] != 1) coords.Enqueue((i+1, j));
                if (j - 1 >= 0 && labirinth[i , j - 1] != 1) coords.Enqueue((i, j - 1));
                if (j + 1 < labirinth.GetLength(1) && labirinth[i, j + 1] != 1) coords.Enqueue((i, j + 1));
            }

            return count;
        }
    }
}
