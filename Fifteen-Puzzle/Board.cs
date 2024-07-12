using System;
using System.Collections.Generic;

public class Board
{
    private Square[,] board;
    private Boolean winChecker;

    public Board()
    {
        board = new Square[4, 4]; // Create a 4x4 board
        winChecker = false;
        generateBoard();
    }
    
    public void generateBoard()
    {
        Random rand = new Random();
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
                Console.Write(board[row, col].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public void makeMove()
    {
        int x = 0, y = 0;
        
        while(board[x, y].GetValue() != 16)
        {
            y++;
            if (y >= 4)
            {
                y = 0;
                x++;
            }
        }
                
        while (!winChecker)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (x-1 >= 0)
                    {
                        int temp = board[x-1, y].GetValue();
                        board[x-1, y].SetValue(16);
                        board[x, y].SetValue(temp);
                    }
                    break;

                case ConsoleKey.DownArrow:
                if (x+1 <= 4)
                {
                    int temp = board[x+1, y].GetValue();
                    board[x+1, y].SetValue(16);
                    board[x, y].SetValue(temp);
                }
                break;
                
                case ConsoleKey.LeftArrow:
                    if (y-1 >= 0)
                    {
                        int temp = board[x, y-1].GetValue();
                        board[x, y-1].SetValue(16);
                        board[x, y].SetValue(temp);
                    }
                    break;
                
                case ConsoleKey.RightArrow:
                    if (y-1 <= 4)
                    {
                        int temp = board[x, y+1].GetValue();
                        board[x, y+1].SetValue(16);
                        board[x, y].SetValue(temp);
                        
                    }
                    break;
                
                default:
                    continue;
            }
        }
    }

    public Boolean checkWinner()
    {
        Boolean winCheck = false;
        int checker = 1;
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                while(board[row, col].GetValue() == checker)
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
        Console.WriteLine("Game on.");
        return winCheck;
    }
}