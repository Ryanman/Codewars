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
            _genericInput.Add(new int[,] //Incomplete
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
            _genericInput.Add(new int[,] //Cat's game
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
        var gamestate = new Dictionary<string, int>()
        {
            { "1-i",0 },
            { "1-j",0 },
            { "2-i",0 },
            { "2-j",0 }
        };
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i,j] == 0)
                {
                    completed = false;
                    continue;
                }
                var key = $"{board[i, j]}-i";
                gamestate[$"{board[i, j]}-i"] += i;
                gamestate[$"{board[i, j]}-j"] += j;
            }
        }
        foreach(var elem in gamestate)
        {            
            if(elem.Value > 3)
            {
                return Convert.ToInt32(elem.Key.Substring(0,1));
            }
            return completed ? 0 : -1;
        }
        return 0;
    }
}