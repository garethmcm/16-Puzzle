public class Program
{
    public static void Main(string[] args)
    {
        Board board = new Board();
        board.displayBoard();
        while (!board.checkWinner())
        {
            board.makeMove();
            board.displayBoard();
        }
    }
}