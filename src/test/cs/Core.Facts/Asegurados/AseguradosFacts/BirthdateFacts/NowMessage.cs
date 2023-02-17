using RI.Novus.Core.Asegurados;

namespace RI.Novus.Core.Facts.Asegurados.AseguradosFacts.BirthdateFacts;

[TestFixture]
internal sealed class NowMessage
{
    [Test]
    public void Returns_Close_To_Now()
        => Assert.That(Birthdate.Now().AsPrimitive, Is.EqualTo(DateTimeOffset.UtcNow).Within(TimeSpan.FromSeconds(5)));
}
