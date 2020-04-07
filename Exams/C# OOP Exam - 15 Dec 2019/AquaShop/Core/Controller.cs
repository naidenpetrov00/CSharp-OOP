namespace AquaShop
{
    using AquaShop.Core.Contracts;
    using AquaShop.Models.Aquariums;
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private DecorationRepository decorations = new DecorationRepository();
        private List<IAquarium> aquariums = new List<IAquarium>();

        public Controller() { }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == nameof(FreshwaterAquarium))
            {
                this.aquariums.Add(new FreshwaterAquarium(aquariumName));

                return $"Successfully added {aquariumType}.";
            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                this.aquariums.Add(new SaltwaterAquarium(aquariumName));

                return $"Successfully added {aquariumType}.";
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == nameof(Ornament))
            {
                this.decorations.Add(new Ornament());

                return $"Successfully added {decorationType}.";
            }
            else if (decorationType == nameof(Plant))
            {
                this.decorations.Add(new Plant());

                return $"Successfully added {decorationType}.";
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != nameof(FreshwaterFish) && fishType != nameof(SaltwaterFish))
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

           var aquariume = AquariumExcistingValidator(aquariumName);

            if (nameof(aquariume).StartsWith("Fresh") && fishType.StartsWith("Fresh"))
            {
                foreach (var aquarium in this.aquariums)
                {
                    if (aquarium.Name == aquariumName)
                    {
                        aquarium.AddFish(new FreshwaterFish(fishName, fishSpecies, price));
                    }
                }

                return $"Successfully added {fishType} to {aquariumName}.";
            }
            else if (nameof(aquariume).StartsWith("Salt") && fishType.StartsWith("Salt"))
            {
                foreach (var aquarium in this.aquariums)
                {
                    if (aquarium.Name == aquariumName)
                    {
                        aquarium.AddFish(new SaltwaterFish(fishName, fishSpecies, price));
                    }
                }

                return $"Successfully added {fishType} to {aquariumName}.";
            }
            else
            {
                return $"Water not suitable.";
            }
        }

        public string CalculateValue(string aquariumName)
        {
            decimal fullPrice = 0;

            var aquariume = AquariumExcistingValidator(aquariumName);

            foreach (var fish in aquariume.Fish)
            {
                fullPrice += fish.Price;
            }
            foreach (var decoration in aquariume.Decorations)
            {
                fullPrice += decoration.Price;
            }

            return $"The value of Aquarium {aquariumName} is {fullPrice : F2}.";
        }

        public string FeedFish(string aquariumName)
        {
            var fedCount = 0;

            foreach (var aquarium in this.aquariums)
            {
                foreach (var fish in aquarium.Fish)
                {
                    fish.Eat();
                    fedCount++;
                }
            }

            return $"Fish fed: {fedCount}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException("There isn't a decoration of type {decorationType}.");
            }

            var aquariume = AquariumExcistingValidator(aquariumName);

            foreach (var aquarium in this.aquariums)
            {
                if (aquarium.Name == aquariumName)
                {
                    aquarium.AddDecoration(decoration);
                }
            }

            this.decorations.Remove(decoration);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            var report = new StringBuilder();

            foreach (var aquariume in this.aquariums)
            {
                report.AppendLine(aquariume.GetInfo());
            }

            return report.ToString().Trim();
        }

        public IAquarium AquariumExcistingValidator(string aquariumName)
        {
            var aquarium = (IAquarium)this.aquariums.Where(a => a.Name.Equals(aquariumName));

            if (aquarium == null)
            {
                throw new ArgumentException($"{aquariumName} does not stand in aquariums");
            }

            return aquarium;
        }
    }
}
