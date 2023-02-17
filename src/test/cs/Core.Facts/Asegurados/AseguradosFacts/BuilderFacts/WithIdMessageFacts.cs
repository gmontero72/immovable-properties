using static RI.Novus.Core.Facts.Asegurados.AseguradosFacts.CreateBuilderHelper;

using RI.Novus.Core.Asegurados;

namespace RI.Novus.Core.Facts.Asegurados.AseguradosFacts.BuilderFacts;

internal sealed class WithIdMessageFacts :
    AbstractBuilderRequiredPropertySetterTestFixture<Asegurado.Builder, Asegurado, Id>
{
    protected override Context BuildContext()
    {
        return new Context(empty: new Asegurado.Builder(),
            missingTestedProperty: CreateBuilderWithoutId(),
            used: CreateUsedBuilder(),
            toSetTwice: CreateBuilderWithoutId(),
            firstValue: Id.From(Guid.NewGuid()),
            secondValue: Id.From(Guid.Parse("9a4b3c6d-f3f1-4a85-832d-8b4ad3893bef")));
    }

    protected override void SetProperty(Asegurado.Builder builder, Id value)
        => builder.WithId(value);

    protected override Id GetProperty(Asegurado buildable) => buildable.Id;
}
