using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private const string FirstDriverName = "Naiden";
        private const string SecondDriverName = "Ralica";
        private string[] CarModel = new string[] { "Sport", "Muscle", "Drift" };
        private int[] CarHorsePower = new int[] { 200, 500, 300 };
        private double[] CarCubicPower = new double[] { 2300, 4000, 2500 };


        private RaceEntry race;
        private UnitDriver firstDriver;
        private UnitDriver secondDriver;
        private UnitCar sportCar;
        private UnitCar muscleCar;

        [SetUp]
        public void Setup()
        {
            this.race = new RaceEntry();

            this.sportCar = new UnitCar(this.CarModel[0], this.CarHorsePower[0], this.CarCubicPower[0]);
            this.muscleCar = new UnitCar(this.CarModel[1], this.CarHorsePower[1], this.CarCubicPower[1]);

            this.firstDriver = new UnitDriver(FirstDriverName, this.sportCar);
            this.secondDriver = new UnitDriver(SecondDriverName, this.muscleCar);
        }

        [Test]
        public void ConstructorShouldInstanciateCorrectly()
        {
            Assert.IsNotNull(this.race);
        }

        [Test]
        public void AddDriverMethodShouldAddDriverCorrectly()
        {
            this.race.AddDriver(this.firstDriver);

            Assert.IsNotNull(this.race, "The driver was not added!");
        }

        [Test]
        public void AddMethodShouldReturnCorrectly()
        {
            var message = this.race.AddDriver(this.firstDriver);

            Assert.That(message, Is.EqualTo($"Driver {this.firstDriver.Name} added in race."));
        }

        [Test]
        public void AddDriverMethodShouldntAddNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.race.AddDriver(null), "Method is adding null value driver!");    
        }    

        [Test]
        public void AddMethodCannotAddExsistingDriver()
        {
            this.race.AddDriver(this.firstDriver);

            Assert.Throws<InvalidOperationException>(() => this.race.AddDriver(this.firstDriver), "Method is adding exsisting driver!");
        }

        [Test]
        public void CounterShouldReturnCorrectCount()
        {
            this.race.AddDriver(this.firstDriver);
            this.race.AddDriver(this.secondDriver);

            var count = this.race.Counter;

            Assert.That(count, Is.EqualTo(2), "Counter is not retrning correct count of object!");
        }

        [Test]
        public void RacePointsCalculatorShouldCalculateCorrectly()
        {
            this.race.AddDriver(this.firstDriver);
            this.race.AddDriver(this.secondDriver);
            var result = (this.firstDriver.Car.HorsePower + this.secondDriver.Car.HorsePower) / this.race.Counter;

            Assert.That(this.race.CalculateAverageHorsePower, Is.EqualTo(result));
        }

        [Test]
        public void RaceCannotStartWithParticipantsLessThenMinimum()
        {
            this.race.AddDriver(this.firstDriver);

            Assert.Throws<InvalidOperationException>(() => this.race.CalculateAverageHorsePower());
        }
    }
}
/*You will receive a skeleton with RaceEntry, UnitCar and UnitDriver classes inside. The class will 
 * have some methods, properties, fields and one constructor, which are working properly.
 * You are NOT ALLOWED to change any class. Cover the whole class (RaceEntry) with unit tests to make sure that the class is working as intended. 
You are provided with a unit test project in the project skeleton. DO NOT modify its NuGet packages.
Do NOT use Mocking in your unit tests!
*/