using GrumingAPI.Models;
using GrumingAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static GrumingAPI.Controllers.ServiceController;

namespace GrumingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {

        static private readonly DBGruming _db = DBService.Instance.Context;

        public record PetPost(string Name, int Type, int Breed);
        public record PetPatch(string? Name, int? Type, int? Breed);

        [HttpPost]
        public IActionResult PostPet(PetPost br)
        {
            ClientPet cp = new();

            cp.IdBreed = br.Breed;
            cp.IdType = br.Type;
            cp.Name = br.Name;
            cp.IdClient = 1;
            _db.ClientPets.Add(cp);
            _db.SaveChanges();

            return Ok();
        }


        [HttpGet]
        public IActionResult GetPets()
        {

            return Ok(_db.ClientPets.ToList());
        }



    }
}
