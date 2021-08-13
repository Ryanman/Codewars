using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Kata
{
    private static int _number;
    private static double _productSum = 0;
    private static LinkedList<int> _productList = new LinkedList<int>();
    private static LinkedListNode<int> _median;
    private static List<int> _productTracker = new List<int>();

    public static bool ValidateBattlefield(int[,] field)
    {
        // Write your magic here
        return true;
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
                    Console.Write($"field[i, j] ");
                }
                Console.WriteLine();
            }
            var result = ValidateBattlefield(field);
            Console.WriteLine($"Result: {result}");
        }
        Console.ReadLine();
    }
}