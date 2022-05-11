using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber
{
    public class GuessNumberGame : IGuessNumberGame
    {
        public readonly int numberValue;

        public GuessNumberGame(int maxValue)
        {
            numberValue = GeneratorNumber.GenerateNumber(maxValue);
        }

        public GuessNumberGameResult GetResult(int inputUser)
        {
            if (numberValue > inputUser)
            {
                return GuessNumberGameResult.Greater;
            }
            else if (numberValue < inputUser)
            {
                return GuessNumberGameResult.Lower;
            }
            else
            {
                return GuessNumberGameResult.Equal;
            }            
        }        
    }
}
