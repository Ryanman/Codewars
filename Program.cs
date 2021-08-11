using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Kata
{
    private static int _dim;
    private static bool[,]_map;
    private static string _maze;

    public static bool PathFinder(string maze)
    {
        _dim = maze.IndexOf('\n');
        _map = new bool[_dim,_dim];
        _maze = maze.Replace("\n","");
        return Search(0, 0);
    }

    private static bool Search(int i, int j)
    {
        if (i >= _dim || j >= _dim || i < 0 || j < 0)
            return false;
        if (i == _dim - 1 && j == _dim - 1)
            return true;
        if (_map[i,j] //Already visited
            || _maze[(i * _dim) + j] == 'W')
            return false;
        _map[i, j] = true; //Mark as visited
        //Right, Down, Left, Up
        if (Search(i , j + 1) == true)
            return true;        
        if (Search(i + 1, j) == true)        
            return true;        
        if (Search(i, j -1) == true)        
            return true;        
        if (Search(i -1, j) == true)        
            return true;        
        return false;
    }

    public static void Main()
    {
        string a = ".W.\n" +
                   ".W.\n" +
                   "...",

               b = ".W.\n" +
                   ".W.\n" +
                   "W..",

               c = "......\n" +
                   "......\n" +
                   "......\n" +
                   "......\n" +
                   "......\n" +
                   "......",

               d = "......\n" +
                   "......\n" +
                   "......\n" +
                   "......\n" +
                   ".....W\n" +
                   "....W.";

        Console.WriteLine($"Path for a possible? {PathFinder(a)}");
        Console.WriteLine($"Path for a possible? {PathFinder(b)}");
        Console.WriteLine($"Path for a possible? {PathFinder(c)}");
        Console.WriteLine($"Path for a possible? {PathFinder(d)}");
        Console.ReadLine();
    }
}