using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber
{
    public static class GeneratorNumber
    {
        public static int GenerateNumber(int maxValue)
        {
            Random rnd = new Random();
            return rnd.Next(maxValue);
        }        
    }
}
