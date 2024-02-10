using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {



        [EnableCors("API")]


        [HttpPost("add/{idUsuario}")]
   
        public IActionResult Add(int idUsuario, [FromBody] ML.Task task)
        {

            ML.Result result = BL.Task.Add(task, idUsuario);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }


        }



        [HttpGet("getAll/{idUsuario}/{txtSearch}/{dtFechaVencimiento}")]

        public IActionResult GetAll(int idUsuario, string txtSearch, string dtFechaVencimiento)
        {

            txtSearch = txtSearch == "0" ? "" : txtSearch;
            dtFechaVencimiento = dtFechaVencimiento == "0" ? "" : dtFechaVencimiento;


            ML.Result result = BL.Task.GetAll(idUsuario, txtSearch, dtFechaVencimiento);


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
