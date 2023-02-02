using Microsoft.AspNetCore.Mvc;
using Cats.Data;
using Cats.Models;

namespace Cats.Controllers
{
    public class CatsController : Controller
    {
        private CatContext context;
        public CatsController(CatContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }
        [HttpPost]
        public IActionResult Add(Cat model)
        {
            if (this.ModelState.IsValid) {
                var cat = new Cat
                {
                    Age = model.Age,
                    Breed = model.Breed,
                    ImgUrl = model.ImgUrl,
                    Name = model.Name
                };
                this.context.Add(cat);
                this.context.SaveChanges();
                return RedirectToAction("Details", "Cats", new { id = cat.Id });
            }
            return this.View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var cat = context.Cats.Find(id);
            if (cat != null)
            {
                var model = new Cat
                {
                    Age = cat.Age,
                    Breed = cat.Breed,
                    ImgUrl = cat.ImgUrl,
                    Name = cat.Name
                };
                return this.View(model);
            }
            return NotFound();
        }
    }
}
