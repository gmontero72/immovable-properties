using static RI.Novus.Core.Facts.Asegurados.AseguradosFacts.CreateBuilderHelper;
using RI.Novus.Core.Asegurados;

namespace RI.Novus.Core.Facts.Asegurados.AseguradosFacts.BuilderFacts;

internal sealed class WithidentificationNumberMessageFacts :
    AbstractBuilderRequiredPropertySetterTestFixture<Asegurado.Builder, Asegurado, IdentificationNumber>
{
    protected override Context BuildContext()
    {
        return new Context(empty: new Asegurado.Builder(),
            missingTestedProperty: CreateBuilderWithoutidentificationNumber(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutidentificationNumber(),
            firstValue: IdentificationNumber.From("1234567890123456"),
            secondValue: IdentificationNumber.From("1234567890123457"));
    }

    protected override void SetProperty(Asegurado.Builder builder, IdentificationNumber value)
        => builder.WithidentificationNumber(value);

    protected override IdentificationNumber GetProperty(Asegurado buildable) => buildable.IdentificationNumber;
}
