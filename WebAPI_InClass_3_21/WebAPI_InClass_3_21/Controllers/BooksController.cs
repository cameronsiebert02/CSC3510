using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_InClass_3_21.Controllers
{
    public class BooksController : Controller
    {
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        [Route("books")]
        public string Get()
        {
            string text = System.IO.File.ReadAllText("books.json");
            Rootobject theBooks = JsonConvert.DeserializeObject<Rootobject>(text);
            string ret = JsonConvert.SerializeObject(theBooks.books);
            return ret;
        }
        [HttpGet]
        [Route("books/{id:int}")]
        public string Get(int id)
        {
            string text = System.IO.File.ReadAllText("books.json");
            Rootobject theBooks = JsonConvert.DeserializeObject<Rootobject>(text);
            Book theBook = null;
            foreach(Book b in theBooks.books)
            {
                if(b.id == id)
                {
                    theBook = b;
                    break;
                }
            }
            string result = null;
            if(theBook != null)
            {
                result = JsonConvert.SerializeObject(theBook);
            }
            //string ret = JsonConvert.SerializeObject(theBooks.books);
            return result;
        }
    }
}