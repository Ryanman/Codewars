using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Kata
{
    private static int _dim;
    private static Dictionary<string, bool> _map;
    private static string _maze;

    public static bool PathFinder(string maze)
    {
        _dim = Math.Max(maze.IndexOf('\n'),1);
        _map = new Dictionary<string, bool>();
        _maze = maze.Replace("\n", "");
        var result = Search(0, 0);
        return result;
    }

    private static bool Search(int i, int j)
    {
        if (i >= _dim || j >= _dim || i < 0 || j < 0)
            return false;
        if (i == _dim - 1 && j == _dim - 1)
            return true;
        var key = $"{i},{j}";
        if (_map.ContainsKey(key) //Already visited or wall
            || _maze[(i * _dim) + j] == 'W')
            return false;
        _map.Add(key, true);//Mark as visited
        //E,S,W,N
        if (Search(i, j + 1) == true)
            return true;
        if (Search(i + 1, j) == true)
            return true;
        if (Search(i, j - 1) == true)
            return true;
        if (Search(i - 1, j) == true)
            return true;
        return false;
    }

    public static void Main()
    {
        string[] maps = { ".W.\n" +
                   ".W.\n" +
                   "...",

                ".W...W\n" +
                ".W.W.W\n" +
                ".W.W.W\n" +
                ".W.W.W\n" +
                ".W.W.W\n" +
                "...W..",

                "......\n" +
                "WWWW.W\n" +
                "W....W\n" +
                "W.WWWW\n" +
                "W.....\n" +
                "...W..",

                ".",

                "......\n" +
                ".W.W.W\n" +
                ".W...W\n" +
                ".W.WWW\n" +
                ".W....\n" +
                "...W.."};

        foreach (var map in maps)
        {
            PathFinder(map);
            //Console.WriteLine(map);
            //Console.WriteLine($"Result: {PathFinder(map)}\r\n");
        }
        Console.ReadLine();
    }
}