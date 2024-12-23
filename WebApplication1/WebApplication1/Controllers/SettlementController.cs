using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettlementController : ControllerBase
    {

        public MapbdContext Context { get; }
        public SettlementController(MapbdContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Settlement> settlements = Context.Settlements.ToList();
            return Ok(settlements);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Settlement? settlements = Context.Settlements.Where(x => x.SettlementId == id).FirstOrDefault();
            if (User == null)
            {
                return BadRequest("Кудаааа");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Settlement settlements)
        {
            Context.Settlements.Add(settlements);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Settlement settlements)
        {
            Context.Settlements.Update(settlements);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Settlement? settlements = Context.Settlements.Where(x => x.SettlementId == id).FirstOrDefault();
            if (User == null)
            {
                return BadRequest("Кудаааа");
            }
            Context.Settlements.Remove(settlements);
            Context.SaveChanges();
            return Ok();
        }
    }
}
 