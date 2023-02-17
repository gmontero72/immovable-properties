
using RI.Novus.Core.ImmovableOwner;
using static RI.Novus.Core.Facts.ImmovableOwner.ImmovableOwnerFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.ImmovableOwner.ImmovableOwnerFacts.BuilderFacts;

internal sealed class WithIdentificationNumberMessageFacts :
    AbstractBuilderRequiredPropertySetterTestFixture<ImmovableOwnerClass.Builder, ImmovableOwnerClass, IdentificationNumber>
{
    protected override Context BuildContext()
    {
        return new Context(empty: new ImmovableOwnerClass.Builder(),
            missingTestedProperty: CreateBuilderWithoutIdentificationNumber(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutIdentificationNumber(),
            firstValue: IdentificationNumber.From("1234567890123456"),
            secondValue: IdentificationNumber.From("1234567890123457"));
    }

    protected override void SetProperty(ImmovableOwnerClass.Builder builder, IdentificationNumber value)
        => builder.WithIdentificationNumber(value);

    protected override IdentificationNumber GetProperty(ImmovableOwnerClass buildable) => buildable.IdentificationNumber;
}
