namespace AquaShop
{
    using AquaShop.Core.Contracts;
    using AquaShop.Models.Aquariums;
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations;
    using AquaShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == nameof(FreshwaterAquarium))
            {
                this.aquariums.Add(new FreshwaterAquarium(aquariumName));

                return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                this.aquariums.Add(new SaltwaterAquarium(aquariumName));

                return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == nameof(Ornament))
            {
                this.decorations.Add(new Ornament());

                return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
            }
            else if (decorationType == nameof(Plant))
            {
                this.decorations.Add(new Plant());

                return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != nameof(FreshwaterFish) && fishType != nameof(SaltwaterFish))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            var aquarium = AquariumExistingValidator(aquariumName);

            if (aquarium.GetType().Name.StartsWith("Fresh") && fishType.StartsWith("Fresh"))
            {
                this.aquariums.Find(a => a.Name.Equals(aquariumName)).AddFish(new FreshwaterFish(fishName, fishSpecies, price));

                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else if (aquarium.GetType().Name.StartsWith("Salt") && fishType.StartsWith("Salt"))
            {
                this.aquariums.Find(a => a.Name.Equals(aquariumName)).AddFish(new SaltwaterFish(fishName, fishSpecies, price));

                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else
            {
                return OutputMessages.UnsuitableWater;
            }
        }

        public string CalculateValue(string aquariumName)
        {
            decimal fullPrice = 0;

            var aquariume = AquariumExistingValidator(aquariumName);

            foreach (var fish in aquariume.Fish)
            {
                fullPrice += fish.Price;
            }
            foreach (var decoration in aquariume.Decorations)
            {
                fullPrice += decoration.Price;
            }

            return string.Format(OutputMessages.AquariumValue, aquariumName, fullPrice);
        }

        public string FeedFish(string aquariumName)
        {
            var fedCount = 0;

            var aquarium = AquariumExistingValidator(aquariumName);

            foreach (var fish in aquarium.Fish)
            {
                fish.Eat();
                fedCount++;
            }

            return string.Format(OutputMessages.FishFed, fedCount);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            var aquariume = AquariumExistingValidator(aquariumName);

            this.aquariums.Find(a => a.Name.Equals(aquariumName)).AddDecoration(decoration);

            this.decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
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

        private IAquarium AquariumExistingValidator(string aquariumName)
        {
            var aquarium = this.aquariums.Find(a => a.Name.Equals(aquariumName));

            if (aquarium == null)
            {
                throw new ArgumentException($"Aquarium: {aquariumName} does not exist!");
            }

            return aquarium;
        }
    }
}
