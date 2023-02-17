using RI.Novus.Core.Boundaries.Persistence;
using RI.Novus.Core.ImmovableOwner;

namespace RI.Novus.Core.Facts.ImmovableProperty.ImmovablePropertyFacts
{
    [TestFixture]
    internal sealed class ImmovablePropertyFacts
    {

        [Test]
        public void When_Using_Persist_With_Null_Repository_Throws_Argument_Exception()
        {
            //Arrange
            Guid Id = Guid.NewGuid();
            decimal Area = 99.00M;
            decimal Surface = 99.00M;
            decimal Region = 99.00M;

            Guid IdProperty = Guid.NewGuid();
            string Name = "Jose Montero";
            DateTimeOffset CreationDate = DateTimeOffset.Now;
            string IdentificacionNumber = "1234567890123456";
            int Codia = 25;


            IImmovableRepositoryDummy? immovableRepositoryDummy = null;

            ImmovableProperties.ImmovablePropertyClass immovableProperty = new ImmovableProperties.ImmovablePropertyClass.Builder()
                         .WithArea(ImmovableProperties.Area.From(Area))
                         .WithSurface(ImmovableProperties.Surface.From(Surface))
                         .WithRegion(ImmovableProperties.Region.From(Region))
                         .WithId(ImmovableProperties.Id.From(IdProperty))
                         .Build();

            Core.ImmovableOwner.ImmovableOwnerClass immovableOwner = new Core.ImmovableOwner.ImmovableOwnerClass.Builder()
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
}
