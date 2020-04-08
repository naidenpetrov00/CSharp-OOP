namespace AquaShop
{
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private List<IDecoration> decorations;
        private List<IFish> fishes;

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fishes = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            private set { this.capacity = value; }
        }

        public int Comfort
        {
            get => this.ComfortCalculator();
        }

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fishes;

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fishes.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            else if (fishes.Count < this.Capacity)
            {
                this.Fish.Add(fish);
            }
        }

        public void Feed()
        {
            foreach (var fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var info = new StringBuilder();

            info.AppendLine($"{this.Name} ({this.GetType().Name}):");

            if (this.Fish.Count == 0)
            {
                info.AppendLine($"Fish: none");
            }
            else
            {
                info.AppendLine($"Fish: {string.Join(", ", this.Fish.Select(f => f.Name))}");
            }

            info.AppendLine($"Decorations: {this.decorations.Count}");
            info.AppendLine($"Comfort: {this.Comfort}");

            return info.ToString().Trim();
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fishes.Remove(fish);
        }

        private int ComfortCalculator()
        {
            var result = 0;

            foreach (var decoration in this.Decorations)
            {
                result += decoration.Comfort;
            }

            return result;
        }
    }
}
