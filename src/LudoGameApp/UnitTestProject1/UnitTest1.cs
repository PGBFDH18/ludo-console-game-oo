using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameEngine;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            LudoEngine game = new LudoEngine(3);

            // Act


            // Assert
            Assert.AreEqual(3, game.PlayersList.Count);
        }


        [TestMethod]
        public void MovePiece1()
        {
            // Arrange
            LudoEngine game = new LudoEngine(3);
            game.PlayersList[0].Pieces[0].InNest = false;
            game.PlayersList[0].Pieces[0].Movement = 37;
            game.Counter = 0;


            // Act
            game.MovePiece(1);

            // Assert
            Assert.AreEqual(1, game.FinalStretch[2].PieceList.Count);
        }

    }
}
