using GrumingAPI.Models;
using GrumingAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static GrumingAPI.Controllers.AdminController;

namespace GrumingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        static private readonly DBGruming _db = DBService.Instance.Context;

        public record TypePost(string Name);
        public record TypePatch(string? Name);

        [HttpGet]
        public IActionResult GetTypeAnimal()
        {
            return Ok(_db.TypeAnimals.ToList());
        }

        [HttpPost]
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

        [HttpPatch("{id}")]
        public IActionResult PatchTypeAnimal(TypePatch tp,int id)
        {
            if (tp.Name == null&&id!=-1)
            {
                return BadRequest();
            }



            TypeAnimal t = _db.TypeAnimals.FirstOrDefault(i => i.IdType==id);
            
            t.Name = tp.Name;

            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTypeAnimal(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            TypeAnimal t = _db.TypeAnimals.FirstOrDefault(i => i.IdType == id);

            if (t == null)
            {
                return BadRequest();
            }

            _db.TypeAnimals.Remove(t);
            _db.SaveChanges();
            return Ok();
        }

    }
}
