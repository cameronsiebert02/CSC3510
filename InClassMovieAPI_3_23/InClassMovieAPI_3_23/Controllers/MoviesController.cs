using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InClassMovieAPI_3_23.Controllers
{
    public class MoviesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("Movies")]
        public IActionResult Get()
        {
            //string str = "Seems to work";
            //IActionResult result = Ok(str);
            List<Movies> movies = new List<Movies>();
            string q = "Select is, name, sales, year from Movies";
            DBConnectMysql dbc = new DBConnectMysql();
            string where = "";
            List<Movies> movieRows = dbc.Select(where);
            string ret = JsonConvert.SerializeObject(movieRows);
            return Ok(ret);
            //IActionResult result = null;
            //return result;
        }
        [HttpGet]
        [Route("Movies/{id:int}")]
        public IActionResult Get(int id)
        {
            //string str = "Seems to work";
            //IActionResult result = Ok(str);
            List<Movies> movies = new List<Movies>();
            string q = "Select is, name, sales, year from Movies";
            DBConnectMysql dbc = new DBConnectMysql();
            string where = string.Format(" where id={0}", id);
            List<Movies> movieRows = dbc.Select(where);
            string ret = JsonConvert.SerializeObject(movieRows);
            return Ok(ret);
            //IActionResult result = null;
            //return result;
        }
        [HttpPost]
        [Route("Movies")]
        public IActionResult Post([FromBody] Movies m)
        {
            Console.WriteLine("---Inside Post");
            Console.WriteLine(m.name);
            Console.WriteLine(m.sales);

            DBConnectMysql dbc = new DBConnectMysql();
            dbc.Insert(m);

            string str = "Seems to work";
            IActionResult result = Ok(str);
            //List<Movies> movies = new List<Movies>();
            //string q = "Select is, name, sales, year from Movies";
            //DBConnectMysql dbc = new DBConnectMysql();
            //string where = string.Format(" where id={0}", id);
            //List<Movies> movieRows = dbc.Select(where);
            ////string ret = JsonConvert.SerializeObject(movieRows);
            //return Ok(ret);
            //IActionResult result = null;
            return result;
        }
    }
}

