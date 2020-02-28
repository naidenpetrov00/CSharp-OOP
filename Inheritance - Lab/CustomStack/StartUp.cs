namespace CustomStack
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new StackOfStrings();
            var arr = new string[] { "banichka", "bozichka", "rakjq" };

            stack.IsEmpty();
            stack.AddRange(arr);
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
