
using RI.Novus.Core.ImmovableProperties;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Triplex.Validations;

namespace Persistence.Models
{
    /// <summary>
    /// Represents the database representation for an asegurado.
    /// </summary>
    public sealed class ImmovableOwnerDb
    {
        /// <summary>
        /// Creates an instance of <see cref="Expedient"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="identificationNumber"></param>
        /// <param name="codia"></param>
        /// <param name="creationDate"></param>
        /// <param name="id"></param>
        public ImmovableOwnerDb(string name, string identificationNumber, int codia, DateTimeOffset creationDate, Guid id)
        {
            Name = name;
            IdentificationNumber = identificationNumber;
            Codia = codia;
            CreationDate = creationDate;
            Id = id;
        }
        /// <summary>
        /// Indicates asegurado name
        /// </summary>
        public int Codia { get; set; }

        /// <summary>
        /// Indicates asegurado age
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicates asegurado birthdate
        /// </summary>
        public DateTimeOffset CreationDate { get; set; }

        /// <summary>
        /// Indicates asegurados identification number
        /// </summary>
        public string IdentificationNumber { get; set; } = string.Empty;

        /// <summary>
        /// Indicates asegurados id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Indicates asegurados id
        /// </summary>
        [NotMapped]
        public List<ImmovablePropertyDb> PropertiesList { get; set; }


        /// <summary>
        ///  Converts current model to Asegurado entity.
        /// </summary>
        /// <returns></returns>
        public RI.Novus.Core.ImmovableOwner.ImmovableOwnerClass ToEntity()
        {
            

            return new RI.Novus.Core.ImmovableOwner.ImmovableOwnerClass.Builder()
                         .WithName(RI.Novus.Core.ImmovableOwner.Name.From(Name))
                         .WithCodia(RI.Novus.Core.ImmovableOwner.Codia.From(Codia))
                         .WithId(RI.Novus.Core.ImmovableOwner.Id.From(Id))
                         .WithCreationDate(RI.Novus.Core.ImmovableOwner.CreationDate.From(CreationDate))
                         .WithIdentificationNumber(RI.Novus.Core.ImmovableOwner.IdentificationNumber.From(IdentificationNumber))
                         .WithProperties(PropertiesList.Select(p => p.ToEntity()).ToList())
                         .Build();

        }

        public static ImmovableOwnerDb FromEntity(RI.Novus.Core.ImmovableOwner.ImmovableOwnerClass immovableOwner)
        {
            Arguments.NotNull(immovableOwner, nameof(immovableOwner));

            return new ImmovableOwnerDb(immovableOwner.Name.Value, immovableOwner.IdentificationNumber.Value, immovableOwner.Codia.AsPrimitive, immovableOwner.CreationDate.AsPrimitive, immovableOwner.Id.Value);
        }
    }
}
