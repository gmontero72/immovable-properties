using RI.Novus.Core.ImmovableOwner;

namespace RI.Novus.Core.Facts.ImmovableOwner.ImmovableOwnerFacts.IdentificationNumberFacts;
[TestFixture]
internal sealed class FromMessageFacts
{
    [TestCase("adadadadadadadad")]
    public void With_Valid_identificationNumbers_Throws_Nothing(string rawIdentificationNumber)
        => Assert.That(() => IdentificationNumber.From(rawIdentificationNumber), Throws.Nothing);

    [Test]
    public void With_Null_Throws_ArgumentNullException()
        => Assert.That(() => IdentificationNumber.From(null), Throws.ArgumentNullException);

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("  ")]
    public void With_Empty_Throws_ArgumentOutOfRangeException(string rawIdentificationNumber)
        => Assert.That(() => IdentificationNumber.From(rawIdentificationNumber), Throws.InstanceOf<ArgumentOutOfRangeException>());

    [TestCase("                ")]
    [TestCase("                ")]
    public void With_Empty_And_Larger_Than_Minimum_Throws_FormatException(string rawIdentificationNumber)
        => Assert.That(() => IdentificationNumber.From(rawIdentificationNumber), Throws.InstanceOf<FormatException>());

    [TestCase(1)]
    [TestCase(3)]
    [TestCase(129)]
    [TestCase(256)]
    public void With_identificationNumbers_Length_Outside_Boundaries_Throws_ArgumentOutOfRangeException(int length)
    {
        string rawIdentificationNumber = new('a', length);

        Assert.That(() => IdentificationNumber.From(rawIdentificationNumber), Throws.InstanceOf<ArgumentOutOfRangeException>());
    }
}
