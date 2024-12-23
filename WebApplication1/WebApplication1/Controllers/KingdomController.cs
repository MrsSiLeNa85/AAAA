using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KingdomController : ControllerBase
    {

        public MapbdContext Context { get; }
        public KingdomController(MapbdContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Kingdom> kingdoms = Context.Kingdoms.ToList();
            return Ok(kingdoms);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Kingdom? kingdoms = Context.Kingdoms.Where(x => x.KingdomId == id).FirstOrDefault();
            if (User == null)
            {
                return BadRequest("Кудаааа");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Kingdom kingdoms)
        {
            Context.Kingdoms.Add(kingdoms);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Kingdom kingdoms)
        {
            Context.Kingdoms.Update(kingdoms);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Kingdom? kingdoms = Context.Kingdoms.Where(x => x.KingdomId == id).FirstOrDefault();
            if (User == null)
            {
                return BadRequest("Кудаааа");
            }
            Context.Kingdoms.Remove(kingdoms);
            Context.SaveChanges();
            return Ok();
        }
    }
}
