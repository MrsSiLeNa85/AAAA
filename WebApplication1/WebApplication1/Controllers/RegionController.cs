using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    
    public class RegionController : ControllerBase
    {
        public MapbdContext Context { get; }
        public RegionController(MapbdContext context) 
        {
            Context = context;
        }
        [HttpGet]  
        public IActionResult GetAll()
        {
            List<Region> regions = Context.Regions.ToList();
            return Ok(regions);
        }
        [HttpGet("{id}")]
        public IActionResult GetById (int id)
        {
            Region? region = Context.Regions.Where(x => x.RegionId == id).FirstOrDefault();
            if (User == null)
            {
                return BadRequest("Кудаааа");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add (Region region)
        {
            Context.Regions.Add(region);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Region region)
        {
            Context.Regions.Update(region);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Region? region = Context.Regions.Where(x => x.RegionId == id).FirstOrDefault();
            if (User == null)
            {
                return BadRequest("Кудаааа");
            }
            Context.Regions.Remove(region);
            Context.SaveChanges();
            return Ok();
        }
    }
    
}
