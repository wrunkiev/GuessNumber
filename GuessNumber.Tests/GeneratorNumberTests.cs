using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuessNumber.Tests
{
    [TestClass]
    public class GeneratorNumberTests
    {
        [TestMethod]
        public void GenerateNumber_GreaterZero()
        {
            //arrange
            int input = 5;
            bool expected = true;

            //act
            bool result = GeneratorNumber.GenerateNumber(input) >= 0;                        
            
            //assert
            Assert.AreEqual(expected, result);            
        }

        [TestMethod]
        public void GenerateNumber_LowerZero()
        {
            //arrange
            int input = 5;
            bool expected = true;

            //act
            bool result = GeneratorNumber.GenerateNumber(input) < 5;

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
