namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ProductTests
    {
        private Product firstProductToCompare = new Product("FirstTest", 3, 1);
        private Product secondProductToCompare = new Product("SecondTest", 2, 1);
        private Product thirdProductToCompare = new Product("ThirdTest", 2, 1);

        [SetUp]
        public void InitProgram()
        {
        }

        [Test]
        public void LabelCannotBeNull()
        {
            Assert.Throws<ArgumentException>(() => new Product(null, 5, 1), "Label cannot be null or empty!");
        }

        [Test]
        public void LabelCannotBeEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Product(string.Empty, 5, 1), "Label cannot be null or empty!");
        }

        [Test]
        public void PriceCannotBeLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => new Product("Test", -1, 1), "Price cannot be less than zero!");
        }

        [Test]
        public void QuantityCannotBeLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => new Product("Test", 5, -1), "Quantity cannot be less than zero!");
        }

        [Test]
        public void ProductShouldBeComparedByPriceWhenCorrect()
        {
            var correctResult = this.firstProductToCompare.CompareTo(this.secondProductToCompare);

            Assert.That(correctResult > 0, Is.True, "Products are not compared by price in descending order!");
        }

        [Test]
        public void ProductShouldBeComparedByPriceWhenInCorrect()
        {
            var inCorrectResult = this.secondProductToCompare.CompareTo(this.firstProductToCompare);

            Assert.That(inCorrectResult < 0, Is.True, "Products are not compared by price in descending order!");
        }

        [Test]
        public void ProductShouldBeComparedByPriceWhenEqual()
        {
            var equalResult = this.secondProductToCompare.CompareTo(this.thirdProductToCompare);

            Assert.That(equalResult == 0, Is.True, "Products are not compared by price in descending order!");
        }
    }
}