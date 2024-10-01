using System;
using System.Runtime.InteropServices;

class Program
{
    static char[,] board =
    {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };
    static char currentPlayer = 'X';

    static void Main(string[] args)
    {
        int turns = 0;
        bool isGameOver = false;

        while (!isGameOver)
        {
            Console.Clear();
            PrintBoard(); // tady voláme metodu PrintBoard

            Console.WriteLine($"\nHráč {currentPlayer}, zadej tlačítko pozice:");
            int Position = Convert.ToInt32(Console.ReadLine()) - 1;

            int row = Position / 3;
            int col = Position % 3;

            if (board[row, col] != 'X' && board[row, col] != '0')
            {
                board[row, col] = currentPlayer;
                turns++;
            }
            else
            {
                Console.WriteLine("Pozice je obsazená, zkuste to znovu!");
                continue;
            }

            if (CheckWinner())
            {
                Console.Clear();
                PrintBoard(); // opět volání metody
                Console.WriteLine($"\nHráč {currentPlayer} vyhrál!");
                isGameOver = true;
            }
            else if (turns == 9)
            {
                Console.Clear();
                PrintBoard(); // znovu volání metody
                Console.WriteLine("\nRemíza!");
                isGameOver = true;
            }
            else
            {
                currentPlayer = (currentPlayer == 'X') ? '0' : 'X';
            }
        }
    }

    // Metoda PrintBoard je definovaná zde
    static void PrintBoard()
    {
        Console.WriteLine(" Piškvorky");
        Console.WriteLine("-------------");
        for (int i = 0; i < 3; i++)
        {
            Console.Write("| ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j] + " | ");
            }
            Console.WriteLine("\n-------------");
        }
    }
    static bool CheckWinner()
    {
        // Kontrola řádků
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                return true;
        }

        // Kontrola sloupců
        for (int i = 0; i < 3; i++)
        {
            if (board[0, 1] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                return true;
        }

        // Kontrola diagonál
        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
            return true;

        if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
            return true;

        return false;
    }
}
