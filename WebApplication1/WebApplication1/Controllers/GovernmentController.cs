using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernmentController : ControllerBase
    {

        public MapbdContext Context { get; }
        public GovernmentController(MapbdContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Government> governments = Context.Governments.ToList();
            return Ok(governments);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Government? governments = Context.Governments.Where(x => x.GovernmentId == id).FirstOrDefault();
            if (User == null)
            {
                return BadRequest("Кудаааа");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Government region)
        {
            Context.Governments.Add(region);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Government governments)
        {
            Context.Governments.Update(governments);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Government? governments = Context.Governments.Where(x => x.GovernmentId == id).FirstOrDefault();
            if (User == null)
            {
                return BadRequest("Кудаааа");
            }
            Context.Governments.Remove(governments);
            Context.SaveChanges();
            return Ok();
        }
    }
}
