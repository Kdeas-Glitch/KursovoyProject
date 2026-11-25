using GrumingAPI.Models;
using GrumingAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrumingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedController : ControllerBase
    {
        static private readonly DBGruming _db = DBService.Instance.Context;

        [HttpGet]
        public IActionResult GetBreeds()
        {
            return Ok(_db.Breeds.ToList());
        }

        public record BreedPost(string Name, int MarkUp, int AddTime);
        public record BreedPatch(string? Name, int? MarkUp, int? AddTime);


        [HttpPost]
        public IActionResult PostBreeds(BreedPost br)
        {
            if (br.Name == null)
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

        [HttpPatch("{id}")]
        public IActionResult PatchBreeds(BreedPatch br,int id)
        {
            Breed breed = _db.Breeds.FirstOrDefault(i => i.IdBreed == id);//1983ke2007
            
            if(breed == null)
                return BadRequest();

            if(br.Name != null)
                breed.Name = br.Name;
            if(br.MarkUp != null)
                breed.Markup = (int)br.MarkUp;
            if(br.AddTime != null)
                breed.AddTime = (int)br.AddTime;

            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBreed(int id)
        {

            Breed t = _db.Breeds.FirstOrDefault(i => i.IdBreed == id);

            if (t == null)
            {
                return BadRequest();
            }

            _db.Breeds.Remove(t);
            _db.SaveChanges();
            return Ok();
        }
    }
}
