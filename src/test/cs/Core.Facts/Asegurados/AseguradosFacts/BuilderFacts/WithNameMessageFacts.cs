using RI.Novus.Core.ImmovableOwner;
using static RI.Novus.Core.Facts.ImmovableOwner.ImmovableOwnerFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.ImmovableOwner.ImmovableOwnerFacts.BuilderFacts;

internal sealed class WithNameMessageFacts :
    AbstractBuilderRequiredPropertySetterTestFixture<ImmovableOwnerClass.Builder, ImmovableOwnerClass, Name>
{
    protected override Context BuildContext()
    {
        return new Context(empty: new ImmovableOwnerClass.Builder(),
            missingTestedProperty: CreateBuilderWithoutName(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutName(),
            firstValue: Name.From("Expedient1"),
            secondValue: Name.From("Expedient2"));
    }

    protected override void SetProperty(ImmovableOwnerClass.Builder builder, Name value)
        => builder.WithName(value);

    protected override Name GetProperty(ImmovableOwnerClass buildable) => buildable.Name;
}
