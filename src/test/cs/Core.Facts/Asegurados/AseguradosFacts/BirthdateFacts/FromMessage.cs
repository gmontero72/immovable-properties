

using RI.Novus.Core.Asegurados;

namespace RI.Novus.Core.Facts.Asegurados.AseguradosFacts.BirthdateFacts;
[TestFixture]
internal sealed class FromMessage
{
    [Test]
    public void With_Past_Date_Throws_Nothing()
        => Assert.That(() => Birthdate.From(DateTimeOffset.UtcNow.AddDays(-1)), Throws.Nothing);
}
