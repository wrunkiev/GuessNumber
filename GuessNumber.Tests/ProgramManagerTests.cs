using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuessNumber.Tests
{
    [TestClass]
    public class ProgramManagerTests
    {
        private readonly Mock<IWriter> _consoleMock = new Mock<IWriter>();
        private readonly Mock<IValidatorInput> _inputMock = new Mock<IValidatorInput>();
        private readonly Mock<IGuessNumberGame> _guessNumberGame = new Mock<IGuessNumberGame>();
        private ProgramManager _manager;

        [TestInitialize]
        public void Init()
        {
            _manager = new ProgramManager(_consoleMock.Object, _inputMock.Object, _guessNumberGame.Object);              
        }

        [TestMethod]
        public void Start_StringInput_ResultEqual()
        {
            // Arrange
            _inputMock.Setup(x => x.ValidateInput(It.IsAny<string>())).Returns(true);
            _guessNumberGame.Setup(x => x.GetResult(It.IsAny<int>())).Returns(GuessNumberGameResult.Equal);
            _consoleMock.Setup(x => x.WriteLine(It.IsAny<object>())).Verifiable();

            var seq = new MockSequence();
            _consoleMock.InSequence(seq).Setup(x => x.ReadLine()).Returns("100");
            _consoleMock.InSequence(seq).Setup(x => x.ReadLine()).Returns("N");

            // Act
            _manager.Start();

            // Assert           
            _consoleMock.Verify(x => x.WriteLine(UserMessageConstant.WelcomeMsg), Times.Once);
            _consoleMock.Verify(x => x.WriteLine(UserMessageConstant.GuessNumberMsg), Times.Once);
            _consoleMock.Verify(x => x.WriteLine(UserMessageConstant.CongratulationMsg), Times.Once);
        }

        [TestMethod]
        public void Start_StringInput_ResultGreater()
        {
            // Arrange
            _inputMock.Setup(x => x.ValidateInput(It.IsAny<string>())).Returns(true);            
            _consoleMock.Setup(x => x.WriteLine(It.IsAny<object>())).Verifiable();

            var seq = new MockSequence();
            _consoleMock.InSequence(seq).Setup(x => x.ReadLine()).Returns("0");
            _guessNumberGame.InSequence(seq).Setup(x => x.GetResult(It.IsAny<int>())).Returns(GuessNumberGameResult.Greater);
            _consoleMock.InSequence(seq).Setup(x => x.ReadLine()).Returns("50");
            _guessNumberGame.InSequence(seq).Setup(x => x.GetResult(It.IsAny<int>())).Returns(GuessNumberGameResult.Equal);
            _consoleMock.InSequence(seq).Setup(x => x.ReadLine()).Returns("N");

            // Act
            _manager.Start();

            // Assert           
            _consoleMock.Verify(x => x.WriteLine(UserMessageConstant.WelcomeMsg), Times.Once);
            _consoleMock.Verify(x => x.WriteLine(UserMessageConstant.GuessNumberMsg), Times.Once);
            _consoleMock.Verify(x => x.WriteLine(UserMessageConstant.EnterNumberGreaterMsg), Times.Once);
            _consoleMock.Verify(x => x.WriteLine(UserMessageConstant.CongratulationMsg), Times.Once);
        }

        [TestMethod]
        public void Start_StringInput_ResultLower()
        {
            // Arrange
            _inputMock.Setup(x => x.ValidateInput(It.IsAny<string>())).Returns(true);
            _consoleMock.Setup(x => x.WriteLine(It.IsAny<object>())).Verifiable();

            var seq = new MockSequence();
            _consoleMock.InSequence(seq).Setup(x => x.ReadLine()).Returns("100");
            _guessNumberGame.InSequence(seq).Setup(x => x.GetResult(It.IsAny<int>())).Returns(GuessNumberGameResult.Lower);
            _consoleMock.InSequence(seq).Setup(x => x.ReadLine()).Returns("50");
            _guessNumberGame.InSequence(seq).Setup(x => x.GetResult(It.IsAny<int>())).Returns(GuessNumberGameResult.Equal);
            _consoleMock.InSequence(seq).Setup(x => x.ReadLine()).Returns("N");

            // Act
            _manager.Start();

            // Assert           
            _consoleMock.Verify(x => x.WriteLine(UserMessageConstant.WelcomeMsg), Times.Once);
            _consoleMock.Verify(x => x.WriteLine(UserMessageConstant.GuessNumberMsg), Times.Once);
            _consoleMock.Verify(x => x.WriteLine(UserMessageConstant.EnterNumberLowerMsg), Times.Once);
            _consoleMock.Verify(x => x.WriteLine(UserMessageConstant.CongratulationMsg), Times.Once);
        }
    }
}
