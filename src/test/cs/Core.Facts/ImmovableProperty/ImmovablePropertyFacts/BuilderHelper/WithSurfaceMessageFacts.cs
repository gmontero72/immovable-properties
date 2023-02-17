
using RI.Novus.Core.ImmovableOwner;
using static RI.Novus.Core.Facts.ImmovableOwner.ImmovableOwnerFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.ImmovableOwner.ImmovableOwnerFacts.BuilderFacts;

internal sealed class WithAgeMessageFacts :
    AbstractBuilderRequiredPropertySetterTestFixture<ImmovableOwnerClass.Builder, ImmovableOwnerClass, Codia>
{
    protected override Context BuildContext()
    {
        return new Context(empty: new ImmovableOwnerClass.Builder(),
            missingTestedProperty: CreateBuilderWithoutAge(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutAge(),
            firstValue: Codia.From(25),
            secondValue: Codia.From(26));
    }

    protected override void SetProperty(ImmovableOwnerClass.Builder builder, Codia value)
        => builder.WithCodia(value);

    protected override Codia GetProperty(ImmovableOwnerClass buildable) => buildable.Codia;
}
