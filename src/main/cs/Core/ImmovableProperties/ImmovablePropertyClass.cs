
using RI.Novus.Core.Boundaries.Persistence;
using RI.Novus.Core.ImmovableOwner;
using RI.Novus.Core.ImmovableProperties;

namespace RI.Novus.Core.ImmovableProperties
{

    /// <summary>
    /// ImmovableProperty (initial dummy class).
    /// </summary>
    public sealed class ImmovablePropertyClass
    {


        private ImmovablePropertyClass(Builder builder)
        {
            
            Id = builder.IdOption.ValueOr(Id.Generate());
            Area = builder.AreaOption;
            ImmovableOwnerClassId = builder.ImmovableOwnerClassIdOption.ValueOrFailure();
            ImmovablePropertyTypes = builder.ImmovablePropertyTypesOption.ValueOrFailure();
            Region = builder.RegionOption;
            Surface = builder.SurfaceOption.ValueOrFailure();
        }

        /// <summary>
        /// ImmovableProperty's Id
        /// </summary>
        public Id Id { get; }

        /// <summary>
        /// ImmovableProperty's Area
        /// </summary>
        public Option<Area> Area { get; }

        /// <summary>
        /// ImmovableProperty's ImmovableOwnerClassId
        /// </summary>
        public Guid ImmovableOwnerClassId { get; }

        /// <summary>
        /// ImmovableProperty's ImmovablePropertyTypes
        /// </summary>
        public ImmovablePropertyTypes ImmovablePropertyTypes { get; }

        /// <summary>
        /// ImmovableProperty's Region
        /// </summary>
        public Option<Region> Region { get; }

        /// <summary>
        /// ImmovableProperty's Surface
        /// </summary>
        public Surface Surface { get; }

        /// <summary>
        /// Update a owner's property
        /// </summary>
        /// <param name="immovableRepositoryDummy"></param>
        /// <param name="immovableOwnerToUpdate"></param>
        /// <param name="propertyClassId"></param>
        public void Update(IImmovableRepositoryDummy immovableRepositoryDummy, ImmovableOwnerClass immovableOwnerToUpdate, Guid propertyClassId)
        {
            Arguments.NotNull(immovableRepositoryDummy, nameof(immovableRepositoryDummy));
            immovableRepositoryDummy.Update(this, immovableOwnerToUpdate, propertyClassId);
        }


        /// <summary>
        /// ImmovableProperty's builder.
        /// </summary>
        public sealed class Builder : AbstractEntityBuilder<ImmovablePropertyClass>
        {
            /// <inheritdoc />
            protected override Option<string> AlreadyBuiltErrorMessage => Option.None<string>();

            /// <inheritdoc />
            protected override Option<string> MustBeBuiltErrorMessage => Option.None<string>();

            internal Option<Id> IdOption { private set; get; }

            internal Option<Area> AreaOption { private set; get; }

            internal Option<Guid> ImmovableOwnerClassIdOption { private set; get; }

            internal Option<ImmovablePropertyTypes> ImmovablePropertyTypesOption { private set; get; }

            internal Option<Region> RegionOption { private set; get; }

            internal Option<Surface> SurfaceOption { private set; get; }

            /// <inheritdoc />
            protected override ImmovablePropertyClass DoBuild()
            {
                State.IsTrue(AreaOption.HasValue, "Area.Missing");
                State.IsTrue(ImmovableOwnerClassIdOption.HasValue, "ImmovableOwnerClassId.Missing");
                State.IsTrue(ImmovablePropertyTypesOption.HasValue, "ImmovablePropertyTypes.Missing");
                State.IsTrue(RegionOption.HasValue, "Region.Missing");
                State.IsTrue(SurfaceOption.HasValue, "Surface.Missing");

                return new ImmovablePropertyClass(this);
            }


            /// <summary>
            /// Sets Id.
            /// </summary>
            /// <param name="id"></param>
            /// <returns>self</returns>
            public Builder WithId(Id id) => 
                   SetProperty(() => IdOption = Arguments.NotNull(id, nameof(id)).SomeNotNull());

            /// <summary>
            /// Sets Area.
            /// </summary>
            /// <param name="area"></param>
            /// <returns>self</returns>
            public Builder WithArea(Area area) =>
                   SetProperty(() => AreaOption = area.Some());

            /// <summary>
            /// Sets Area.
            /// </summary>
            /// <param name="ImmovableOwnerClassId"></param>
            /// <returns>self</returns>
            public Builder WithImmovableOwnerClassId(Guid ImmovableOwnerClassId) => 
                   SetProperty(() => ImmovableOwnerClassIdOption = ImmovableOwnerClassId.Some());


            /// <summary>
            /// Sets Area.
            /// </summary>
            /// <param name="immovablePropertyTypes"></param>
            /// <returns>self</returns>
            public Builder WithImmovablePropertyTypes(ImmovablePropertyTypes immovablePropertyTypes) =>
                   SetProperty(() =>
                   {
                       Arguments.ValidEnumerationMember(immovablePropertyTypes, nameof(immovablePropertyTypes));
                       ImmovablePropertyTypesOption = immovablePropertyTypes.Some();

                   });

            /// <summary>
            /// Sets Area.
            /// </summary>
            /// <param name="region"></param>
            /// <returns>self</returns>
            public Builder WithRegion(Region region) =>
                   SetProperty(() => RegionOption = region.Some());


            /// <summary>
            /// Sets Area.
            /// </summary>
            /// <param name="surface"></param>
            /// <returns>self</returns>
            public Builder WithSurface(Surface surface) =>
                   SetProperty(() => SurfaceOption = Arguments.NotNull(surface, nameof(surface)).SomeNotNull());


            private new Builder SetProperty(Action setter) => (Builder)base.SetProperty(setter);


        }
    }
}
