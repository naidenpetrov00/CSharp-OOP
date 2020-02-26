namespace _2.PointinRectangle
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var coordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var topCoordinates = new Point(coordinates[0], coordinates[1]);
            var bottomCoordinates = new Point(coordinates[2], coordinates[3]);

            var rectangle = new Rectangle(topCoordinates, bottomCoordinates);
            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var coords = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                var coordinatesForValidation = new Point(coords[0], coords[1]);

                Console.WriteLine(rectangle.Contains(coordinatesForValidation));
            }
        }
    }
}

