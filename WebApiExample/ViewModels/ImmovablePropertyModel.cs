using RI.Novus.Core.ImmovableProperties;
using Triplex.Validations;
using Wepsys.Core;

namespace WebApiExample.ViewModels
{
    public sealed class ImmovablePropertyModel
    {
        /// <summary>
        /// Indicates ImmovablePropertyModel's id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Indicates ImmovablePropertyModel's Area.
        /// </summary>
        public decimal Area { get; set; }

        /// <summary>
        /// Indicates ImmovablePropertyModel's Region.
        /// </summary>
        public decimal Region { get; set; }

        /// <summary>
        /// Indicates ImmovablePropertyModel's Surface.
        /// </summary>
        public decimal Surface { get; set; }

        /// <summary>
        /// Indicates ImmovablePropertyModel's ImmovableOwnerClassId.
        /// </summary>
        public Guid ImmovableOwnerClassId { get; set; }

        /// <summary>
        /// Indicates ImmovablePropertyModel's ImmovablePropertyTypes.
        /// </summary>
        public ImmovablePropertyTypes ImmovablePropertyTypes { get; set; }

        /// <summary>
        /// Converts to Asegurado entity.
        /// </summary>
        public ImmovablePropertyClass ToEntity()
        {
            return new ImmovablePropertyClass.Builder()
                         .WithArea(RI.Novus.Core.ImmovableProperties.Area.From(Area))
                         .WithRegion(RI.Novus.Core.ImmovableProperties.Region.From(Region))
                         .WithSurface(RI.Novus.Core.ImmovableProperties.Surface.From(Surface))
                         .WithId(RI.Novus.Core.ImmovableProperties.Id.From(Id))
                         .WithImmovableOwnerClassId(ImmovableOwnerClassId)
                         .WithImmovablePropertyTypes(ImmovablePropertyTypes)
                         .Build();
        }

        public static ImmovableOwnerModel FromEntity(RI.Novus.Core.ImmovableOwner.ImmovableOwnerClass immovableOwnerClass)
        {
            Arguments.NotNull(immovableOwnerClass, nameof(immovableOwnerClass));

            return new ImmovableOwnerModel()
            {
                Id = immovableOwnerClass.Id.Value,
                Name = immovableOwnerClass.Name.Value,
                IdentificationNumber = immovableOwnerClass.IdentificationNumber.Value,
                CreationDate = immovableOwnerClass.CreationDate.AsPrimitive,
                Codia = immovableOwnerClass.Codia.AsPrimitive,

            };
        }

    }
}
