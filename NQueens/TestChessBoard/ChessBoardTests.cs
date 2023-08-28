using NQueens;

namespace TestChessBoard
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestQueenSingle()
        {
            NQueens::ChessBoard cb = new NQueens::ChessBoard(4);
        }
    }
}