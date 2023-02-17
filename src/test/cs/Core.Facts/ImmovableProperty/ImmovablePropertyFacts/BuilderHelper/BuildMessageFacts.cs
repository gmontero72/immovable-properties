
using RI.Novus.Core.ImmovableProperties;
using static RI.Novus.Core.Facts.ImmovableProperty.ImmovablePropertyFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.ImmovableProperty.ImmovablePropertyFacts.BuilderFacts;

[TestFixture]
internal sealed class BuildMessageFacts
{
    [Test]
    public void With_Missing_Required_Property_Throws_InvalidOperationException([Values] BuilderProperty missingProperty)
    {
        Assume.That(missingProperty, Is.Not.EqualTo(BuilderProperty.None));

        ImmovablePropertyClass.Builder builder = CreateBuilderWithout(missingProperty);

        Assert.That(() => builder.Build(), Throws.InvalidOperationException);
    }

    [Test]
    public void With_All_Required_Throws_Nothing([Values(BuilderProperty.None)] BuilderProperty missingProperty)
    {
        ImmovablePropertyClass.Builder builder = CreateBuilderWithout(missingProperty);

        Assert.That(() => builder.Build(), Throws.Nothing);
    }
}
