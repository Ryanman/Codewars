using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Kata
{
    private static Dictionary<int, int> _ships = new Dictionary<int, int> //Length and Num
    {
        {4,1},//Battleship
        {3,2},//Cruisers
        {2,3},//Destroyers
        {1,4},//Submarines
    };

    public static bool ValidateBattlefield(int[,] field)
    {
        // Write your magic here
        /*
         * Subs: 1 with no surrounding, 4
         * Destroyers: 2 with 1 surrounding, 3 (6 squares)
         * Cruisers: 3 with 1 surrounding, 2 (6 squares)
         * Battleship: 4, 1 (4)
         * Total = 20 squares
         * Iterate through like a book
         *  if (sum of R,D,RD > 1) return false
         *  For each = 1, mark as possible ship
         *  Check left and up and eliminate possibilities
         *  If 0 but left or up, "Close Out" a ship
         * If not all ships closed out, return false
         */
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (field[i, j] != 1)
                {
                    continue;
                }
                if (i < 8 && j < 8) //Check for illegal diagonal connections
                {
                    if ((field[i, j + 1] + field[i + 1, j] + field[i + 1, j + 1]) > 1)
                        return false;
                }
                var length = FillShip(field, i, j);
                if (length > 4)
                    return false;
                _ships[length]--;
                Console.WriteLine($"Found ship of length {length} at {i},{j}"); //Remove
            }
        }
        foreach(var ship in _ships)
        {
            if (ship.Value != 0)
                return false;
        }
        return true;
    }

    private static int FillShip(int[,] field, int i, int j, int shipLength = 1)
    {
        if (field[i,j] == 0 || i > 8 || j > 8)
        {
            return shipLength;
        }
        if (field[i, j +1] == 1) //Chase Right
        {
            shipLength = FillShip(field, i, j + 1, shipLength + 1);
        }
        else if (field[i +1, j] == 1) //Chase Down
        {
            shipLength = FillShip(field, i + 1, j, shipLength + 1);
        }
        field[i, j] = shipLength;
        return shipLength;
    }

    public static void Main()
    {
        List<int[,]> fields = new List<int[,]>() { 
            new int[10, 10]
                     {{1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                      {1, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                      {1, 0, 1, 0, 1, 1, 1, 0, 1, 0},
                      {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}} 
        };
        foreach (var field in fields)
        {
            Console.WriteLine("Field:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("\t");
                for(int j = 0; j < 10; j++)
                {
                    Console.Write($"{field[i, j]}");
                }
                Console.WriteLine();
            }
            var result = ValidateBattlefield(field);
            Console.WriteLine($"Result: {result}");
        }
        Console.ReadLine();
    }
}