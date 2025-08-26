using System;

class TicTacToe
{
    static char[,] board = {
        {'1', '2', '3'},
        {'4', '5', '6'},
        {'7', '8', '9'}
    };

    static char currentPlayer = 'X';

    static void Main()
    {
        int turns = 0;
        bool gameEnded = false;

        do
        {
            Console.Clear();
            DrawBoard();
            Console.WriteLine($"Player {currentPlayer}, choose your move (1-9):");
            string input = Console.ReadLine();

            if (!IsValidInput(input, out int row, out int col))
            {
                Console.WriteLine("Invalid input. Press any key to try again...");
                Console.ReadKey();
                continue;
            }

            if (board[row, col] == 'X' || board[row, col] == 'O')
            {
                Console.WriteLine("Cell already taken. Press any key to try again...");
                Console.ReadKey();
                continue;
            }

            board[row, col] = currentPlayer;
            turns++;

            if (CheckWinner())
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine($"🎉 Player {currentPlayer} wins!");
                gameEnded = true;
            }
            else if (turns == 9)
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine("It's a draw!");
                gameEnded = true;
            }
            else
            {
                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            }

        } while (!gameEnded);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static void DrawBoard()
    {
        Console.WriteLine("Tic Tac Toe\n");
        Console.WriteLine(" {0} | {1} | {2} ", board[0, 0], board[0, 1], board[0, 2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", board[1, 0], board[1, 1], board[1, 2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", board[2, 0], board[2, 1], board[2, 2]);
        Console.WriteLine();
    }

    static bool IsValidInput(string input, out int row, out int col)
    {
        row = -1; col = -1;

        if (!int.TryParse(input, out int pos)) return false;
        if (pos < 1 || pos > 9) return false;

        pos--; // Convert to 0-based index
        row = pos / 3;
        col = pos % 3;
        return true;
    }

    static bool CheckWinner()
    {
        // Check rows and columns
        for (int i = 0; i < 3; i++)
        {
            if ((board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2]) ||
                (board[0, i] == board[1, i] && board[1, i] == board[2, i]))
                return true;
        }

        // Check diagonals
        if ((board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) ||
            (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]))
            return true;

        return false;
    }
}
