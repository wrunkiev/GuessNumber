using System;

namespace GuessNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteConsole wc = new WriteConsole();
            ValidatorInput vi = new ValidatorInput();
            IGuessNumberGame guessNumberGame = new GuessNumberGame(101);
            IProgramManager programManager = new ProgramManager(wc, vi, guessNumberGame);
            programManager.Start();
        }
    }
}
