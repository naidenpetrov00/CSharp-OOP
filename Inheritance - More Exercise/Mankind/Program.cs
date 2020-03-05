namespace Mankind
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        static void Main(string[] args)
        {
            string[] stud = Console.ReadLine()
                .Split(' ')
                .ToArray();
            string[] work = Console.ReadLine()
                .Split(' ')
                .ToArray();

            var student = new Student(stud[0], stud[1], stud[2]);
            var worker = new Worker(work[0], work[1], int.Parse(work[2]), int.Parse(work[3]));

            Console.WriteLine(student);
            Console.WriteLine(worker);

        }
    }
}
