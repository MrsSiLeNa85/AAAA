using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImgController : ControllerBase
    {
        public MapbdContext Context { get; }
            public ImgController(MapbdContext context)
            {
                Context = context;
            }
            [HttpGet]
            public IActionResult GetAll()
            {
                List<Img> imgs = Context.Imgs.ToList();
                return Ok(imgs);
            }
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
            Img? imgs = Context.Imgs.Where(x => x.ImageId == id).FirstOrDefault();
                if (User == null)
                {
                    return BadRequest("Кудаааа");
                }
                return Ok();
            }
            [HttpPost]
            public IActionResult Add(Img imgs)
            {
                Context.Imgs.Add(imgs);
                Context.SaveChanges();
                return Ok();
            }
        [HttpPut]
            public IActionResult Update(Img imgs)
            {
                Context.Imgs.Update(imgs);
                Context.SaveChanges();
                return Ok();
            }
        [HttpDelete]
            public IActionResult Delete(int id)
            {
            Img? imgs = Context.Imgs.Where(x => x.ImageId == id).FirstOrDefault();
                if (User == null)
                {
                    return BadRequest("Кудаааа");
                }
                Context.Imgs.Remove(imgs);
                Context.SaveChanges();
                return Ok();
            }
        }
}
