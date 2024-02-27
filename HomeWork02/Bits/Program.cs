namespace bits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long longNum = 3L;
            Bits bitsLong = new Bits(longNum);
            Console.WriteLine(longNum.GetType() + " " + (long)bitsLong);
            for (int i = 0; i < sizeof(long)*8; i++)
            {
                Console.Write(bitsLong[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            int intNum = 3;
            Bits bitsInt = new Bits(intNum);
            Console.WriteLine(intNum.GetType() + " " + (int)bitsInt);
            for (int i = 0; i < sizeof(int) * 8; i++)
            {
                Console.Write(bitsInt[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            byte byteNum = 3;
            Bits bitsByte = new Bits(byteNum);
            Console.WriteLine(byteNum.GetType() + " " + (byte)bitsByte);
            for (int i = 0; i < sizeof(byte) * 8; i++)
            {
                Console.Write(bitsByte[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();



        }
    }
}
