using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber
{
    public class ProgramManager : IProgramManager
    {
        private IGuessNumberGame _compValue;
        private IWriter _wc;
        private IValidatorInput _vi;

        public ProgramManager(IWriter console, IValidatorInput input, IGuessNumberGame guessNumberGame)        
        {            
            _wc = console;
            _vi = input;
            _compValue = guessNumberGame;
        }

        
        public void Start()
        {                   
            PrintWelcome();
            var userInputValue = InputUser();
            ProceedUserInput(userInputValue);
        }

        private void PrintWelcome()
        {
            _wc.WriteLine(UserMessageConstant.WelcomeMsg);
            _wc.WriteLine(UserMessageConstant.GuessNumberMsg);
            PrintYourNumber();
        }

        private int InputUser()
        {
            string input = _wc.ReadLine();
            
            if (_vi.ValidateInput(input))
            {
                return int.Parse(input);
            }

            PrintInvalidInputWarning();
            PrintYourNumber();           
                
            return InputUser();            
        }

        private void ProceedUserInput(int input)
        {
            var gameResult = _compValue.GetResult(input);
            InvokeAction(gameResult);
        }

        private void RestartGame(string answer)
        {
            if (answer.Equals("Y"))
            {
                _vi = new ValidatorInput();
                _compValue = new GuessNumberGame(101);
                _wc = new WriteConsole();
                Start();
            }
        }

        private void InvokeAction(GuessNumberGameResult guessNumberGameResult)
        {
            if (guessNumberGameResult == GuessNumberGameResult.Equal)
            {
                PrintCongratulations();
                return;
            }

            if (guessNumberGameResult == GuessNumberGameResult.Greater)
            {
                PrintGreater();
            }
            else if (guessNumberGameResult == GuessNumberGameResult.Lower)
            {
                PrintLower();
            }
            else
            {
                throw new NotImplementedException();
            }

            PrintYourNumber();
            int result = InputUser();
            ProceedUserInput(result);
        }

        private void ExitGame(string exit)
        {
            if (exit.Equals("Y") || exit.Equals("N"))
            {
                RestartGame(exit);
                return;
            }

            PrintCongratulations();
        }

        private void PrintCongratulations()
        {
            _wc.WriteLine(UserMessageConstant.CongratulationMsg);
            _wc.WriteLine(UserMessageConstant.PlayAgainMsg);
            _wc.WriteLine(UserMessageConstant.QuestionYesMsg);
            _wc.WriteLine(UserMessageConstant.QuestionNotMsg);
            ExitGame(_wc.ReadLine());
        }

        private void PrintGreater()
        {
            _wc.WriteLine(UserMessageConstant.EnterNumberGreaterMsg);
        }

        private void PrintLower()
        {
            _wc.WriteLine(UserMessageConstant.EnterNumberLowerMsg);
        }

        private void PrintYourNumber()
        {
            _wc.Write(UserMessageConstant.EnterYourNumberMsg);
        }

        private void PrintInvalidInputWarning()
        {
            _wc.WriteLine(UserMessageConstant.InvalidWarningMsg);
        }      
    }
}
