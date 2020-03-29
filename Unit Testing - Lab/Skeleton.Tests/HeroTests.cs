using Moq;
using NUnit.Framework;
using Skeleton;

[TestFixture]
public class HeroTest
{
    private const string HeroName = "Denis";

    [Test]
    public void Hero_Gains_Experience_When_Kills_Target()
    {
        //Arange
        Mock<ITarget> target = new Mock<ITarget>();
        target
            .Setup(t => t.Health)
            .Returns(0);
        target
            .Setup(t => t.GiveExperience())
            .Returns(20);
        target
            .Setup(t => t.IsDead())
            .Returns(true);
        Mock<IWeapon> weapon = new Mock<IWeapon>();

        var hero = new Hero(HeroName, weapon.Object);

        //Act
        hero.Attack(target.Object);

        //Assert
        Assert.That(hero.Experience, Is.EqualTo(20), "Hero is not gaining Exeperience!");
    }
}