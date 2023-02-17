using RI.Novus.Core.ImmovableOwner;

namespace RI.Novus.Core.Facts.ImmovableOwner.ImmovableOwnerFacts.CodiaFacts;

[TestFixture]
internal sealed class FromMessage
{

    [TestCase(1)]
    [TestCase(1_024)]
    [TestCase(int.MaxValue)]
    public void With_Positive_Values_Throws_Nothing(int versionAsInt)
        => Assert.That(() => Codia.From(versionAsInt), Throws.Nothing);
}
