using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_InClass_3_21.Controllers
{
    public class Items : Controller
    {
        //// GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        [Route("items")]
        public string Get()
        {
            string text = "Welcome to my items!";
            return text;
        }
        [HttpGet]
        [Route("items/{id:int}")]
        public string Get(int id)
        {
            string text = "Details for item:" + id;
            return text;
        }
    }
}