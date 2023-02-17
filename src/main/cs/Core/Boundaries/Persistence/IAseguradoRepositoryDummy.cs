using RI.Novus.Core.Asegurados;
using System.Collections.Generic;

namespace RI.Novus.Core.Boundaries.Persistence
{
    /// <summary>
    /// Provides the contract to provide methods to interact with asegurados.
    /// </summary>
    public interface IAseguradoRepositoryDummy
    {

        /// <summary>
        /// Gets all Asegurados
        /// </summary>
        /// <returns></returns>
        ICollection<Asegurado> GetAsegurados();

        /// <summary>
        /// Get Asegurado by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Asegurado GetAseguradoById(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="asegurado"></param>
        void Save(Asegurado asegurado);
    }
}
