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
    private static List<int[,]> _genericInput = new List<int[,]>();

    public static void Main()
    {
        var input = "";
        while (true)
        {
            _genericInput.Add(new int[,] //Incomplete (-1)
            {
                { 0,0,1},
                { 0,1,2},
                { 2,1,0}
            });
            _genericInput.Add(new int[,] //1
            {
                { 1,0,1},
                { 0,1,2},
                { 2,2,1}
            });
            _genericInput.Add(new int[,] //2
            {
                { 0,0,2},
                { 0,1,2},
                { 1,1,2}
            });
            _genericInput.Add(new int[,] //Cat's game (0)
            {
                { 1,2,1},
                { 1,1,2},
                { 2,1,2}
            });
            foreach (var board in _genericInput)
            {
                Console.WriteLine(
                    IsSolved(board));
            }
            Console.WriteLine($"Enter Number, or E for Exit");
            input = Console.ReadLine();
            if (input == "e")
                return;
            Console.ReadLine();
        }

    }
    public static int IsSolved(int[,] board)
    {
        var completed = true;
        for (int i = 0; i < 3; i++)
        {
            var corner = board[i, i];
            //Check Diagonals
            if (i == 1
                && ((board[0, 0] == corner && board[2, 2] == corner)
                    || (board[2, 0] == corner && board[0, 2] == corner)))
                return corner;
            for (int j = 0; j < 9; j++)
            {
                var piece = (j >= 3) ?
                    board[i, j] :
                    board[j % 3, i];
                if (piece == 0 || piece != corner)
                {
                    if (piece == 0)
                        completed = false;
                    break;
                }
                if (piece == corner && j % 3 == 2)
                    return corner;
            }
        }
        return completed ? 0 : -1;
    }
}