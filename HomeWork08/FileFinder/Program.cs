namespace FileFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            String path = args[0];
            foreach (var item in Directory.GetFiles(path, "*."+args[1], SearchOption.AllDirectories)
                .Where(item => new StreamReader(item).ReadToEnd().Contains(args[2])))
            {
                Console.WriteLine(item);
            }
        }
    }
}
