public class Board
{
    private Square[,] board;

    public Board()
    {
        board = new Square[4, 4]; // Create a 4x4 board
        generateBoard();
    }
    
    public void generateBoard()
    {
        List<int> availableValues = new List<int>();
        for (int i = 1; i <= 16; i++)
        {
            availableValues.Add(i);
        }

        Random rand = new Random();

        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                int randomIndex = rand.Next(0, availableValues.Count);
                int randomValue = availableValues[randomIndex];
                board[row, col] = new Square(randomValue);
                availableValues.RemoveAt(randomIndex);
            }
        }
    }
    
    public int GetSquareAllocation(Random rand, int minValue, int maxValue, HashSet<int> excludedNumbers)
    {
        int value;
        do
        {
            value = rand.Next(minValue, maxValue);
        } while (excludedNumbers.Contains(value));

        return value;
    }

    public void displayBoard()
    {
        
    }

    public void makeMove()
    {
        
    }

    public Boolean checkWinner()
    {
        Boolean winner = false;
        
        return winner;
    }
}