using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InClassMovieAPI_3_23.Controllers
{
    public class Home : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Home2")]
        public ContentResult Home2()
        {
            var html = "<div style='color:red'> Welcome Home Again </div>";
            return base.Content(html, "text/html");
        }
        [HttpGet("Home3")]
        public ContentResult Home3()
        {

            var html = System.IO.File.ReadAllText(@"./bestMovies.html");
            return base.Content(html, "text/html");
        }
    }
}

