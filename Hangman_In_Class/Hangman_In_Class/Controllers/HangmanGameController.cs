using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            List<Hangman_game> hGame = new List<Hangman_game>();
            DBGames DBG = new DBGames();
            string where = "";
            hGame = DBG.Select(where);
            string ret = JsonConvert.SerializeObject(hGame);
            return Ok(ret);
        }
        [HttpGet("HangmanGame/{id:int}")]
        public IActionResult HangmanGame(int id)
        { 
            List<Hangman_game> hGame = new List<Hangman_game>();
            DBGames DBG = new DBGames();
            string where = string.Format(" Where id='{0}'", id);
            hGame = DBG.Select(where);
            string ret = JsonConvert.SerializeObject(hGame);
            return Ok(ret);
        }
        [HttpPost("HangmanGame")]
        public IActionResult HangmanGame([FromBody] HangmanGameCommand hmg)
        {
            const int MAX_WRONG = 7;
            string ret = "OK";
            DBGames DBG = new DBGames();
            Hangman_game hangG = new Hangman_game();
            if (hmg.action.Equals("Create"))
            {
                ret = "Creating a game";
            }else if (hmg.action.Equals("Guess"))
            {
                string where = string.Format(" Where userId='{0}'", hmg.userId);
                hangG = DBG.SelectHangManGame(where);
                if(hangG != null)
                {
                    if (hangG.game_state.Equals("Over"))
                    {
                        hangG.Msg = string.Format("This game is over miss:{0} word:{1}", hangG.miss, hangG.secret_word);
                        hangG.error = 100;
                    }
                    else
                    {
                        char guess = hmg.guess[0];
                        StringBuilder show_word = new StringBuilder(hangG.show_word);
                        StringBuilder secret_word = new StringBuilder(hangG.secret_word);
                        int ct = 0;
                        bool gotOneBlank = false;
                        for (int i = 0;i < hangG.secret_word.Length; i++)
                        {
                            if (secret_word[i] == guess)
                            {
                                hangG.Msg = string.Format("Found:{0}", ++ct);
                                show_word[i] = guess;
                            }
                            else if (show_word[i] == '_')
                            {
                                gotOneBlank = true;
                            }
                        }
                        hangG.show_word = show_word.ToString();
                        // checked the word now generate response
                        if(ct == 0)
                        {
                            hangG.miss += 1;
                            hangG.Msg = string.Format("Letter:{0} is not found", guess);
                        }
                        if(!gotOneBlank)
                        {
                            hangG.game_state = "Over";
                            hangG.Msg = string.Format("Game over you win");
                            hangG.error = 0;
                            DBUsers DBU = new DBUsers();
                            string w = string.Format(" where id='{0}'", hangG.userId);
                            List<Users> usersAsList = DBU.Select(w);
                            Users theUser = usersAsList[0];
                            theUser.win += 1;
                            DBU.update(theUser.userName, theUser.win, theUser.loss, w);
                        }
                        if(hangG.miss > MAX_WRONG)
                        {
                            hangG.game_state = "Over";
                            hangG.Msg = string.Format("You are a loser Miss:{0}", hangG.miss);
                            hangG.error = 0;
                            DBUsers DBU = new DBUsers();
                            string w = string.Format(" where id='{0}'", hangG.userId);
                            List<Users> usersAsList = DBU.Select(w);
                            Users theUser = usersAsList[0];
                            theUser.loss += 1;
                            DBU.update(theUser.userName, theUser.win, theUser.loss, w);
                        }
                        DBG.Update(hangG, where);
                    }
                }
                ret = "Guessing";
            }
            else
            {
                ret = "Unkown action";
                hangG = new Hangman_game();
                hangG.Msg = string.Format("Unknown Action:{0}", hmg.action);
                hangG.error = 99;
            }
            ret = JsonConvert.SerializeObject(hangG);
            return Ok(ret);
        }
    }
}