using NUnit.Framework;
using Skeleton;

[TestFixture]
public class AxeTests
{
    private IWeapon weapon;
    private ITarget dummy;

    [SetUp]
    public void TestInit()
    {
        this.weapon = new Axe(10, 1);
        this.dummy = new Dummy(100, 100);
    }

    [Test]
    public void WeaponLosesDurabilityAfterAttack()
    {
        //Act
        this.weapon.Attack(this.dummy);

        //Assert
        Assert.That(weapon.DurabilityPoints, Is.EqualTo(0), "Axe durability doesnt change after attack");
    }

    [Test]
    public void BrokenWeaponCannotAttack()
    {
        //Act
        weapon.Attack(dummy);

        //Assert
        Assert.That(() => weapon.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}