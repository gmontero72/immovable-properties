using RI.Novus.Core.ImmovableProperties;
using Id = RI.Novus.Core.ImmovableProperties.Id;


namespace RI.Novus.Core.Facts.ImmovableProperty.ImmovablePropertyFacts;
internal static class CreateBuilderHelper
{
    internal enum BuilderProperty
    {
        None,
        Id,
        Area,
        Surface,
        Region
    }
    internal static ImmovablePropertyClass.Builder CreateUsedBuilder()
    {
        ImmovablePropertyClass.Builder builder = CreateFullBuilder();

        _ = builder.Build();

        return builder;
    }

    internal static ImmovablePropertyClass.Builder CreateFullBuilder() => CreateBuilderWithout(BuilderProperty.None);
    internal static ImmovablePropertyClass.Builder CreateBuilderWithoutArea() => CreateBuilderWithout(BuilderProperty.Id);
    internal static ImmovablePropertyClass.Builder CreateBuilderWithoutRegion() => CreateBuilderWithout(BuilderProperty.Area);
    internal static ImmovablePropertyClass.Builder CreateBuilderWithoutSurface() => CreateBuilderWithout(BuilderProperty.Surface);
    internal static ImmovablePropertyClass.Builder CreateBuilderWithoutId() => CreateBuilderWithout(BuilderProperty.Region);
    
    internal static ImmovablePropertyClass BuildRoleWithId(Guid id)
    {
        return CreateBuilderWithoutArea()
            .WithId(Id.From(id))
            .Build();
    }


    internal static ImmovablePropertyClass.Builder CreateBuilderWithout(BuilderProperty propertyToSkip)
    {
        IDictionary<BuilderProperty, Action<ImmovablePropertyClass.Builder>> setters = new Dictionary<BuilderProperty, Action<ImmovablePropertyClass.Builder>>
        {
            [BuilderProperty.Id] = b => b.WithId(Id.Generate()),
            [BuilderProperty.Area] = b => b.WithArea(Area.From(99.99M)),
            [BuilderProperty.Region] = b => b.WithRegion(Region.From(99.99M)),
            [BuilderProperty.Surface] = b => b.WithSurface(Surface.From(99.99M))
        };

        var builder = new ImmovablePropertyClass.Builder();
        foreach (BuilderProperty key in setters.Keys.Where(k => k != propertyToSkip))
        {
            setters[key](builder);
        }

        return builder;

    }
}
