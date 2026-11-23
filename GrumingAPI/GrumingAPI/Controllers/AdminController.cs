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

        public record BreedPost(string Name,int MarkUp,int AddTime);
        public record TypePost(string Name);

        [HttpPost("Breed")]
        public IActionResult PostBreeds(BreedPost br)
        {
            if(br.Name == null)
            {
                return BadRequest();
            }

            Breed breed = new();

            breed.Name = br.Name;
            breed.Markup = br.MarkUp;
            breed.AddTime = br.AddTime;

            _db.Breeds.Add(breed);
            _db.SaveChanges();
            return Ok();
        }



        [HttpGet("Type")]
        public IActionResult GetTypeAnimal()
        {
            return Ok(_db.TypeAnimals.ToList());
        }

        [HttpPost("Type")]
        public IActionResult PostTypeAnimal(TypePost tp)
        {
            if (tp.Name == null)
            {
                return BadRequest();
            }

            TypeAnimal t = new TypeAnimal();
            t.Name = tp.Name;

            _db.TypeAnimals.Add(t);
            _db.SaveChanges();
            return Ok();
        }
    }
}
