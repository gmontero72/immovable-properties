
using RI.Novus.Core.ImmovableOwner;
using static RI.Novus.Core.Facts.ImmovableOwner.ImmovableOwnerFacts.CreateBuilderHelper;

namespace RI.Novus.Core.Facts.ImmovableOwner.ImmovableOwnerFacts.BuilderFacts;

internal sealed class WithCreationDateMessageFacts :
    AbstractBuilderRequiredPropertySetterTestFixture<ImmovableOwnerClass.Builder, ImmovableOwnerClass, CreationDate>
{
    protected override Context BuildContext()
    {
        return new Context(empty: new ImmovableOwnerClass.Builder(),
            missingTestedProperty: CreateBuilderWithoutBirthdate(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutBirthdate(),
            firstValue: CreationDate.From(DateTimeOffset.UtcNow.AddHours(-1)),
            secondValue: CreationDate.From(DateTimeOffset.UtcNow.AddHours(-2)));
    }

    protected override void SetProperty(ImmovableOwnerClass.Builder builder, CreationDate value)
        => builder.WithCreationDate(value);

    protected override CreationDate GetProperty(ImmovableOwnerClass buildable) => buildable.CreationDate;
}
