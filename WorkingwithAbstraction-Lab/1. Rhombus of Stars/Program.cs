namespace _1.RhombusofStars
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            for (int i = 1; i <= size ; i++)
            {
                PrintRow(size, i);
            }
            for (int i = size - 1; i > 0; i--)
            {
                PrintRow(size, i);
            }
        }

        static void PrintRow(int size, int parameter)
        {
            for (int i = 0; i < size - parameter; i++)
            {
                Console.Write(" ");
            }
            for (int i = 1; i <= parameter; i++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
    }
}
