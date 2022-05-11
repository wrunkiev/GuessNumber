using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber
{
    public interface IGuessNumberGame
    {
        GuessNumberGameResult GetResult(int inputUser);
    }
}
