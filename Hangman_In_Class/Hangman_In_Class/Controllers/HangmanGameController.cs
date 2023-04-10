using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hangman_In_Class.Controllers
{
    public class HangmanGameController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("HangmanGame")]
        public IActionResult HangmanGame()
        {
            string ret = "OK";
            List<Hangman_game> hGame = new List<Hangman_game>();
            DBGames DBG = new DBGames();
            string where = "";
            hGame = DBG.Select(where);
            ret = JsonConvert.SerializeObject(hGame);
            return Ok(ret);
        }
        [HttpGet("HangmanGame/{id:int}")]
        public IActionResult HangmanGame(int id)
        {
            string ret = "OK";
            List<Hangman_game> hGame = new List<Hangman_game>();
            DBGames DBG = new DBGames();
            string where = string.Format(" Where id='{0}'", id);
            hGame = DBG.Select(where);
            ret = JsonConvert.SerializeObject(hGame);
            return Ok(ret);
        }
        [HttpPost("HangmanGame")]
        public IActionResult HangmanGame([FromBody] HangmanGameCommand HGC)
        {
            string ret = "OK";
            DBGames DBG = new DBGames();
            List<Hangman_game> hangG = new List<Hangman_game>();
            if (HGC.action.Equals("Create"))
            {
                ret = "Creating a game";
            }else if (HGC.action.Equals("Guess"))
            {
                string where = string.Format(" Where userId='{0}'", HGC.userId);
                hangG = DBG.Select(where);
                Hangman_game hg = hangG[0];

                ret = "Guessing";
            }
            else
            {
                ret = "Unkown action";
            }
            return Ok(ret);
        }
    }
}