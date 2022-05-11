using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace GuessNumber
{
    public class ValidatorInput : IValidatorInput
    {       
        public bool ValidateInput(string input)
        {
            int inputNumber;

            if (String.IsNullOrWhiteSpace(input))
            {                
                return false;
            }
            else
            {
                return int.TryParse(input, out inputNumber);                
            }                   
        }              
    }
}
