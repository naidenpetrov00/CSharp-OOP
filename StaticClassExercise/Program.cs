namespace Exercise
{
    using System;
    public class Startup
    {
        static void Main()
        {
            var arr = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.WriteLine(string.Join(", ", Mover.MoveRight(arr)));

            Console.WriteLine(string.Join(", ", Mover.MoveLeft(arr)));
        }
    }
}
