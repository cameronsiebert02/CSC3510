using System;
namespace Hangman_In_Class
{
	public class Hangman_game
	{
        public int id { get; set; }
        public int userId { get; set; }
        public int miss { get; set; }
        public string secret_word { get; set; }
        public string show_word { get; set; }
        public string game_state { get; set; }
        public string guess_letters { get; set; }
        public int error { get; set; }
        public string Msg { get; set; }
        public Hangman_game() { }
        public Hangman_game(int id, int userId, int miss, string secret_word, string show_word, string game_state, string guess_letters)
        {
            this.id = id;
            this.userId = userId;
            this.miss = 0;
            this.secret_word = secret_word;
            this.show_word = show_word;
            this.game_state = game_state;
            this.guess_letters = guess_letters;
        }
    }
}