using RI.Novus.Core.ImmovableProperties;

namespace RI.Novus.Core.Facts.ImmovableProperty.ImmovablePropertyFacts.IdFacts;

[TestFixture]
internal sealed class GenerateMessage
{
    [TestCase(2)]
    [TestCase(4)]
    [TestCase(8)]
    public void All_Are_Distinct(int count)
    {
        ISet<Id> ids = Enumerable.Range(0, count).Select(_ => Id.Generate()).ToHashSet();

        Assert.That(ids, Has.Count.EqualTo(count));
    }
}
