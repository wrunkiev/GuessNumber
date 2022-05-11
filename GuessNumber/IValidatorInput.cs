using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber
{
    public interface IValidatorInput
    {
        bool ValidateInput(string input);
    }
}
