namespace CustomRandomList
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var myList = new RandomList() { "pizza", "spaghetti", "bread"};

            Console.WriteLine($"Today im gonna eat {myList.RandomString()}");
        }
    }
}
