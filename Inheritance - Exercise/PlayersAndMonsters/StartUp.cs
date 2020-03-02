namespace PlayersAndMonsters
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var name = "Gosho";
            var level = 6;
            var champ = new SoulMaster(name, level);

            Console.WriteLine(champ);
        }
    }
}