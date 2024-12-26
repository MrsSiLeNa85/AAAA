using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contr.Gover;
using Microsoft.Net.Http.Headers;
using WebApplication1.Contr;

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
            if (governments == null)
            {
                return BadRequest("Кудаааа");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(GovermentAdd gov)
        {
            var governments = new Government()
            {
                KingdomId = gov.KingdomID,
                LeaderName = gov.LeaderName,
                StartDate = gov.StartDate,
            };

            Context.Governments.Add(governments);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(GovermentOther gov)
        {
            Government? governments = Context.Governments.Where(x => x.GovernmentId == gov.GovermentID).FirstOrDefault();
            if (governments == null)
            {
                return BadRequest("Кудаааа");
            }
            governments.GovernmentId = gov.GovermentID;
            governments.KingdomId = gov.KingdomID;
            governments.LeaderName = gov.LeaderName;
            governments.  StartDate = gov.StartDate;
            Context.Governments.Update(governments);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Government? governments = Context.Governments.Where(x => x.GovernmentId == id).FirstOrDefault();
            if (governments == null)
            {
                return BadRequest("Кудаааа");
            }
            Context.Governments.Remove(governments);
            Context.SaveChanges();
            return Ok();
        }
    }
}
