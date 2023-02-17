
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Optional.Unsafe;
using RI.Novus.Core.ImmovableOwner;
using RI.Novus.Core.ImmovableProperties;
using Triplex.Validations;

namespace WebApiExample.ViewModels
{
    public sealed class ImmovableOwnerModel
    {
        /// <summary>
        /// Indicates ImmovableOwnerModel's Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Indicates ImmovableOwnerModel's Name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Indicates ImmovableOwnerModel's IdentificationNumber.
        /// </summary>
        public string IdentificationNumber { get; set; } = string.Empty;

        /// <summary>
        /// Indicates ImmovableOwnerModel's CreationDate.
        /// </summary>
        public DateTimeOffset CreationDate { get; set; }

        /// <summary>
        /// Indicates ImmovableOwnerModel's Codia.
        /// </summary>
        public int Codia { get; set; }

        /// <summary>
        /// Indicates ImmovableOwnerModel's Codia.
        /// </summary>
        public ICollection<ImmovablePropertyModel> PropertyList { get; set; }

        /// <summary>
        /// Converts to Asegurado entity.
        /// </summary>
        /// <returns>An instance of <see cref="RI.Novus.Core.CadastralSurvey.Expedients.Expedient"/></returns>
        public ImmovableOwnerClass ToEntity()
        {
            var id = Guid.NewGuid();

            var propertyClass = PropertyList.Select(x => new ImmovablePropertyClass.Builder()
            .WithSurface(Surface.From(PropertyList.Select(x => x.Surface).FirstOrDefault()))
            .WithImmovablePropertyTypes(PropertyList.Select(x => x.ImmovablePropertyTypes).FirstOrDefault())
            .WithArea(Area.From(PropertyList.Select(x => x.Area).FirstOrDefault()))
            .WithRegion(Region.From(PropertyList.Select(x => x.Region).FirstOrDefault()))
            .WithImmovableOwnerClassId(id)
            .Build());

            return new ImmovableOwnerClass.Builder()
                         .WithName(RI.Novus.Core.ImmovableOwner.Name.From(Name))
                         .WithCodia(RI.Novus.Core.ImmovableOwner.Codia.From(Codia))
                         .WithCreationDate(RI.Novus.Core.ImmovableOwner.CreationDate.From(DateTimeOffset.Now))
                         .WithId(RI.Novus.Core.ImmovableOwner.Id.From(id))
                         .WithIdentificationNumber(RI.Novus.Core.ImmovableOwner.IdentificationNumber.From(IdentificationNumber))
                         .WithProperties(propertyClass)
                         .Build();
        }

        public static ImmovableOwnerModel FromEntity(ImmovableOwnerClass immovableOwnerClass)
        {
            Arguments.NotNull(immovableOwnerClass, nameof(immovableOwnerClass));

            return new ImmovableOwnerModel()
            {
                Id = immovableOwnerClass.Id.Value,
                Name = immovableOwnerClass.Name.Value,
                IdentificationNumber = immovableOwnerClass.IdentificationNumber.Value,
                CreationDate = immovableOwnerClass.CreationDate.AsPrimitive,
                Codia = immovableOwnerClass.Codia.AsPrimitive,
                PropertyList = immovableOwnerClass.PropertiesList.Select(x => new ImmovablePropertyModel 
                { 
                    Id = x.Id.Value,
                    Area = x.Area.ValueOrDefault().Value,
                    Region = x.Region.ValueOrDefault().Value,
                    Surface = x.Surface.Value, 
                    ImmovableOwnerClassId = x.ImmovableOwnerClassId,
                    ImmovablePropertyTypes = x.ImmovablePropertyTypes,  
                }).ToList()

            };
        }

    }
}
