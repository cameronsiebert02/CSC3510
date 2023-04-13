using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hangman_In_Class.Controllers {
    public class HangmanGamePrepController : Controller {
        public IActionResult Index() {
            return View();
        }
        [HttpGet("HangmanGamePrep")]
        public IActionResult HangmanGamePrep() {
            string ret = "OOK";
            List<Hangman_game> hGame = new List<Hangman_game>();
            DBGames DBG = new DBGames();
            string where = "";
            hGame = DBG.Select(where);
            ret = JsonConvert.SerializeObject(hGame);
            return Ok(ret);
        }
        [HttpGet("HangmanGamePrep/{id:int}")]
        public IActionResult HangmanGamePrep(int id) {
            string ret = "OOK";
            List<Hangman_game> hGame = new List<Hangman_game>();
            DBGames DBG = new DBGames();
            string where = String.Format("where  id='{0}'", id);
            hGame = DBG.Select(where);
            ret = JsonConvert.SerializeObject(hGame);
            return Ok(ret);
        }
        [HttpPost("HangmanGamePrep")]
        public IActionResult HangmanGamePrep([FromBody] HangmanGameCommand hmgCommand) {
            const int MAX_WRONG = 7;
            string ret = "OOK";
            System.Diagnostics.Debug.WriteLine("===========FL 0 STARTING=====");
            DBGames DBG = new DBGames();
           
            Hangman_game hg = new Hangman_game();
            if (hmgCommand.action.Equals("Create")) {
                ret = "Creating games";
                int userId = hmgCommand.userId;
                // Create new game but first make sure user doesn't have one already
                string q = "Select id, userId, miss, secret_word, show_word, game_state";
                       q += " from Hangman_game";
                string q1 = string.Format("Select game_state from Hangman_game where userId='{0}'",
                                                   userId);
                string gState = DBG.SlectSingleString(q1);
                System.Diagnostics.Debug.WriteLine("===========ABACK GSTATE=" + gState);
                if (gState.Equals("In_Progress") ){
                    hg.id = userId;
                    hg.error = 99;
                    hg.Msg = "Error game already in progress";
                    System.Diagnostics.Debug.WriteLine("===========INPROGRESS GSTATE=" + gState);
                }   else {
                    if (gState.Equals("Over")) {
                        string deleteq = string.Format(" where userId='{0}'",
                                                           userId);
                        System.Diagnostics.Debug.WriteLine("===========Delete PRev Game=" + userId);
                        DBG.Delete(userId);
                    } else {
                        System.Diagnostics.Debug.WriteLine("===========UNKNOWN GSTATE=" + gState);

                    }
                    hg.secret_word = DBG.getRandomWord();
                     hg.error = 0;
                     hg.userId = userId;
                     hg.miss = 0;
                     hg.show_word = "";
                     for (int i = 0; i < hg.secret_word.Length; i++) {
                               hg.show_word += '_';
                     }
                     hg.guess_letters = "";
                     hg.game_state = "In_Progress";

              
                     DBG.InsertGame(hg);
                     hg.Msg = "New Game Created";
                }
            }
            else if (hmgCommand.action.Equals("Guess")) {
                string where = string.Format(" where userId='{0}'", hmgCommand.userId);
                hg = DBG.SelectHangManGame(where);
                if ( hg.game_state != null) {
                    if (hg.game_state.Equals("Over")) {
                        hg.Msg = string.Format(" This game is over miss:{0} word:{1}", hg.miss, hg.show_word);
                        hg.error = 100;
                    }
                    else
                    {
                        //System.Diagnostics.Debug.WriteLine("===========FL 1 Miss=" + hg.miss);
                        ret = "Guessing";
                        char g = hmgCommand.guess[0];
                        StringBuilder show_word = new StringBuilder(hg.show_word);
                        StringBuilder secret_word = new StringBuilder(hg.secret_word);
                        int ct = 0;
                        bool gotOneBlank = false;
                        for (int i = 0; i < hg.secret_word.Length; i++) {
                            if (secret_word[i] == g)
                            {
                                hg.Msg = string.Format(" Found:{0}", ++ct);
                                show_word[i] = g;
                            }
                            else if (show_word[i] == '_')
                            {
                                gotOneBlank = true;
                            }
                            hg.show_word = show_word.ToString();
                        }
                        if (ct == 0) {
                            System.Diagnostics.Debug.WriteLine("===========Miss=" + hg.miss);
                            hg.miss += 1;
                            hg.Msg = string.Format(" Letter {0} Is Not Found", g);
                            hg.guess_letters += g;
                        }
                        if (!gotOneBlank) {
                            hg.game_state = "Over";
                            hg.Msg += "Game is Over ... you win!";
                            DBUsers2 DBU = new DBUsers2();
                            string w = string.Format(" where id='{0}'", hmgCommand.userId );
                            System.Diagnostics.Debug.WriteLine("===GOT ONE NOT =" +w);
                            List<Users> theUserAsAList = DBU.Select(w);
                            Users u =  theUserAsAList[0];
                            u.win += 1;
                           
                            DBU.update(u.userName, u.win, u.loss, w);
                        }
                        if (hg.miss >= MAX_WRONG) {
                            hg.game_state = "Over";
                            hg.Msg += "Loser Game Over";
                            DBUsers2 DBU = new DBUsers2();
                            string w = string.Format(" where id='{0}'", hmgCommand.userId);
                            System.Diagnostics.Debug.WriteLine("===Loser overNOT =" + w);
                            List<Users> theUserAsAList = DBU.Select(w);
                            Users u = theUserAsAList[0];
                            u.loss += 1;

                            DBU.update(u.userName, u.win, u.loss, w);
                        }
                        hg.error = 0;
                        DBG.Update(hg, where);
                    }
                } else {
                    ret = "Unknown UserId";
                    
                    hg.Msg = string.Format("Cannot find userId : {0}", hmgCommand.userId);
                    hg.error = 99;

                } 
             } else {
                ret = "Unknown action";
                hg = new Hangman_game();
                hg.error = 99;
                hg.Msg = string.Format(" Unknown action:%{0}", hmgCommand.action );
            }
            System.Diagnostics.Debug.WriteLine("===========FL 0 ENDING=====");
            ret = JsonConvert.SerializeObject(hg);
            return Ok(ret);
            
        }
    }
}