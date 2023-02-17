using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Optional;
using Persistence;
using RI.Novus.Core.Boundaries.Persistence;
using RI.Novus.Core.ImmovableOwner;
using RI.Novus.Core.ImmovableProperties;
using WebApiExample.ViewModels;

namespace WebApiExample.Controllers
{

    [Route("api/immovableOwners")]
    [ApiController]
    public class ImmovableController : Controller
    {
        private readonly IImmovableRepositoryDummy _immovableRepositoryDummy;

        public ImmovableController(IImmovableRepositoryDummy immovableRepositoryDummy ) 
        {
            _immovableRepositoryDummy = immovableRepositoryDummy;
        }

        [HttpPost]
        public IActionResult ImmovablePersist([FromBody] ImmovableOwnerModel immovableOwnerModel)
        {
           
            ImmovableOwnerClass owner = immovableOwnerModel.ToEntity();
            owner.Persist(_immovableRepositoryDummy);
            return Ok();
        }

        [HttpGet]

        public IActionResult ImmovableRetrieve()
        {

            return Ok(_immovableRepositoryDummy.Retrieve().Select(ImmovableOwnerModel.FromEntity));
        }

        [HttpDelete("{propertyClassId}")]
        public IActionResult ImmovableDelete(Guid propertyClassId) 
        {
            ImmovableOwnerClass.Delete(_immovableRepositoryDummy, propertyClassId);
            return Ok();
        }
        
        [HttpPatch("{ownerClassId}/properties/{propertyClassId}")]

        public IActionResult immovableProtetyUpdate([FromBody] ImmovablePropertyModel immovablePropertyModel, Guid propertyClassId, Guid ownerClassId) 
        {
            var immovableOwnerToUpdate = _immovableRepositoryDummy.RetrieveById(ownerClassId);
            ImmovablePropertyClass propertyClass = immovablePropertyModel.ToEntity();
            propertyClass.Update(_immovableRepositoryDummy, immovableOwnerToUpdate, propertyClassId);


            return Ok();
        }
    }
}
