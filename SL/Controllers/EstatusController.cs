using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EstatusController : Controller
    {




        [EnableCors("API")]


        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            ML.Result result = BL.Estatus.GetAll();

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
