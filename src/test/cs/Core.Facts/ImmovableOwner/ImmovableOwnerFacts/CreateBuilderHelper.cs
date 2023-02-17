using RI.Novus.Core.Asegurados;
using RI.Novus.Core.ImmovableOwner;
using Id = RI.Novus.Core.ImmovableOwner.Id;


namespace RI.Novus.Core.Facts.ImmovableOwner.ImmovableOwnerFacts;
internal static class CreateBuilderHelper
{
    internal enum BuilderProperty
    {
        None,
        Id,
        Name,
        IdentificationName,
        Codia,
        CreationDate
    }
    internal static ImmovableOwnerClass.Builder CreateUsedBuilder()
    {
        ImmovableOwnerClass.Builder builder = CreateFullBuilder();

        _ = builder.Build();

        return builder;
    }

    internal static ImmovableOwnerClass.Builder CreateFullBuilder() => CreateBuilderWithout(BuilderProperty.None);
    internal static ImmovableOwnerClass.Builder CreateBuilderWithoutId() => CreateBuilderWithout(BuilderProperty.Id);
    internal static ImmovableOwnerClass.Builder CreateBuilderWithoutName() => CreateBuilderWithout(BuilderProperty.Name);
    internal static ImmovableOwnerClass.Builder CreateBuilderWithoutIdentificationNumber() => CreateBuilderWithout(BuilderProperty.IdentificationName);
    internal static ImmovableOwnerClass.Builder CreateBuilderWithoutAge() => CreateBuilderWithout(BuilderProperty.Codia);
    internal static ImmovableOwnerClass.Builder CreateBuilderWithoutBirthdate() => CreateBuilderWithout(BuilderProperty.CreationDate);
    internal static ImmovableOwnerClass BuildRoleWithCustomName(string name)
    {
        return CreateBuilderWithoutName()
            .WithName(Core.ImmovableOwner.Name.From(name))
            .Build();
    }


    internal static ImmovableOwnerClass.Builder CreateBuilderWithout(BuilderProperty propertyToSkip)
    {
        IDictionary<BuilderProperty, Action<ImmovableOwnerClass.Builder>> setters = new Dictionary<BuilderProperty, Action<ImmovableOwnerClass.Builder>>
        {
            [BuilderProperty.Id] = b => b.WithId(Id.Generate()),
            [BuilderProperty.Name] = b => b.WithName(Core.ImmovableOwner.Name.From("Administrator")),
            [BuilderProperty.IdentificationName] = b => b.WithIdentificationNumber(Core.ImmovableOwner.IdentificationNumber.From("1234567890123456")),
            [BuilderProperty.Codia] = b => b.WithCodia(Codia.From(24)),
            [BuilderProperty.CreationDate] = b => b.WithCreationDate(CreationDate.From(DateTimeOffset.UtcNow))
        };

        var builder = new ImmovableOwnerClass.Builder();
        foreach (BuilderProperty key in setters.Keys.Where(k => k != propertyToSkip))
        {
            setters[key](builder);
        }

        return builder;

    }
}
