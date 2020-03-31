using NUnit.Framework;
using System;
using System.Linq;

[TestFixture]
public class DatabaseTests
{
    private Database dataBaseWithFullCapacity;
    private Database dataBaseWithNonFullCapacity;
    private Database emptyDataBase;
    private int[] bigArray = Enumerable.Range(1, 17).ToArray();
    private const int ElementToAdd = 17;
    private const int MaxSize = 16;
    private int[] arrayCopy;

    [SetUp]
    public void Setup()
    {
        this.dataBaseWithFullCapacity = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
        this.dataBaseWithNonFullCapacity = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        this.emptyDataBase = new Database();
    }

    [Test]
    public void CountMustReturnExactLength() => Assert.That(dataBaseWithFullCapacity.Count, Is.EqualTo(MaxSize), "Count return is not correct");

    [Test]
    public void StoringArrayCapacityMustBe16Elements() => Assert.Throws<InvalidOperationException>(() => dataBaseWithFullCapacity.Add(ElementToAdd), "Array's capacity must be exactly 16 integers!");

    [Test]
    public void ElementIsAddedAtTheNextIndex()
    {
        this.dataBaseWithNonFullCapacity.Add(ElementToAdd);

        this.arrayCopy = this.dataBaseWithNonFullCapacity.Fetch();
        Assert.That(arrayCopy[arrayCopy.Length - 1], Is.EqualTo(ElementToAdd), "Add method should add an element at the next free cell");
    }

    [Test]
    public void RemoveOperationCannotRemoveFromEmptyCollection() => Assert.Throws<InvalidOperationException>(() => this.emptyDataBase.Remove(), "The collection is empty!");

    [Test]
    public void RemoveShouldDeleteTheElementAtTheLastIndex()
    {
        var arrayCopyWithLastElement = this.dataBaseWithNonFullCapacity.Fetch();
        this.dataBaseWithNonFullCapacity.Remove();
        var arrayCopyWithoutLastElement = this.dataBaseWithNonFullCapacity.Fetch();

        Assert.That(arrayCopyWithLastElement.SkipLast(1), Is.EqualTo(arrayCopyWithoutLastElement), "Remove operation doesnt remove at the last index");
    }

    [Test]
    public void ConstructorsTakeOnlyIntegers()
    {
        var expectedArr = new int[] { 1, 2, 3 };
        this.emptyDataBase = new Database(expectedArr);
        var arrayCopy = this.emptyDataBase.Fetch();

        Assert.That(arrayCopy, Is.EqualTo(expectedArr), "Constructor is not implementing correctly");
        Assert.That(arrayCopy is Array, "Constructor is not implementing correctly");
    }

    [Test]
    public void ConstructorShouldThrowWithManyElements() => Assert.That(() => new Database(this.bigArray), Throws.InvalidOperationException);

    [Test]
    public void FetchReturnElementsAsArray() => Assert.That(() => this.dataBaseWithFullCapacity.Fetch() is Array, "Fetch is not returning array");

    [Test]
    public void ComplexFunctionalityTest()
    {
        var db = new Database(1, 2, 3, 4, 5);
        db.Remove();
        db.Remove();
        db.Remove();
        db.Add(13);
        db.Add(14);
        db.Remove();

        var expected = new int[] { 1, 2, 13 };
        var actual = db.Fetch();

        Assert.That(actual, Is.EqualTo(expected), "Complex functionality is broken");
    }
}