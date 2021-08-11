using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Kata
{
    private static int _dim;
    private static Dictionary<string,bool[]> _map; //E,S,W,N
    private static string _maze;

    public static bool PathFinder(string maze)
    {
        _dim = maze.IndexOf('\n');
        _map = new Dictionary<string, bool[]>();
        _maze = maze.Replace("\n","");
        return Search(0, 0, 4);
    }

    private static bool Search(int i, int j, int direction)
    {
        if (i >= _dim || j >= _dim || i < 0 || j < 0)
            return false;
        if (i == _dim - 1 && j == _dim - 1)
            return true;
        var key = $"{i},{j}";
        if (!_map.ContainsKey(key))        
            _map.Add(key, new bool[5]);        
        if (_map[key][direction] //Already visited
            || _maze[(i * _dim) + j] == 'W')
            return false;        
        _map[key][direction] = true;//Mark as visited
        //E,S,W,N
        if (Search(i , j + 1, 0) == true)
            return true;        
        if (Search(i + 1, j, 1) == true)        
            return true;        
        if (Search(i, j -1, 2) == true)        
            return true;        
        if (Search(i -1, j, 3) == true)        
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
                "....W.",
            e =".W...W\n" +
                ".W.W.W\n" +
                ".W.W.W\n" +
                ".W.W.W\n" +
                ".W.W.W\n" +
                "...W..",
            f = "......\n" +
                "WWWW.W\n" +
                "W....W\n" +
                "W.WWWW\n" +
                "W.....\n" +
                "...W..",

            g = "......\n" +
                ".W.W.W\n" +
                ".W...W\n" +
                ".W.WWW\n" +
                ".W....\n" +
                "...W..";

        Console.WriteLine($"Path for a possible? {PathFinder(a)}");
        Console.WriteLine($"Path for b possible? {PathFinder(b)}");
        Console.WriteLine($"Path for c possible? {PathFinder(c)}");
        Console.WriteLine($"Path for d possible? {PathFinder(d)}");
        Console.WriteLine($"Path for e possible? {PathFinder(e)}");
        Console.WriteLine($"Path for f possible? {PathFinder(f)}");
        Console.WriteLine($"Path for g possible? {PathFinder(g)}");
        Console.ReadLine();
    }
}