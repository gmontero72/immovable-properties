using Microsoft.AspNetCore.Mvc;
using RI.Novus.Core.Boundaries.Persistence;
using WebApiExample.ViewModels;

namespace WebApiExample.Controllers
{
    [Route("api/asegurados")]
    [ApiController]
    public sealed class AseguradosController : ControllerBase
    {
        private readonly IAseguradoRepositoryDummy _aseguradoRepositoryDummy;

        public AseguradosController(IAseguradoRepositoryDummy aseguradoRepositoryDummy)
        {
            _aseguradoRepositoryDummy = aseguradoRepositoryDummy;
        }

        [HttpGet]
        public IActionResult GetAsegurados()
        {

            return Ok(_aseguradoRepositoryDummy.GetAsegurados().Select(AseguradoModel.FromEntity));
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetAseguradoById(Guid id)
        {

            RI.Novus.Core.Asegurados.Asegurado asegurado = _aseguradoRepositoryDummy.GetAseguradoById(id);

            return Ok(AseguradoModel.FromEntity(asegurado));

        }

        [HttpPost]

        public IActionResult Save([FromBody] AseguradoModel aseguradoModel)
        {


            try
            {
                RI.Novus.Core.Asegurados.Asegurado asegurado = aseguradoModel.ToEntity();

                asegurado.Persist(_aseguradoRepositoryDummy);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }

            return Ok();
        }

    }
}
