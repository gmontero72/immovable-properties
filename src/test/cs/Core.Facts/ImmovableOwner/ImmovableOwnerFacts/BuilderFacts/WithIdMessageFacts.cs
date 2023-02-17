using RI.Novus.Core.ImmovableOwner;
using static RI.Novus.Core.Facts.ImmovableOwner.ImmovableOwnerFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.ImmovableOwner.ImmovableOwnerFacts.BuilderFacts;

internal sealed class WithIdMessageFacts :
    AbstractBuilderRequiredPropertySetterTestFixture<ImmovableOwnerClass.Builder, ImmovableOwnerClass, Id>
{
    protected override Context BuildContext()
    {
        return new Context(empty: new ImmovableOwnerClass.Builder(),
            missingTestedProperty: CreateBuilderWithoutId(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutId(),
            firstValue: Id.From(Guid.NewGuid()),
            secondValue: Id.From(Guid.Parse("9a4b3c6d-f3f1-4a85-832d-8b4ad3893bef")));
    }

    protected override void SetProperty(ImmovableOwnerClass.Builder builder, Id value)
        => builder.WithId(value);

    protected override Id GetProperty(ImmovableOwnerClass buildable) => buildable.Id;
}
