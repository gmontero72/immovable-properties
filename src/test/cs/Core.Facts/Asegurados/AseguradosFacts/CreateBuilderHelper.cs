using RI.Novus.Core.Asegurados;
using Id = RI.Novus.Core.Asegurados.Id;

namespace RI.Novus.Core.Facts.Asegurados.AseguradosFacts;

internal static class CreateBuilderHelper
{
    internal enum BuilderProperty
    {
        None,
        Id,
        Name,
        identificationName,
        Age,
        Birthdate
    }
    internal static Asegurado.Builder CreateUsedBuilder()
    {
        Asegurado.Builder builder = CreateFullBuilder();

        _ = builder.Build();

        return builder;
    }

    internal static Asegurado.Builder CreateFullBuilder() => CreateBuilderWithout(BuilderProperty.None);
    internal static Asegurado.Builder CreateBuilderWithoutId() => CreateBuilderWithout(BuilderProperty.Id);
    internal static Asegurado.Builder CreateBuilderWithoutName() => CreateBuilderWithout(BuilderProperty.Name);
    internal static Asegurado.Builder CreateBuilderWithoutidentificationNumber() => CreateBuilderWithout(BuilderProperty.identificationName);
    internal static Asegurado.Builder CreateBuilderWithoutAge() => CreateBuilderWithout(BuilderProperty.Age);
    internal static Asegurado.Builder CreateBuilderWithoutBirthdate() => CreateBuilderWithout(BuilderProperty.Birthdate);
    internal static Asegurado BuildRoleWithCustomName(string name)
    {
        return CreateBuilderWithoutName()
            .WithName(Name.From(name))
            .Build();
    }


    internal static Asegurado.Builder CreateBuilderWithout(BuilderProperty propertyToSkip)
    {
        IDictionary<BuilderProperty, Action<Asegurado.Builder>> setters = new Dictionary<BuilderProperty, Action<Asegurado.Builder>>
        {
            [BuilderProperty.Id] = b => b.WithId(Id.Generate()),
            [BuilderProperty.Name] = b => b.WithName(Name.From("Administrator")),
            [BuilderProperty.identificationName] = b => b.WithidentificationNumber(IdentificationNumber.From("1234567890123456")),
            [BuilderProperty.Age] = b => b.WithAge(Age.From(24)),
            [BuilderProperty.Birthdate] = b => b.WithBirthdate(Birthdate.From(DateTimeOffset.UtcNow))
        };

        var builder = new Asegurado.Builder();
        foreach (BuilderProperty key in setters.Keys.Where(k => k != propertyToSkip))
        {
            setters[key](builder);
        }

        return builder;

    }
}
