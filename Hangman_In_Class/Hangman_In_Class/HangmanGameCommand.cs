using System;
namespace Hangman_In_Class
{
	public class HangmanGameCommand
	{
        public int userId { get; set; }
        public string guess { get; set; }
        public string action { get; set; }
        public HangmanGameCommand()
        {
            this.userId = 0;
            this.guess = "Null";
            this.action = "action";
        }
        public HangmanGameCommand(int userName, string guess, string action)
        {
            this.userId = userId;
            this.guess = guess;
            this.action = action;
        }
    }
}