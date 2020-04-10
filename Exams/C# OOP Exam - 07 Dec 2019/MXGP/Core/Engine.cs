namespace MXGP
{
    using MXGP.Core.Contracts;
    using MXGP.IO;
    using MXGP.IO.Contracts;
    using System;

    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IChampionshipController controller;

        public Engine()
        {
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
            this.controller = new ChampionshipController();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = reader.ReadLine().Split();
                if (input[0] == "End")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string result = string.Empty;
                    if (input[0] == "CreateRider")
                    {
                        var name = input[1];

                        result = this.controller.CreateRider(name);
                    }
                    else if (input[0] == "CreateMotorcycle")
                    {
                        var type = input[1];
                        var model = input[2];
                        var HP = int.Parse(input[3]);

                        result = this.controller.CreateMotorcycle(type, model, HP);
                    }
                    else if (input[0] == "AddMotorcycleToRider")
                    {
                        var name = input[1];
                        var model = input[2];

                        result = this.controller.AddMotorcycleToRider(name, model);
                    }
                    else if (input[0] == "AddRiderToRace")
                    {
                        var raceName = input[1];
                        var riderName = input[2];

                        result = this.controller.AddRiderToRace(raceName, riderName);
                    }
                    else if (input[0] == "CreateRace")
                    {
                        var name = input[1];
                        var laps = int.Parse(input[2]);

                        result = this.controller.CreateRace(name, laps);
                    }
                    else if (input[0] == "StartRace")
                    {
                        var raceName = input[1];

                        result = this.controller.StartRace(raceName);
                    }

                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}