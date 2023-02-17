using RI.Novus.Core.Boundaries.Persistence;
using RI.Novus.Core.ImmovableProperties;

using System.Collections.Generic;

namespace RI.Novus.Core.ImmovableOwner
{

    /// <summary>
    /// Represents a InmovableOwner's CreationDate.
    /// </summary>
    public sealed class ImmovableOwnerClass
    {
        private ImmovableOwnerClass(Builder builder)
        {
            Arguments.NotNull(builder, nameof(builder));

            Id = builder.IdOption.ValueOr(Id.Generate());
            Name = builder.NameOption.ValueOrFailure();
            IdentificationNumber = builder.IdentificationNumberOption.ValueOrFailure();
            CreationDate = builder.CreationDateOption.ValueOrFailure();
            Codia = builder.CodiaOption.ValueOrFailure();
            PropertiesList = builder.PropertyOption.ValueOrFailure();
        }

        /// <summary>Property's id.</summary>
        public Id Id { get; }

        /// <summary>
        /// Property's name
        /// </summary>
        public Name Name { get; }

        /// <summary>
        /// Property's identification number.
        /// </summary>
        public IdentificationNumber IdentificationNumber { get; }

        /// <summary>
        /// Property's birthdate.
        /// </summary>
        public CreationDate CreationDate { get; }

        /// <summary>
        /// Property's age.
        /// </summary>
        public Codia Codia { get; }

        /// <summary>
        /// Property's PropertiesList.
        /// </summary>
        public IEnumerable<ImmovablePropertyClass> PropertiesList { get; }

        /// <summary>
        /// Deletes a property from owner.
        /// </summary>
        /// <param name="immovableRepositoryDummy"></param>
        /// <param name="propertyClassId"></param>
        public static void Delete(IImmovableRepositoryDummy immovableRepositoryDummy, Guid propertyClassId)
        {
            Arguments.NotNull(immovableRepositoryDummy, nameof(immovableRepositoryDummy));
            immovableRepositoryDummy.Delete(propertyClassId);
        }

        /// <summary>
        /// Create an owner
        /// </summary>
        /// <param name="immovableRepositoryDummy"></param>
        public void Persist(IImmovableRepositoryDummy immovableRepositoryDummy)
        {
            Arguments.NotNull(immovableRepositoryDummy, nameof(immovableRepositoryDummy));
            immovableRepositoryDummy.Persist(this);

        }

        /// <summary>
        /// Property's builder.
        /// </summary>
        public sealed class Builder : AbstractEntityBuilder<ImmovableOwnerClass>
        {
            /// <inheritdoc />
            protected override Option<string> AlreadyBuiltErrorMessage => Option.None<string>();

            /// <inheritdoc />
            protected override Option<string> MustBeBuiltErrorMessage => Option.None<string>();

            internal Option<Id> IdOption { get; private set; }

            internal Option<Name> NameOption { private set; get; }

            internal Option<IdentificationNumber> IdentificationNumberOption { private set; get; }

            internal Option<CreationDate> CreationDateOption { private set; get; }

            internal Option<Codia> CodiaOption { private set; get; }

            internal Option<IEnumerable<ImmovablePropertyClass>> PropertyOption { private set; get; }

            /// <inheritdoc />
            protected override ImmovableOwnerClass DoBuild()
            {
                State.IsTrue(IdOption.HasValue, "Id.Missing");
                State.IsTrue(NameOption.HasValue, "Name.Missing");
                State.IsTrue(IdentificationNumberOption.HasValue, "IdentificationNumber.Missing");
                State.IsTrue(CreationDateOption.HasValue, "CreationDate.Missing");
                State.IsTrue(CodiaOption.HasValue, "Codia.Missing");
                

                return new ImmovableOwnerClass(this);
            }

            /// <summary>Adds a valid ID</summary>
            /// <param name="id">Represents the ID.</param>
            /// <returns></returns>
            public Builder WithId(Id id)
                => SetProperty(() => IdOption = Arguments.NotNull(id, nameof(id)).SomeNotNull());

            /// <summary>
            /// Sets Property's name.
            /// </summary>
            /// <param name="name">Represents the name.</param>
            /// <returns>self</returns>
            public Builder WithName(Name name)
                => SetProperty(() => NameOption
                    = Arguments.NotNull(name, nameof(name)).SomeNotNull());
            /// <summary>
            /// Sets Property's identification number.
            /// </summary>
            /// <param name="identificationNumber">Represents the identification number.</param>
            /// <returns>self</returns>
            public Builder WithIdentificationNumber(IdentificationNumber identificationNumber)
                => SetProperty(() => IdentificationNumberOption
                    = Arguments.NotNull(identificationNumber, nameof(identificationNumber)).SomeNotNull());

            /// <summary>
            /// Sets Property's createdDate.
            /// </summary>
            /// <param name="creationDate"></param>
            /// <returns>self</returns>
            public Builder WithCreationDate(CreationDate creationDate)
                => SetProperty(() => CreationDateOption
                    = Arguments.NotNull(creationDate, nameof(creationDate)).SomeNotNull());

            /// <summary>
            /// Sets Property's codia.
            /// </summary>
            /// <param name="codia">Represents the age.</param>
            /// <returns>self</returns>
            public Builder WithCodia(Codia codia)
                => SetProperty(() => CodiaOption
                    = Arguments.NotNull(codia, nameof(codia)).SomeNotNull());

            /// <summary>
            /// Entities with property
            /// </summary>
            /// <param name="property"></param>
            /// <returns></returns>
            public Builder WithProperties(IEnumerable<ImmovablePropertyClass> property)
                => SetProperty(() => PropertyOption
                    = Arguments.NotNull(property, nameof(property)).SomeNotNull());

            private new Builder SetProperty(Action setter) => (Builder)base.SetProperty(setter);
        }
    }
}
