using static RI.Novus.Core.Facts.Asegurados.AseguradosFacts.CreateBuilderHelper;
using RI.Novus.Core.Asegurados;

namespace RI.Novus.Core.Facts.Asegurados.AseguradosFacts.BuilderFacts;

internal sealed class WithBirthdateMessageFacts :
    AbstractBuilderRequiredPropertySetterTestFixture<Asegurado.Builder, Asegurado, Birthdate>
{
    protected override Context BuildContext()
    {
        return new Context(empty: new Asegurado.Builder(),
            missingTestedProperty: CreateBuilderWithoutBirthdate(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutBirthdate(),
            firstValue: Birthdate.From(DateTimeOffset.UtcNow.AddHours(-1)),
            secondValue: Birthdate.From(DateTimeOffset.UtcNow.AddHours(-2)));
    }

    protected override void SetProperty(Asegurado.Builder builder, Birthdate value)
        => builder.WithBirthdate(value);

    protected override Birthdate GetProperty(Asegurado buildable) => buildable.Birthdate;
}
