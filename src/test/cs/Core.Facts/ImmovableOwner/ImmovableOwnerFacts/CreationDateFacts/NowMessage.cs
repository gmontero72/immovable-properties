using RI.Novus.Core.ImmovableOwner;

namespace RI.Novus.Core.Facts.ImmovableOwner.ImmovableOwnerFacts.CreationDateFacts;

[TestFixture]
internal sealed class NowMessage
{
    [Test]
    public void Returns_Close_To_Now()
        => Assert.That(CreationDate.Now().AsPrimitive, Is.EqualTo(DateTimeOffset.UtcNow).Within(TimeSpan.FromSeconds(5)));
}
