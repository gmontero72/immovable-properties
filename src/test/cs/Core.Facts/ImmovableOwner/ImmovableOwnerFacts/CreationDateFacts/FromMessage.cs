using RI.Novus.Core.ImmovableOwner;

namespace RI.Novus.Core.Facts.ImmovableOwner.ImmovableOwnerFacts.CreationDateFacts;
[TestFixture]
internal sealed class FromMessage
{
    [Test]
    public void With_Past_Date_Throws_Nothing()
        => Assert.That(() => CreationDate.From(DateTimeOffset.UtcNow.AddDays(-1)), Throws.Nothing);
}
