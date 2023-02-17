using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Persistence.Models;
using RI.Novus.Core.Boundaries.Persistence;
using RI.Novus.Core.ImmovableOwner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triplex.Validations;
using RI.Novus.Core.ImmovableProperties;

namespace Persistence
{

    /// <summary>
    /// Represents the dummy in memory implementation for ImmovableRepositoryDummy
    /// </summary>
    public sealed class ImmovableRepositoryDummy : IImmovableRepositoryDummy
    {

        private readonly WepsysContext _wepsysContext;


        public ImmovableRepositoryDummy(WepsysContext wepsysContext) 
        {
            _wepsysContext = wepsysContext;

        }

        /// <inheritdoc />
        public void Delete(Guid propertyClassId)
        {
            
            var propertyToDelete = _wepsysContext.Properties.Find(propertyClassId); 
            if (propertyToDelete != null) _wepsysContext.Properties.Remove(propertyToDelete); 
            _wepsysContext.SaveChanges();
        }

        /// <inheritdoc />
        public void Persist(ImmovableOwnerClass immovableOwnerClass)
        {

            var ownerDb = ImmovableOwnerDb.FromEntity(immovableOwnerClass);
            _wepsysContext.Owners.Add(ownerDb);
            _wepsysContext.SaveChanges();

            _wepsysContext.Properties.AddRange(immovableOwnerClass.PropertiesList.Select(ImmovablePropertyDb.FromEntity));
            _wepsysContext.SaveChanges();
        }

        /// <inheritdoc />
        public IEnumerable<ImmovableOwnerClass> Retrieve()
        {
            var owners = new List<ImmovableOwnerClass>(); 
            var ownersDatabaseModel = _wepsysContext.Owners.Include(x => x.PropertiesList).ToList(); 
            foreach (var i in ownersDatabaseModel) 
            { 
                owners.Add(i.ToEntity()); 
            }
            return owners;
        }

        /// <inheritdoc />
        public ImmovableOwnerClass RetrieveById(Guid ownerClassId)
        {

            ImmovableOwnerDb immovableOwner = _wepsysContext.Owners.AsNoTracking().Include(x => x.PropertiesList).FirstOrDefault(x => x.Id == ownerClassId) ?? throw new ArgumentException("Not ImmovableOwner found!");
            

            return immovableOwner.ToEntity();
            
        }

        /// <inheritdoc />
        public void Update(ImmovablePropertyClass immovablePropertyClass, ImmovableOwnerClass immovableOwnerToUpdate, Guid propertyClassId)
        {
            ImmovableOwnerDb propertyOwnerClass = ImmovableOwnerDb.FromEntity(immovableOwnerToUpdate);
            ImmovablePropertyDb propertyUpdate =
                _wepsysContext.Properties.FirstOrDefault(x => x.Id == propertyClassId && x.ImmovableOwnerClassId == propertyOwnerClass.Id);
            if (propertyUpdate != null)
            {
                ImmovablePropertyDb ownerProperty = ImmovablePropertyDb.FromEntity(immovablePropertyClass);
                propertyUpdate.Surface = ownerProperty.Surface;
                propertyUpdate.ImmovablePropertyTypes = ownerProperty.ImmovablePropertyTypes;
                propertyUpdate.Area = ownerProperty.Area;
                propertyUpdate.Region = ownerProperty.Region;
                _wepsysContext.SaveChanges();
            }
        }
    }
}
