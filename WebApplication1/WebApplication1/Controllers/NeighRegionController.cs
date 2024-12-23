using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeighRegionController : ControllerBase
    {
        public MapbdContext Context { get; }
        public NeighRegionController(MapbdContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<NeighRegion> neighRegions = Context.NeighRegions.ToList();
            return Ok(neighRegions);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            NeighRegion? neighRegions = Context.NeighRegions.Where(x => x.RegionId == id).FirstOrDefault();
            if (User == null)
            {
                return BadRequest("Кудаааа");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(NeighRegion neighRegions)
        {
            Context.NeighRegions.Add(neighRegions);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(NeighRegion neighRegions)
        {
            Context.NeighRegions.Update(neighRegions);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            NeighRegion? neighRegions = Context.NeighRegions.Where(x => x.RegionId == id).FirstOrDefault();
            if (User == null)
            {
                return BadRequest("Кудаааа");
            }
            Context.NeighRegions.Remove(neighRegions);
            Context.SaveChanges();
            return Ok();
        }
    }
}
