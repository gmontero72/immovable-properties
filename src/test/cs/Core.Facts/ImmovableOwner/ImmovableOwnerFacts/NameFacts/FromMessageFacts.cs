using RI.Novus.Core.ImmovableOwner;

namespace RI.Novus.Core.Facts.ImmovableOwner.ImmovableOwnerFacts.NameFacts;
[TestFixture]
internal sealed class FromMessageFacts
{
    [TestCase("Pedro Pablo")]
    public void With_Valid_Names_Throws_Nothing(string rawName)
        => Assert.That(() => Name.From(rawName), Throws.Nothing);

    [Test]
    public void With_Null_Throws_ArgumentNullException()
        => Assert.That(() => Name.From(null), Throws.ArgumentNullException);

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("  ")]
    public void With_Empty_Throws_ArgumentOutOfRangeException(string rawName)
        => Assert.That(() => Name.From(rawName), Throws.InstanceOf<ArgumentOutOfRangeException>());

    [TestCase("     ")]
    [TestCase("          ")]
    public void With_Empty_And_Larger_Than_Minimum_Throws_FormatException(string rawName)
        => Assert.That(() => Name.From(rawName), Throws.InstanceOf<FormatException>());

    [TestCase(1)]
    [TestCase(3)]
    [TestCase(129)]
    [TestCase(256)]
    public void With_Names_Length_Outside_Boundaries_Throws_ArgumentOutOfRangeException(int length)
    {
        string rawName = new('a', length);

        Assert.That(() => Name.From(rawName), Throws.InstanceOf<ArgumentOutOfRangeException>());
    }

    [TestCase(" Hello World")]
    [TestCase("Hello World ")]
    [TestCase(" Hello World ")]
    public void With_Leading_Or_Trailing_White_Spaces_Throws_FormatException(string rawName)
        => Assert.That(() => Name.From(rawName), Throws.InstanceOf<FormatException>());

    [Test]
    [TestCaseSource(typeof(OneTimeSetupFixture), nameof(OneTimeSetupFixture.ControlCharacters))]
    public void With_Control_Characters_Throws_FormatException(char value)
    {
        string rawExpedientName = $"This is a name{value}";

        Assert.That(() => Name.From(rawExpedientName), Throws.InstanceOf<FormatException>());
    }

}
