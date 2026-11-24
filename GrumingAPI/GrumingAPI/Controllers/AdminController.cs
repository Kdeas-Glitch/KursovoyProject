using GrumingAPI.Models;
using GrumingAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrumingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        static private readonly DBGruming _db = DBService.Instance.Context;


        [HttpGet("Clients")]
        public IActionResult GetClients()
        {
            return Ok(_db.Clients.ToList());
        }


        [HttpGet("Breed")]
        public IActionResult GetBreeds()
        {
            return Ok(_db.Breeds.ToList());
        }

       



    }
}
