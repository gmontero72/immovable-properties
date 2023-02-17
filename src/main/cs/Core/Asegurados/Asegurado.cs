

using RI.Novus.Core.Boundaries.Persistence;

namespace RI.Novus.Core.Asegurados
{   /// <summary>
    /// Asegurado (initial dummy class).
    /// </summary>
    public sealed class Asegurado
    {



        private Asegurado(Builder builder)
        {
            Arguments.NotNull(builder, nameof(builder));

            Id = builder.IdOption.ValueOrFailure();
            Name = builder.NameOption.ValueOrFailure();
            Age = builder.AgeOption.ValueOrFailure();
            IdentificationNumber = builder.IdentificationNumberOption.ValueOrFailure();
            Birthdate = builder.BirthdateOption.ValueOrFailure();
        }

        /// <summary>
        /// Asegurado's Id
        /// </summary>
        public Id Id { get; private set; }

        /// <summary>
        /// Asegurado's Age
        /// </summary>
        public Age Age { get; }


        /// <summary>
        /// Asegurado's Name
        /// </summary>
        public Name Name { get; }

        /// <summary>
        /// Asegurado's IdentificationNumber
        /// </summary>
        public IdentificationNumber IdentificationNumber { get; }

        /// <summary>
        /// Asegurado's Birthdate
        /// </summary>
        public Birthdate Birthdate { get; }


        /// <summary>
        /// Persists entity.
        /// </summary>
        /// <param name="aseguradoRepositoryDummy"></param>
        public void Persist(IAseguradoRepositoryDummy aseguradoRepositoryDummy)
        {
            Arguments.NotNull(aseguradoRepositoryDummy, nameof(aseguradoRepositoryDummy));

            aseguradoRepositoryDummy.Save(this);
        }

        /// <summary>
        /// Asegurado's builder.
        /// </summary>
        public sealed class Builder : AbstractEntityBuilder<Asegurado>
        {
            /// <inheritdoc />
            protected override Option<string> AlreadyBuiltErrorMessage => Option.None<string>();

            /// <inheritdoc />
            protected override Option<string> MustBeBuiltErrorMessage => Option.None<string>();

            internal Option<Id> IdOption { private set; get; }

            internal Option<Name> NameOption { private set; get; }

            internal Option<Birthdate> BirthdateOption { private set; get; }

            internal Option<IdentificationNumber> IdentificationNumberOption { private set; get; }

            internal Option<Age> AgeOption { private set; get; }

            /// <inheritdoc />
            protected override Asegurado DoBuild()
            {
                State.IsTrue(IdOption.HasValue, "Id.Missing");
                State.IsTrue(NameOption.HasValue, "Name.Missing");
                State.IsTrue(BirthdateOption.HasValue, "Birthdate.Missing");
                State.IsTrue(IdentificationNumberOption.HasValue, "identificationNumber.Missing");
                State.IsTrue(AgeOption.HasValue, "Age.Missing");

                return new Asegurado(this);
            }

            /// <summary>
            /// Sets Id.
            /// </summary>
            /// <param name="id"></param>
            /// <returns>self</returns>
            public Builder WithId(Id id)
                => SetProperty(() => IdOption
                    = Arguments.NotNull(id, nameof(id)).SomeNotNull());

            /// <summary>
            /// Sets Name.
            /// </summary>
            /// <param name="name"></param>
            /// <returns>self</returns>
            public Builder WithName(Name name)
                => SetProperty(() => NameOption
                    = Arguments.NotNull(name, nameof(name)).SomeNotNull());

            /// <summary>
            /// Sets BirthDate.
            /// </summary>
            /// <param name="birthdate"></param>
            /// <returns>self</returns>
            public Builder WithBirthdate(Birthdate birthdate)
                => SetProperty(() => BirthdateOption
                    = Arguments.NotNull(birthdate, nameof(birthdate)).SomeNotNull());

            /// <summary>
            /// Sets IdentificationNumber.
            /// </summary>
            /// <param name="identificationNumber"></param>
            /// <returns>self</returns>
            public Builder WithidentificationNumber(IdentificationNumber identificationNumber)
                => SetProperty(() => IdentificationNumberOption
                    = Arguments.NotNull(identificationNumber, nameof(identificationNumber)).SomeNotNull());

            /// <summary>
            /// Sets Age.
            /// </summary>
            /// <param name="age"></param>
            /// <returns>self</returns>
            public Builder WithAge(Age age)
                => SetProperty(() => AgeOption
                    = Arguments.NotNull(age, nameof(age)).SomeNotNull());

            private new Builder SetProperty(Action setter) => (Builder)base.SetProperty(setter);
        }



    }
}
