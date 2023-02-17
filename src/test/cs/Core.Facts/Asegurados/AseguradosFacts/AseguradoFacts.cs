using RI.Novus.Core.Boundaries.Persistence;

namespace RI.Novus.Core.Facts.Asegurados.AseguradosFacts
{
    /*
      Persist no debe recibir una instancia del repositorio vacia
     
     */
    [TestFixture]
    internal sealed class ExpedientFacts
    {
        [Test]
        public void When_Using_Persist_With_Null_Repository_Throws_Argument_Exception()
        {
            //Arrange
            Guid Id = Guid.NewGuid();
            string Name = "Expedient1";
            DateTimeOffset Birthdate = DateTimeOffset.Now;
            string identificacionNumber = "1234567890123456";
            int Age = 25;


            IAseguradoRepositoryDummy? aseguradoRepositoryDummy = null;

            var asegurado =  new RI.Novus.Core.Asegurados.Asegurado.Builder()
                         .WithName(RI.Novus.Core.Asegurados.Name.From(Name))
                         .WithAge(RI.Novus.Core.Asegurados.Age.From(Age))
                         .WithBirthdate(RI.Novus.Core.Asegurados.Birthdate.From(Birthdate))
                         .WithId(RI.Novus.Core.Asegurados.Id.From(Id))
                         .WithidentificationNumber(RI.Novus.Core.Asegurados.IdentificationNumber.From(identificacionNumber))
                         .Build();


            // Assert
            Assert.That(() =>
            {
                asegurado.Persist(aseguradoRepositoryDummy: aseguradoRepositoryDummy);

            }, Throws.ArgumentNullException);

        }
    }
}
