using RI.Novus.Core.Asegurados;

namespace RI.Novus.Core.Facts.Asegurados.AseguradosFacts.AgeFacts;

[TestFixture]
internal sealed class FromMessage
{

    [TestCase(1)]
    [TestCase(1_024)]
    [TestCase(int.MaxValue)]
    public void With_Positive_Values_Throws_Nothing(int versionAsInt)
        => Assert.That(() => Age.From(versionAsInt), Throws.Nothing);
}
