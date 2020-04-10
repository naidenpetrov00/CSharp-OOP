namespace TheRace.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RaceEntryTests
    {
        private const string RiderNameMartin = "Martin";
        private const string RiderNameNaiden = "Naiden";
        private const string MotorcycleModel = "Naiden";
        private const int MotorcycleHP = 80;
        private const int MotorcycleCubicCentimeters = 450;

        private RaceEntry basicRace;
        private UnitRider basicRiderOne;
        private UnitRider basicRiderTwo;
        private UnitMotorcycle basicMotorcycle = new UnitMotorcycle(MotorcycleModel, MotorcycleHP, MotorcycleCubicCentimeters);


        [SetUp]
        public void Setup()
        {
            this.basicRiderOne = new UnitRider(RiderNameMartin, basicMotorcycle);
            this.basicRiderTwo = new UnitRider(RiderNameNaiden, basicMotorcycle);
            this.basicRace = new RaceEntry();
            this.basicRiderOne = new UnitRider(RiderNameMartin, basicMotorcycle);
            this.basicRiderTwo = new UnitRider(RiderNameNaiden, basicMotorcycle);
        }

        [Test]
        public void ConstructorShoulInstantiatesCorreclty()
        {
            Assert.IsNotNull(this.basicRace);
        }

        [Test]
        public void AddRiderShouldAddCorrectly()
        {
            this.basicRace.AddRider(basicRiderOne);

            Assert.That(this.basicRace, Is.Not.Null, "Add method doesnt add correctly!");
        }

        [Test]
        public void RaceCannotAddNullRider()
        {
            Assert.Throws<InvalidOperationException>(() => this.basicRace.AddRider(null), "Rider cannot be null.");
        }

        [Test]
        public void RaceCannotAddExistingRider()
        {
            this.basicRace.AddRider(this.basicRiderOne);

            Assert.Throws<InvalidOperationException>(() => this.basicRace.AddRider(this.basicRiderOne), $"Rider {this.basicRiderOne.Name} is already added.");
        }

        [Test]
        public void AddRiderShouldReturnCorrectly()
        {
            var result = this.basicRace.AddRider(this.basicRiderOne);
            var expectedResult = $"Rider {this.basicRiderOne.Name} added in race.";

            Assert.That(result, Is.EqualTo(expectedResult), "Return value is not correct!");
        }

        [Test]
        public void CounterShouldReturnCorrectly()
        {
            this.basicRace.AddRider(basicRiderOne);
            this.basicRace.AddRider(basicRiderTwo);

            Assert.That(this.basicRace.Counter, Is.EqualTo(2), "Counter value is not correct!");
        }

        [Test]
        public void CannotCalculateAverageHorsePowerFromLessThanTwoMotorcycles()
        {
            this.basicRace.AddRider(basicRiderOne);

            Assert.Throws<InvalidOperationException>(() => this.basicRace.CalculateAverageHorsePower(), $"The race cannot start with less than 2 participants.");
        }

        [Test]
        public void CalculateAverageHorsePowerCalculatesCorrectly()
        {
            this.basicRace.AddRider(basicRiderOne);
            this.basicRace.AddRider(basicRiderTwo);

            Assert.That(this.basicRace.CalculateAverageHorsePower(), Is.EqualTo(MotorcycleHP), "Averge value is not calculated correclty!");
        }
    }
}
//You will receive a skeleton with RaceEntry, UnitMotorcycle and UnitRider classes inside.The class will have some methods, properties, fields and one constructor, which are working properly.You are NOT ALLOWED to change any class. Cover the whole class (RaceEntry) with unit tests to make sure that the class is working as intended.
//You are provided with a unit test project in the project skeleton.DO NOT modify its NuGet packages.
//Note: The TheRace you need to test is in the global namespace, so remove any using statements, pointing towards the namespace TheRace.
//Do NOT use Mocking in your unit tests!
