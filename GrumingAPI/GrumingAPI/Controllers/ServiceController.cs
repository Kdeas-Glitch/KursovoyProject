using GrumingAPI.Models;
using GrumingAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrumingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {

        static private readonly DBGruming _db = DBService.Instance.Context;

        [HttpGet]
        public IActionResult GetServices()
        {
            return Ok(_db.Services.ToList());
        }

        public record ServicePost(string Name, int Price, int Time);
        public record ServicePatch(string? Name, int? Price, int? Time);


        [HttpPost]
        public IActionResult PostService(ServicePost br)
        {
            if (br.Name == null)
            {
                return BadRequest();
            }

            Models.Service service = new();

            service.Name = br.Name;
            service.Price = br.Price;
            service.Time = br.Time;

            _db.Services.Add(service);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBreeds(ServicePatch br, int id)
        {
            Models.Service ser = _db.Services.FirstOrDefault(i => i.IdService == id);//1983ke2007

            if (ser == null)
                return BadRequest();

            if (br.Name != null)
                ser.Name = br.Name;
            if (br.Time != null)
                ser.Time = (int)br.Time;
            if (br.Price != null)
                ser.Price = (int)br.Price;

            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBreed(int id)
        {

            Models.Service t = _db.Services.FirstOrDefault(i => i.IdService == id);

            if (t == null)
            {
                return BadRequest();
            }

            _db.Services.Remove(t);
            _db.SaveChanges();
            return Ok();
        }
    }
}
