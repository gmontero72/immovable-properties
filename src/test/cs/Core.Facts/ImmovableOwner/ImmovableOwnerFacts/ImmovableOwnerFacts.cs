using RI.Novus.Core.Boundaries.Persistence;

namespace RI.Novus.Core.Facts.ImmovableOwner.ImmovableOwnerFacts;

/*
  Persist no debe recibir una instancia del repositorio vacia
 
 */
[TestFixture]
internal sealed class ImmovableOwnerFacts
{
    [Test]
    public void When_Using_Persist_With_Null_Repository_Throws_Argument_Exception()
    {
        //Arrange
        Guid Id = Guid.NewGuid();
        string Name = "Jose Montero";
        DateTimeOffset CreationDate = DateTimeOffset.Now;
        string IdentificacionNumber = "1234567890123456";
        int Codia = 25;


        IImmovableRepositoryDummy? immovableRepositoryDummy = null;

        Core.ImmovableOwner.ImmovableOwnerClass immovableOwner =  new Core.ImmovableOwner.ImmovableOwnerClass.Builder()
                     .WithName(Core.ImmovableOwner.Name.From(Name))
                     .WithCodia(Core.ImmovableOwner.Codia.From(Codia))
                     .WithCreationDate(Core.ImmovableOwner.CreationDate.From(CreationDate))
                     .WithId(Core.ImmovableOwner.Id.From(Id))
                     .WithIdentificationNumber(Core.ImmovableOwner.IdentificationNumber.From(IdentificacionNumber))
                     .Build();


        // Assert
        Assert.That(() =>
        {
            immovableOwner.Persist(immovableRepositoryDummy: immovableRepositoryDummy);

        }, Throws.ArgumentNullException);

    }
}
