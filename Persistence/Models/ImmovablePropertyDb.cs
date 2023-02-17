using Optional.Unsafe;
using RI.Novus.Core.ImmovableOwner;
using RI.Novus.Core.ImmovableProperties;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Triplex.Validations;

namespace Persistence.Models
{
    public sealed class ImmovablePropertyDb
    {
        /// <summary>
        /// Creates an instance of <see cref="Expedient"/>
        /// </summary>
        /// <param name="area"></param>
        /// <param name="region"></param>
        /// <param name="surface"></param>
        /// <param name="immovableOwnerClassId"></param>
        /// <param name="id"></param>
        /// <param name="immovablePropertyTypes"></param>
        public ImmovablePropertyDb(decimal area, decimal region, decimal surface, Guid immovableOwnerClassId, Guid id, ImmovablePropertyTypes immovablePropertyTypes )
        {
            Area = area;
            Region = region;
            Surface = surface;
            ImmovableOwnerClassId = immovableOwnerClassId;
            Id = id;
            ImmovablePropertyTypes = immovablePropertyTypes;
        }

        /// <summary>
        /// Indicates asegurado name
        /// </summary>
        public decimal Area { get; set; }

        /// <summary>
        /// Indicates asegurado age
        /// </summary>
        public decimal Region { get; set; }

        /// <summary>
        /// Indicates asegurado birthdate
        /// </summary>
        public decimal Surface { get; set; }

        /// <summary>
        /// Indicates asegurados identification number
        /// </summary>

        [Required]
        public Guid ImmovableOwnerClassId { get; set; }
        /// <summary>
        /// Indicates asegurados id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        public ImmovablePropertyTypes ImmovablePropertyTypes { get; set; }

        [ForeignKey( nameof(ImmovableOwnerClassId) )]
        [NotMapped]
        public ImmovableOwnerDb OwnerDb { get; set; }


        /// <summary>
        ///  Converts current model to ImmovablePropertyClass entity.
        /// </summary>
        /// <returns></returns>
        public ImmovablePropertyClass ToEntity()
        {
            return new ImmovablePropertyClass.Builder()
                         .WithArea(RI.Novus.Core.ImmovableProperties.Area.From(Area))
                         .WithSurface(RI.Novus.Core.ImmovableProperties.Surface.From(Surface))
                         .WithId(RI.Novus.Core.ImmovableProperties.Id.From(Id))
                         .WithImmovablePropertyTypes(ImmovablePropertyTypes)
                         .WithRegion(RI.Novus.Core.ImmovableProperties.Region.From(Region))
                         .WithImmovableOwnerClassId(ImmovableOwnerClassId)
                         .Build();

        }

        /// <summary>
        /// Converts current model to ImmovablePropertyDb entity.
        /// </summary>
        /// <param name="immovablePropertyClass"></param>
        /// <returns></returns>
        public static ImmovablePropertyDb FromEntity(ImmovablePropertyClass immovablePropertyClass)
        {
            Arguments.NotNull(immovablePropertyClass, nameof(immovablePropertyClass));

            return new ImmovablePropertyDb(immovablePropertyClass.Area.ValueOrDefault().Value, immovablePropertyClass.Region.ValueOrDefault().Value, immovablePropertyClass.Surface.Value, immovablePropertyClass.ImmovableOwnerClassId, immovablePropertyClass.Id.Value, immovablePropertyClass.ImmovablePropertyTypes);
        }


    }
}

