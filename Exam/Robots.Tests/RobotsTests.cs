namespace Robots.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        private const int capacityWithValueOne = 1;
        private const int capacity = 5;
        private const int anotherCapacity = 10;
        private const int negativeCapacity = -1;
        private const string robotNameGosho = "Gosho";
        private const string robotNamePesho = "Pesho";
        private const string RandomName = "RandomName";
        private const int maximumBattery = 100;
        private const int LowBattery = 10;

        private RobotManager EmptyManager;
        private RobotManager manager;
        private Robot robotOne = new Robot(robotNameGosho, maximumBattery);
        private Robot robotTwo = new Robot(robotNamePesho, LowBattery);
        private Robot robotThree = new Robot(robotNamePesho, maximumBattery);

        [SetUp]
        public void Init()
        {
            this.manager = new RobotManager(capacity);
        }

        [Test]
        public void ConstructorCreateCorrectly()
        {
            this.EmptyManager = new RobotManager(capacity);

            Assert.That(this.manager, Is.Not.Null, "Constructor not correct");
            Assert.That(this.manager.Capacity, Is.EqualTo(capacity), "Constructor not correct");
        }

        [Test]
        public void CapacityShouldReturnCorreclty()
        {
            Assert.That(this.manager.Capacity, Is.EqualTo(capacity), "Capacity getter not correct");
        }

        [Test]
        public void CapacityCannotTakeBelowZero()
        {
            Assert.Throws<ArgumentException>(() => this.EmptyManager = new RobotManager(negativeCapacity));
        }

        [Test]
        public void AddShouldAddCorrectly()
        {
            this.manager.Add(this.robotOne);
            this.manager.Add(this.robotTwo);

            Assert.That(this.manager.Count, Is.EqualTo(2), "Add not correct");
        }

        [Test]
        public void AddCannotAddIfRobotExist()
        {
            this.manager.Add(this.robotOne);

            Assert.Throws<InvalidOperationException>(() => this.manager.Add(this.robotOne));
        }

        [Test]
        public void AddCannotAddIfCapacityFull()
        {
            this.manager = new RobotManager(capacityWithValueOne);
            this.manager.Add(robotOne);

            Assert.Throws<InvalidOperationException>(() => this.manager.Add(this.robotTwo));
        }

        [Test]
        public void RemoveShouldRemoveCorrectly()
        {
            this.manager.Add(this.robotOne);
            this.manager.Add(this.robotTwo);
            this.manager.Remove(robotTwo.Name);

            Assert.That(this.manager.Count, Is.EqualTo(1), "Remove not correct");
        }

        [Test]
        public void CannotRemoveIfDoesntExist()
        {
            this.manager.Add(robotOne);

            Assert.Throws<InvalidOperationException>(() => this.manager.Remove(RandomName), $"Robot with the name {RandomName} doesn't exist!");
        }

        [Test]
        public void WorkIsCoorect()
        {
            this.manager.Add(robotOne);
            this.manager.Work(robotNameGosho, "Job", 50);

            Assert.That(this.robotOne.Battery, Is.EqualTo(50));
        }

        [Test]
        public void CannotWorkIfDoesntExist()
        {
            this.manager.Add(robotOne);

            Assert.Throws<InvalidOperationException>(() => this.manager.Work(RandomName, "Job", 50), $"Robot with the name {RandomName} doesn't exist!");
        }

        [Test]
        public void CannotWorkIfBatteryLow()
        {
            this.manager.Add(robotTwo);

            Assert.Throws<InvalidOperationException>(() => this.manager.Work(robotNamePesho, "Job", 100), $"{robotNamePesho} doesn't have enough battery!");
        }

        [Test]
        public void CannotChargeIfDoesntExist()
        {
            this.manager.Add(robotOne);

            Assert.Throws<InvalidOperationException>(() => this.manager.Charge(RandomName), $"Robot with the name {RandomName} doesn't exist!");
        }

        [Test]
        public void ChargeISCharging()
        {
            this.manager.Add(robotThree);
            this.manager.Work(robotNamePesho, "kopane", 50);
            this.manager.Charge(robotNamePesho);

            Assert.That(robotThree.Battery, Is.EqualTo(robotThree.MaximumBattery));
        }

        [Test]
        public void CountShouldReturnCorrectly()
        {
            this.manager.Add(this.robotOne);
            this.manager.Add(this.robotTwo);

            Assert.That(this.manager.Count, Is.EqualTo(2), "Count getter not correct");
        }

        [Test]
        public void RobotConstructorWorksCorrectly()
        {
            var robot = new Robot("ivan", 100);

            Assert.That(robot, Is.Not.Null);

            Assert.That(robot.Name, Is.EqualTo("ivan"));
            Assert.That(robot.Battery, Is.EqualTo(100));
            Assert.That(robot.MaximumBattery, Is.EqualTo(100));
        }

        [Test]
        public void RobotMaxBatteryWorksCorrectly()
        {
            var robot = new Robot("ivan", 100);

            Assert.That(robot.MaximumBattery, Is.EqualTo(100));
        }
    }
}
