using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class PrioridadController : Controller
    {


        [EnableCors("API")]


        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            ML.Result result = BL.Prioridad.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }






    }
}
