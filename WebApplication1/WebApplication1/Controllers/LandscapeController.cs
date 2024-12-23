using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandscapeController : ControllerBase
    {
        public MapbdContext Context { get; }
        public LandscapeController(MapbdContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Landscape> landscapes = Context.Landscapes.ToList();
            return Ok(landscapes);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Landscape? landscapes = Context.Landscapes.Where(x => x.LandscapeId == id).FirstOrDefault();
            if (User == null)
            {
                return BadRequest("Кудаааа");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Landscape landscapes)
        {
            Context.Landscapes.Add(landscapes);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Landscape landscapes)
        {
            Context.Landscapes.Update(landscapes);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Landscape? landscapes = Context.Landscapes.Where(x => x.LandscapeId == id).FirstOrDefault();
            if (User == null)
            {
                return BadRequest("Кудаааа");
            }
            Context.Landscapes.Remove(landscapes);
            Context.SaveChanges();
            return Ok();
        }
    }
}
