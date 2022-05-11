using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuessNumber.Tests
{
    [TestClass]
    public class WriteConsoleTests
    {
        [TestMethod]
        public void WriteLine_String_Pass()
        {
            //arrange
            string stringInput = "test";
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            WriteConsole wc = new WriteConsole();
            string expected = "test" + Environment.NewLine;

            //act            
            wc.WriteLine(stringInput);

            //assert
            Assert.AreEqual(expected, stringWriter.ToString());
        }

        [TestMethod]
        public void ReadLine_String_Pass()
        {
            //arrange
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("test");

            var stringReader = new StringReader(stringBuilder.ToString());
            Console.SetIn(stringReader);

            WriteConsole wc = new WriteConsole();

            var expected = "test";

            //act            
            var line = wc.ReadLine();

            //assert
            Assert.AreEqual(expected, line);
        }
    }
}
