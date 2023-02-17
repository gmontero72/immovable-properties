using RI.Novus.Core.ImmovableProperties;
using static RI.Novus.Core.Facts.ImmovableProperty.ImmovablePropertyFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.ImmovableProperty.ImmovablePropertyFacts.BuilderFacts;

internal sealed class WithIdMessageFacts :
    AbstractBuilderRequiredPropertySetterTestFixture<ImmovablePropertyClass.Builder, ImmovablePropertyClass, Id>
{
    protected override Context BuildContext()
    {
        return new Context(empty: new ImmovablePropertyClass.Builder(),
            missingTestedProperty: CreateBuilderWithoutId(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutId(),
            firstValue: Id.From(Guid.NewGuid()),
            secondValue: Id.From(Guid.Parse("9a4b3c6d-f3f1-4a85-832d-8b4ad3893bef")));
    }

    protected override void SetProperty(ImmovablePropertyClass.Builder builder, Id value)
        => builder.WithId(value);

    protected override Id GetProperty(ImmovablePropertyClass buildable) => buildable.Id;
}
