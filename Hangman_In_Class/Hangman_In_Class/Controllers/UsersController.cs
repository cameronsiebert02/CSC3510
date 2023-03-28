using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hangman_In_Class.Controllers
{
    public class UsersController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet ("HangmanUsers")]
        public IActionResult HangmanUser()
        {
            string str = "Welcome human to my site";
            return Ok(str);
        }
    }
}