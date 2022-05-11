using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuessNumber.Tests
{
    [TestClass]
    public class GuessNumberGameTests
    {
        [TestMethod]
        public void GetResult()
        {
            //arrange
            int input = 23;            
            GuessNumberGameResult expected;            
            GuessNumberGame gng = new GuessNumberGame(input);
            int genValue = gng.numberValue;

            if (input < genValue)
            {
                expected =  GuessNumberGameResult.Greater;
            }
            else if (input > genValue)
            {
                expected = GuessNumberGameResult.Lower;
            }
            else
            {
                expected = GuessNumberGameResult.Equal;
            }

            //act
            var result = gng.GetResult(input);            

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
