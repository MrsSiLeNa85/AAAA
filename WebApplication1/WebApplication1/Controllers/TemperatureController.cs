using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        public MapbdContext Context { get; }
        public TemperatureController(MapbdContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Temperature> temperatures = Context.Temperatures.ToList();
            return Ok(temperatures);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Temperature? temperatures = Context.Temperatures.Where(x => x.TemperatureId == id).FirstOrDefault();
            if (User == null)
            {
                return BadRequest("Кудаааа");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Temperature temperatures)
        {
            Context.Temperatures.Add(temperatures);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Temperature temperatures)
        {
            Context.Temperatures.Update(temperatures);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Temperature? temperatures = Context.Temperatures.Where(x => x.TemperatureId == id).FirstOrDefault();
            if (User == null)
            {
                return BadRequest("Кудаааа");
            }
            Context.Temperatures.Remove(temperatures);
            Context.SaveChanges();
            return Ok();
        }
    }
}
