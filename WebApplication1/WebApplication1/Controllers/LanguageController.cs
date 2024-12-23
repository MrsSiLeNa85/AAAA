using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        public MapbdContext Context { get; }
        public LanguageController(MapbdContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Language> languages = Context.Languages.ToList();
            return Ok(languages);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Language? languages = Context.Languages.Where(x => x.LanguageId == id).FirstOrDefault();
            if (User == null)
            {
                return BadRequest("Кудаааа");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Language languages)
        {
            Context.Languages.Add(languages);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Language languages)
        {
            Context.Languages.Update(languages);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Language? languages = Context.Languages.Where(x => x.LanguageId == id).FirstOrDefault();
            if (User == null)
            {
                return BadRequest("Кудаааа");
            }
            Context.Languages.Remove(languages);
            Context.SaveChanges();
            return Ok();
        }
    }
}
