public class Board
{
    private Square[,] board;
    private Boolean winChecker;
    private int numberOfMoves;

    public Board()
    {
        board = new Square[4, 4]; // board is made up of square objects
        winChecker = false;
        numberOfMoves = 0;
        generateBoard(); // allocates random numbers to each square to give start point to game
    }
    
    public void generateBoard()
    {
        Random rand = new Random();
        // list is used to check which numbers have been used already to avoid doubles on board
        List<int> randomList = new List<int>();
        for (int i = 1; i < 17; i++)
        {
            int value;
            do
            {
                value = rand.Next(1, 17);
            } while (randomList.Contains(value));

            randomList.Add(value);
        }

        int listCount = 0;
        // keeps place on list
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                int listValue = randomList[listCount];
                board[row, col] = new Square(listValue);
                listCount++;
            }
        }
    }

    public void displayBoard()
    {
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                Console.Write($" {board[row, col],-3} ");
            }
            Console.WriteLine();
        }
        // shows how many moves user has made during game
        Console.WriteLine("Number of moves: " + numberOfMoves);
    }

    public void makeMove()
    {
        Console.WriteLine("Play on.");
        // coordinates of each square used to swap around on board with keystrokes below
        int x = 0, y = 0;

        while (board[x, y].value != 16)
        {
            y++;
            if (y >= 4)
            {
                y = 0;
                x++;
            }
        }
        
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        if (keyInfo.Key == ConsoleKey.UpArrow && x + 1 < 4)
        {
            int temp = board[x + 1, y].value;
            board[x + 1, y].value = 16;
            board[x, y].value = temp;
            numberOfMoves++;
        }
        else if (keyInfo.Key == ConsoleKey.DownArrow && x - 1 >= 0)
        {
            int temp = board[x - 1, y].value;
            board[x - 1, y].value = 16;
            board[x, y].value = temp;
            numberOfMoves++;
        }
        else if (keyInfo.Key == ConsoleKey.LeftArrow && y + 1 < 4)
        {
            int temp = board[x, y + 1].value;
            board[x, y + 1].value = 16;
            board[x, y].value = temp;
            numberOfMoves++;
        }
        else if (keyInfo.Key == ConsoleKey.RightArrow &&  y - 1 >= 0)
        {
            int temp = board[x, y - 1].value;
            board[x, y - 1].value = 16;
            board[x, y].value = temp;
            numberOfMoves++;
        }
        else
        {
            // if user tries to go out of bounds, doesn't count towards moves
            Console.WriteLine("Whoops! You can't move that way");
        }

    }

    public Boolean checkWinner()
    {
        // checks for a winner every game
        Boolean winCheck = false;
        int checker = 1;
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                while(board[row, col].value == checker)
                {
                    checker++;
                }
            }
        }
        if (checker == 17)
        {
            winCheck = true;
            Console.WriteLine("We have a winner!");
        }
        return winCheck;
    }
}