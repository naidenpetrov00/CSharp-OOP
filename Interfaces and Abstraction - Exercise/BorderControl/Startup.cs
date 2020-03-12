namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var informationForIncomer = new string[] { };
            List<Citizen> citizens = new List<Citizen>();
            List<Robot> robots = new List<Robot>();
            List<string> ids = new List<string>();

            while (true)
            {
                informationForIncomer = Console.ReadLine()
                    .Split(' ')
                    .ToArray();
                if (informationForIncomer[0] == "End")
                {
                    break;
                }

                if (informationForIncomer.Length == 3)
                {
                    ids.Add(informationForIncomer[2]);
                    citizens = ArrOfIncomerCitizensAdder(informationForIncomer, citizens);
                }
                else if (true)
                {
                    ids.Add(informationForIncomer[1]);
                    robots = ArrOfIncomerRobotsAdder(informationForIncomer, robots);
                }

            }

            var fakeIdsEnding = Console.ReadLine();

            foreach (var id in ids)
            {
                if (id.Substring(id.Length - 3) == fakeIdsEnding)
                {
                    Console.WriteLine(id);
                }
            }

        }

        public static List<Citizen> ArrOfIncomerCitizensAdder(string[] informationForIncomer, List<Citizen> Incomers)
        {
            var name = informationForIncomer[0];
            var age = int.Parse(informationForIncomer[1]);
            var idNumber = informationForIncomer[2].ToCharArray();
            Citizen citizen = new Citizen(name, age, idNumber);

            Incomers.Add(citizen);
            return Incomers;
        }

        public static List<Robot> ArrOfIncomerRobotsAdder(string[] informationForIncomer, List<Robot> Incomers)
        {
            var model = string.Empty;
            var idNumber = informationForIncomer[1].ToCharArray();
            Robot robot = new Robot(model, idNumber);

            Incomers.Add(robot);
            return Incomers;
        }
    }
}
