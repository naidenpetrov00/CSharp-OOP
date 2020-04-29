namespace Singleton
{
    using System;

    public class Startup
    {
        static void Main(string[] args)
        {
            var db = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("Sofeto"));

            var db2 = SingletonDataContainer.Instance;
            Console.WriteLine(db2.GetPopulation("Pernik"));
        }
    }
}
