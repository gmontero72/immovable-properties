using RI.Novus.Core.ImmovableOwner;
using RI.Novus.Core.ImmovableProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.Novus.Core.Boundaries.Persistence
{

    /// <summary>
    /// Provides the contract to provide methods to interact with Immovables.
    /// </summary>
    public interface IImmovableRepositoryDummy
    {
        /// <summary>
        /// Deletes a property from a owner.
        /// </summary>
        /// <param name="propertyClassId"></param>
        void Delete(Guid propertyClassId);

        /// <summary>
        /// Create a owner with its property.
        /// </summary>
        /// <param name="immovableOwnerClass"></param>
        void Persist(ImmovableOwnerClass immovableOwnerClass);

        /// <summary>
        /// Gets all Owners with its properties.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ImmovableOwnerClass> Retrieve();

        /// <summary>
        /// Gets a specific owner with its properties
        /// </summary>
        /// <param name="ownerClassId"></param>
        /// <returns></returns>
        ImmovableOwnerClass RetrieveById(Guid ownerClassId);

        /// <summary>
        /// Updates a owner's property.
        /// </summary>
        /// <param name="immovablePropertyClass"></param>
        /// <param name="immovableOwnerToUpdate"></param>
        /// <param name="propertyClassId"></param>
        void Update(ImmovablePropertyClass immovablePropertyClass, ImmovableOwnerClass immovableOwnerToUpdate, Guid propertyClassId);
    }
}
