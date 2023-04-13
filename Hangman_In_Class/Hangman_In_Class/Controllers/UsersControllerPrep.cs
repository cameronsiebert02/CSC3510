using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hangman_In_Class.Controllers {
    public class UsersPrepController : Controller {
        const int MAX_LENGTH = 10;
        public IActionResult Index() {
            return View();
        }
        [HttpGet("HangmanPrepUsers")]
        public IActionResult HangmanPrepUser() {
            //string str = "Welcome human to my site";
            //return Ok(str);
            DBUsers2 DBC = new DBUsers2();
            string where = " ";
            List<Users> hUsers = DBC.Select(where);
            string ret = JsonConvert.SerializeObject(hUsers);
            DBC.CloseConnection();
            return Ok(ret);

        }
        [HttpGet("HangmanPrepUsers/{id:int}")]
        public IActionResult HangmanPrepUser(int id) {
            //string str = "Welcome human to my site";
            //return Ok(str);
            DBUsers2 DBC = new DBUsers2();
            string where = String.Format(" Where id='{0}'", id);
            List<Users> hUsers = DBC.Select(where);
            string ret = JsonConvert.SerializeObject(hUsers);
            DBC.CloseConnection();
            return Ok(ret);

        }
        [HttpPost("HangmanPrepUsers")]
        public IActionResult HangmanUsers([FromBody] Users u) {
            // Is userName there already? 
            string where = string.Format(" where userName='{0}'", u.userName);
            string q = "select count(*) from Hangman_User " + where;
            System.Diagnostics.Debug.WriteLine("QQQQQ=" + q);
            DBUsers2 DBC = new DBUsers2();
            int ct = DBC.SlectSingleRowRetInt(q);
            DBC.CloseConnection();
            string ret = "";
            if (ct > 0) {
                Users u2 = new Users();
                u2.userName = u.userName;
                u2.Msg = "Error userName exists";
                u2.error = 99;
                ret = JsonConvert.SerializeObject(u2);
                // return Ok(ret);
            } else if (u.userName.Length > MAX_LENGTH) {
                u.loss = 0;
                u.win = 0;
                System.Diagnostics.Debug.WriteLine("User Name Length:{0} Greater than man:{1}", u.userName.Length, MAX_LENGTH);
                u.Msg = string.Format("User Name Length:{0} Greater than man:{1}", u.userName.Length, MAX_LENGTH);
                u.error = 99;
                ret = JsonConvert.SerializeObject(u);
            } else {
                if (gotSpaces(u.userName)) {
                    System.Diagnostics.Debug.WriteLine("User Name Length:{0} contains spaces", u.userName.Length);
                    u.Msg = string.Format("User Name Length:{0} Contains spaces", u.userName.Length);
                    u.error = 99;
                    ret = JsonConvert.SerializeObject(u);
                } else {
                    System.Diagnostics.Debug.WriteLine("-->> OK UserName=" + u.userName);
                    u.loss = 0;
                    u.win = 0;
                    u.Msg = " Insert Complete";
                    u.error = 0;

                    where = " ";
                    DBC.Insert(u);
                    ret = JsonConvert.SerializeObject(u);
                    //return Ok(ret);
                }
            }
            DBC.CloseConnection();
            return Ok(ret);
        }

        bool gotSpaces(string userName) {
            foreach (char c in userName) {
                if (c == ' ') {
                    return true;
                }
            }
            return false;
        }
    }
}