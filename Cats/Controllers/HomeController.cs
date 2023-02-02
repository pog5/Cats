using Cats.Data;
using Cats.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cats.Controllers
{
    public class HomeController : Controller
    {
        private CatContext _context;

        public HomeController(CatContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            var cats = this._context.Cats
                .Select(e => new Cat()
                {
                    Id = e.Id,
                    Name = e.Name
                }).ToList();
            return View(cats);
        }
    }
}
