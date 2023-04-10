using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            //string str = "Welcome human to my site";
            //return Ok(str);
            DBUsers DBC = new DBUsers();
            string where = " ";
            List<Users> hUsers = DBC.Select(where);
            string ret = JsonConvert.SerializeObject(hUsers);
            return Ok(ret);
        }
        [HttpGet("HangmanUsers/{id:int}")]
        public IActionResult HangmanUser(int id)
        {
            DBUsers DBC = new DBUsers();
            string where = string.Format(" Where id='{0}'", id);
            List<Users> hUsers = DBC.Select(where);
            string ret = JsonConvert.SerializeObject(hUsers);
            return Ok(ret);
        }
        [HttpPost("HangmanUsers")]
        public IActionResult HangmanUser([FromBody] Users u)
        {
            // Is username there already?
            string where = string.Format(" where userName='{0}'", u.userName);
            string q = "select count(*) from Hangman_User " + where;
            DBUsers DBC = new DBUsers();
            int ct = DBC.SelectSingleRow(q);
            if(ct > 0)
            {
                Users u2 = new Users();
                u2.userName = u.userName;
                u2.Msg = "Error userName exists";
                u2.error = 99;
                string ret = JsonConvert.SerializeObject(u2);
                return Ok(u2);

            }
            else
            {
            u.loss = 0;
            u.win = 0;
            u.Msg = "Insert Complete";
            
            DBC.Insert(u);
            string ret = JsonConvert.SerializeObject(u);
            return Ok(u);
            }
            
        }
    }
}