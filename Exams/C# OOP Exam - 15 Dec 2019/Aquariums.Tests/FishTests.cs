namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class FishTests
    {
        [Test]
        public void ConstructorShouldAddCorrectly()
        {
            var fish = new Fish("Gosho");

            Assert.That(fish.Name, Is.EqualTo("Gosho"), "Constructor does not initialized Name property correct!");
            Assert.That(fish.Available, Is.True, "Constructor does not initialized Available property correct!");
        }
    }
}
