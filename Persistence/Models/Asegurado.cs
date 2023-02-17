using Triplex.Validations;

namespace Persistence.Models
{

    /// <summary>
    /// Represents the database representation for an asegurado.
    /// </summary>
    public sealed class Asegurado
    {
        /// <summary>
        /// Creates an instance of <see cref="Expedient"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="identificationNumber"></param>
        /// <param name="age"></param>
        /// <param name="birthDate"></param>
        /// <param name="id"></param>
        public Asegurado(string name, string identificationNumber, int age, DateTimeOffset birthDate, Guid id)
        {
            this.Name = name;
            this.IdentificationNumber = identificationNumber;
            Age = age;
            Birthdate = birthDate;
            Id = id;
        }
        /// <summary>
        /// Indicates asegurado name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Indicates asegurado age
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Indicates asegurado birthdate
        /// </summary>
        public DateTimeOffset Birthdate { get; set; }

        /// <summary>
        /// Indicates asegurados identification number
        /// </summary>
        public string IdentificationNumber { get; set; } = string.Empty;

        /// <summary>
        /// Indicates asegurados id
        /// </summary>
        public Guid Id { get; set; }


        /// <summary>
        ///  Converts current model to Asegurado entity.
        /// </summary>
        /// <returns></returns>
        public RI.Novus.Core.Asegurados.Asegurado ToEntity()
        {
            return new RI.Novus.Core.Asegurados.Asegurado.Builder()
                         .WithName(RI.Novus.Core.Asegurados.Name.From(Name))
                         .WithAge(RI.Novus.Core.Asegurados.Age.From(Age))
                         .WithBirthdate(RI.Novus.Core.Asegurados.Birthdate.From(Birthdate))
                         .WithId(RI.Novus.Core.Asegurados.Id.From(Id))
                         .WithidentificationNumber(RI.Novus.Core.Asegurados.IdentificationNumber.From(IdentificationNumber))
                         .Build();
        }

        public static Asegurado FromEntity(RI.Novus.Core.Asegurados.Asegurado asegurado)
        {
            Arguments.NotNull(asegurado, nameof(asegurado));

            return new Asegurado(asegurado.Name.Value, asegurado.IdentificationNumber.Value, asegurado.Age.AsPrimitive, asegurado.Birthdate.AsPrimitive, asegurado.Id.Value);
        }
    }
}
