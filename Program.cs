using System;
using System.Collections;
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

    public static void Main()
    {
        var input = "";
        var whileTest = 0;
        while (whileTest != 1)
        {
            var goodBoard = new int[9][];
            goodBoard[0] = new int[] { 5, 3, 4, 6, 7, 8, 9, 1, 2};
            goodBoard[1] = new int[] { 6, 7, 2, 1, 9, 5, 3, 4, 8 };
            goodBoard[2] = new int[] { 1, 9, 8, 3, 4, 2, 5, 6, 7 };
            goodBoard[3] = new int[] { 8, 5, 9, 7, 6, 1, 4, 2, 3 };
            goodBoard[4] = new int[] { 4, 2, 6, 8, 5, 3, 7, 9, 1 };
            goodBoard[5] = new int[] { 7, 1, 3, 9, 2, 4, 8, 5, 6 };
            goodBoard[6] = new int[] { 9, 6, 1, 5, 3, 7, 2, 8, 4 };
            goodBoard[7] = new int[] { 2, 8, 7, 4, 1, 9, 6, 3, 5 };
            goodBoard[8] = new int[] { 3, 4, 5, 2, 8, 6, 1, 7, 9 };

            //{

            //  {5, 3, 4, 6, 7, 8, 9, 1, 2},
            //  {6, 7, 2, 1, 9, 5, 3, 4, 8},
            //  {1, 9, 8, 3, 4, 2, 5, 6, 7},
            //  {8, 5, 9, 7, 6, 1, 4, 2, 3},
            //  {4, 2, 6, 8, 5, 3, 7, 9, 1},
            //  {7, 1, 3, 9, 2, 4, 8, 5, 6},
            //  {9, 6, 1, 5, 3, 7, 2, 8, 4},
            //  {2, 8, 7, 4, 1, 9, 6, 3, 5},
            //  {3, 4, 5, 2, 8, 6, 1, 7, 9}
            //};

            var res = ValidateSolution(goodBoard);

            Console.WriteLine($"{res}");
            var badBoard = new int[9][];
            badBoard[0] = new int[] { 5, 3, 4, 6, 7, 8, 9, 1, 2 };
            badBoard[0] = new int[] { 6, 7, 2, 1, 9, 0, 3, 4, 8 };
            badBoard[0] = new int[] { 1, 0, 0, 3, 4, 2, 5, 6, 0 };
            badBoard[0] = new int[] { 8, 5, 9, 7, 6, 1, 0, 2, 0 };
            badBoard[0] = new int[] { 4, 2, 6, 8, 5, 3, 7, 9, 1 };
            badBoard[0] = new int[] { 7, 1, 3, 9, 2, 4, 8, 5, 6 };
            badBoard[0] = new int[] { 9, 0, 1, 5, 3, 7, 2, 1, 4 };
            badBoard[0] = new int[] { 2, 8, 7, 4, 1, 9, 6, 3, 5 };
            badBoard[0] = new int[] { 3, 0, 0, 4, 8, 1, 1, 7, 9 };
            res = ValidateSolution(badBoard);
            Console.WriteLine($"{res}");
            input = Console.ReadLine();
            if (input == "e")
                return;
            Console.ReadLine();
        }
        Console.ReadLine();
    }

    static bool ValidateSolution(int[][] board)//int[][] board
    {
        var map = new Dictionary<Tuple<string, int>, BitArray>();
        var mapTypes = new string[] { "row","col","square" };
        for (int i = 0; i < 9; i++)
        {            
            for(int j = 0; j < 9; j++)
            {
                var value = board[i][j];
                if (i == 0)
                {
                    foreach (var mapType in mapTypes)
                    {
                        map[new Tuple<string, int>(mapType, j)] = new BitArray(10, false);
                    }
                }
                var rowKey = new Tuple<string, int>("row", i);
                var colKey = new Tuple<string, int>("col", j);
                var squareKey = new Tuple<string, int>("square", SquareBoardHash(i, j));
                if (value == 0
                    || map[rowKey][value] == true
                    || map[colKey][value] == true
                    || map[squareKey][value] == true)
                    return false;

                map[rowKey][value] = map[colKey][value] = map[squareKey][value] = true;
            }
        }
        return true;
    }

    private static int SquareBoardHash(int i, int j)
    {
        return //i / 3 + 
            ((i / 3) * 3) + 
            j / 3;
    }
}