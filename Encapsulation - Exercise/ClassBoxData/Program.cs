namespace ClassBoxData
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {

            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            try
            {
                var box = new Box(length, width, height);

                Console.WriteLine(box);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
