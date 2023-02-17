using Triplex.Validations;

namespace WebApiExample.ViewModels
{
    /// <summary>
    /// Represents an asegurado model.
    /// </summary>
    public sealed class AseguradoModel
    {
        /// <summary>
        /// Indicates asegurado's name.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Indicates asegurado's author name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Indicates asegurado's author name.
        /// </summary>
        public string IdentificationNumber { get; set; } = string.Empty;

        /// <summary>
        /// Indicates asegurado's author name.
        /// </summary>
        public DateTimeOffset Birthdate { get; set; }

        /// <summary>
        /// Indicates asegurado's author name.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Converts to Asegurado entity.
        /// </summary>
        /// <returns>An instance of <see cref="RI.Novus.Core.CadastralSurvey.Expedients.Expedient"/></returns>
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

        public static AseguradoModel FromEntity(RI.Novus.Core.Asegurados.Asegurado asegurado)
        {
            Arguments.NotNull(asegurado, nameof(asegurado));

            return new AseguradoModel()
            {
                Id = asegurado.Id.Value,
                Name = asegurado.Name.Value,
                IdentificationNumber = asegurado.IdentificationNumber.Value,
                Birthdate = asegurado.Birthdate.AsPrimitive,
                Age = asegurado.Age.AsPrimitive,
                
            };
        }
    }
}
