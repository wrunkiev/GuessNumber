using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuessNumber.Tests
{
    [TestClass]
    public class ValidatorInputTests
    {       
        [DataRow("")]
        [DataRow("abc")]
        [TestMethod]
        public void ValidateInput_String_BoolFalse(string input)
        {
            //arrange
            ValidatorInput vi = new ValidatorInput();
            var expected = false;

            //act
            var result = vi.ValidateInput(input);

            //assert
            Assert.AreEqual(expected, result);
        }

        [DataRow("123")]
        [DataRow("12")]
        [TestMethod]
        public void ValidateInput_StringInt_BoolTrue(string input)
        {
            //arrange            
            ValidatorInput vi = new ValidatorInput();
            var expected = true;

            //act
            var result = vi.ValidateInput(input);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
