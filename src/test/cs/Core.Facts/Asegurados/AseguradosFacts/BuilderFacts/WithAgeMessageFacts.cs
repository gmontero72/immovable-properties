using static RI.Novus.Core.Facts.Asegurados.AseguradosFacts.CreateBuilderHelper;
using RI.Novus.Core.Asegurados;

namespace RI.Novus.Core.Facts.Asegurados.AseguradosFacts.BuilderFacts;

internal sealed class WithAgeMessageFacts :
    AbstractBuilderRequiredPropertySetterTestFixture<Asegurado.Builder, Asegurado, Age>
{
    protected override Context BuildContext()
    {
        return new Context(empty: new Asegurado.Builder(),
            missingTestedProperty: CreateBuilderWithoutAge(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutAge(),
            firstValue: Age.From(25),
            secondValue: Age.From(26));
    }

    protected override void SetProperty(Asegurado.Builder builder, Age value)
        => builder.WithAge(value);

    protected override Age GetProperty(Asegurado buildable) => buildable.Age;
}
