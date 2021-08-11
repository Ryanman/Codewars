using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Kata
{
    private static int _colDim;
    private static int _rowDim;
    private static Dictionary<string,bool[]> _map; //E,S,W,N
    private static string _maze;

    public static bool PathFinder(string maze)
    {
        _colDim = maze.IndexOf('\n');
        _map = new Dictionary<string, bool[]>();
        _maze = maze.Replace("\n","");
        _rowDim = _maze.Length / _colDim;
        Console.WriteLine(maze);
        return Search(0, 0, 4);
    }

    private static bool Search(int i, int j, int direction)
    {
        if (i >= _rowDim || j >= _colDim || i < 0 || j < 0)
            return false;
        if (i == _rowDim - 1 && j == _colDim - 1)
            return true;
        var key = $"{i},{j}";
        if (!_map.ContainsKey(key))        
            _map.Add(key, new bool[5]);        
        if (_map[key][direction] //Already visited
            || _maze[(i * _colDim) + j] == 'W')
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
            Console.WriteLine(map);
            Console.WriteLine($"Result: {PathFinder(map)}\r\n");
        }
        Console.ReadLine();
    }
}