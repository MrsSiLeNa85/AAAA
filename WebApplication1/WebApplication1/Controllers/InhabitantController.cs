using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InhabitantController : ControllerBase
    {

        public MapbdContext Context { get; }
        public InhabitantController(MapbdContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Inhabitant> inhabitants = Context.Inhabitants.ToList();
            return Ok(inhabitants);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Inhabitant? inhabitants = Context.Inhabitants.Where(x => x.InhabitantId == id).FirstOrDefault();
            if (User == null)
            {
                return BadRequest("Кудаааа");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Inhabitant inhabitants)
        {
            Context.Inhabitants.Add(inhabitants);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Inhabitant inhabitants)
        {
            Context.Inhabitants.Update(inhabitants);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Inhabitant? inhabitants = Context.Inhabitants.Where(x => x.InhabitantId == id).FirstOrDefault();
            if (User == null)
            {
                return BadRequest("Кудаааа");
            }
            Context.Inhabitants.Remove(inhabitants);
            Context.SaveChanges();
            return Ok();
        }
    }
}
