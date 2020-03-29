using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;
    private Axe weapon;
    private const int BonusAttackPointsToKill = 90;
    private const int LeftedHealth = 90;
    private const int GainedExperience = 100;

    [SetUp]
    public void TestInit()
    {
        this.dummy = new Dummy(100, 100);
        this.weapon = new Axe(10, 10);
    }

    [Test]
    public void DummyLosesHealthIfAttacked()
    {
        //Act
        this.dummy.TakeAttack(this.weapon.AttackPoints);

        //Assert
        Assert.That(this.dummy.Health, Is.EqualTo(LeftedHealth), "Dummy doesn't loose health when attacked!");
    }

    [Test]
    public void DeadDummyCannotBeAttacked()
    {
        //Act
        this.dummy.TakeAttack(this.weapon.AttackPoints + BonusAttackPointsToKill);

        //Assert
        Assert.That(() => dummy.TakeAttack(weapon.AttackPoints), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyCanGiveXP()
    {
        //Act
        this.dummy.TakeAttack(this.weapon.AttackPoints + BonusAttackPointsToKill);

        //Assert
        Assert.That(this.dummy.GiveExperience(), Is.EqualTo(GainedExperience));
    }

    [Test]
    public void AliveDummyCantGiveXP()
    {
        //Act
        this.dummy.TakeAttack(this.weapon.AttackPoints);

        //Assert
        Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}
