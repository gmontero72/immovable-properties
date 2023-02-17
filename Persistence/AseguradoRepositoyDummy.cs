using RI.Novus.Core.Boundaries.Persistence;
using System.Collections.ObjectModel;
using Triplex.Validations;

namespace Persistence
{

    /// <summary>
    /// Represents the dummy in memory implementation for Asegurados
    /// </summary>
    public sealed class AseguradoRepositoyDummy : IAseguradoRepositoryDummy
    {
        private static ICollection<Models.Asegurado> asegurados = new List<Models.Asegurado> 
        { 
            
            new Models.Asegurado("Pedro", "1234567890123456", 25 , DateTimeOffset.Now, Guid.NewGuid()),
            new Models.Asegurado("Martin", "1234567890123457", 24 , DateTimeOffset.Now, Guid.NewGuid()),
            new Models.Asegurado("Julio", "1234567890123458", 54 , DateTimeOffset.Now, Guid.NewGuid()),
            new Models.Asegurado("Alfredo", "1234567890123459", 98 , DateTimeOffset.Now, Guid.NewGuid())



        };
        /// <inheritdoc />
        public RI.Novus.Core.Asegurados.Asegurado GetAseguradoById(Guid id)
        {
            Arguments.NotNull(asegurados, nameof(asegurados));

            Models.Asegurado asegurado = asegurados.FirstOrDefault(asegurado => asegurado.Id == id);


            return asegurado.ToEntity();

        }

        /// <inheritdoc />
        public void Save(RI.Novus.Core.Asegurados.Asegurado asegurado)
        {
            var expedientDatabaseModel = Models.Asegurado.FromEntity(asegurado);

            asegurados.Add(expedientDatabaseModel);
        }

        /// <inheritdoc />
        ICollection<RI.Novus.Core.Asegurados.Asegurado> IAseguradoRepositoryDummy.GetAsegurados()
        {
                Arguments.NotNull(asegurados, nameof(asegurados));

            return new ReadOnlyCollection<RI.Novus.Core.Asegurados.Asegurado>(asegurados.Select(asegurado => asegurado.ToEntity()).ToList());

        }
    }
}
