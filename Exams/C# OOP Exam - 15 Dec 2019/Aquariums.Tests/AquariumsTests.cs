namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        private const string aquariumName = "Black kingdom";
        private const int capacity = 2;
        private const int negativeCapacity = -1;

        private const string fishName = "Gosho";
        private const string anotherFishName = "Petur";
        private const string notExistingNameOfAFish = "123";

        private Aquarium aquarium;

        private Fish fish = new Fish(fishName);
        private Fish anotherFish = new Fish(anotherFishName);

        [SetUp]
        public void TestInit()
        {
            this.aquarium = new Aquarium(aquariumName, capacity);
        }

        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            Assert.That(this.aquarium.Name, Is.EqualTo(aquariumName), "Constructor does not initialized Name property correct!");
            Assert.That(this.aquarium.Capacity, Is.EqualTo(capacity), "Constructor does not initialized Capacity property correct!");
        }

        [Test]
        public void NameCannotBeNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, capacity), "Invalid aquarium name!");
        }

        [Test]
        public void NameCannotBeEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(string.Empty, capacity), "Invalid aquarium name!");
        }

        [Test]
        public void CapacityCannotBeBelowZero()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium(aquariumName, negativeCapacity), "Invalid aquarium capacity!");
        }

        [Test]
        public void CountCannotBeBelowZero()
        {
            Assert.That(this.aquarium.Count, Is.Not.Negative, "Count cannot be below zero!");
        }


        [Test]
        public void CannotAddFishToFullAquarium()
        {
            this.aquarium.Add(this.fish);
            this.aquarium.Add(this.anotherFish);

            Assert.Throws<InvalidOperationException>(() => this.aquarium.Add(this.fish), "Aquarium is full!");
        }

        [Test]
        public void AddShouldAddFishCorrectly()
        {
            this.aquarium.Add(this.fish);

            Assert.That(this.aquarium.Count, Is.EqualTo(1), "Fish not added to aquarium");
        }

        [Test]
        public void CannotRemoveFishThatIsNotExisting()
        {
            this.aquarium.Add(this.fish);

            Assert
                .Throws<InvalidOperationException>
                (() => this.aquarium.RemoveFish(notExistingNameOfAFish), ($"Fish with the name {notExistingNameOfAFish} doesn't exist!"));
            
        }

        [Test]
        public void RemoveShouldRemoveFishCorrectly()
        {
            this.aquarium.Add(this.fish);

            this.aquarium.RemoveFish(fishName);

            Assert.That(this.aquarium.Count, Is.EqualTo(0), "Fish not removed from aquarium");
        }


        [Test]
        public void CannotSellFishThatIsNotExisting()
        {
            this.aquarium.Add(this.fish);

            Assert
                .Throws<InvalidOperationException>
                (() => this.aquarium.SellFish(notExistingNameOfAFish), ($"Fish with the name {notExistingNameOfAFish} doesn't exist!"));

        }

        [Test]
        public void SellShouldSellFishCorrectly()
        {
            this.aquarium.Add(this.fish);

            var soldedFish = this.aquarium.SellFish(fishName);

            Assert.That(soldedFish.Available, Is.False, "Fish not solded from aquarium");
        }

        [Test]
        public void ReportShouldReturnCorrectInformation()
        {
            this.aquarium.Add(this.fish);
            this.aquarium.Add(this.anotherFish);

            var fishNames = $"{fishName}, {anotherFishName}";
            var customReport = $"Fish available at {this.aquarium.Name}: {fishNames}";

            Assert.That(this.aquarium.Report, Is.EqualTo(customReport));
        }
    }
}
