using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Kata
{
    private static long _number;
    private static int _numUniqueChars = 0;
    private static Dictionary<char, int> _characters;
    private static LinkedListNode<int> _median;
    private static List<int> _productTracker = new List<int>();

    /*
    Combinations = word.len! / ((#LetterX!)(#LetterY!).....)
    */

    /*
     * Assuming 300 words
     * Index algo =
     * foreach letter
     *  # of partitions (ABC = 3 partitions)
     *  Get to 0-based index for that partition (B = 100, A = 0, C = 200)
     *  Decrement number of letters available in ordered dic
     *  Recurse?
     */

    public static long ListPosition(string value)
    {
        _number = 0;
        _characters = new Dictionary<char, int>()
        {
            {'A',0},
            {'B',0}
        };
        foreach (var c in value)
        {
            if (_characters[c] == 0)
                _numUniqueChars++;
            _characters[c]++;
        }
        var maxNumChars = _characters.Values.Max(); //Do the thing to simplify factorials here if there are errors https://www.chilimath.com/lessons/intermediate-algebra/dividing-factorials/
        
        return AddPositions(value);
    }

    private static long AddPositions(string value)
    {
        if (value.Length == 1)
            return 1;
        var lchar = value[0];
        long denom = 1;
        foreach (var c in _characters)
        {
            denom *= Factorial(c.Value == 0 ? 1 : c.Value);
        }
        var numPossibleWords = Factorial(value.Length)
            / denom;

        var partitionIndex = 0;
        var numPartitions = 0;
        foreach (var c in _characters)
        {
            if (c.Key == lchar)
                partitionIndex = numPartitions;
            numPartitions += c.Value;            
        }
        var x = (2 * 6) / 4;
        var partitionValue = //(partitionIndex / numPartitions) * numPossibleWords 
            (partitionIndex * numPossibleWords) / numPartitions;
        _number += partitionValue;
        _characters[lchar]--;
        if (_characters[lchar] == 0)
            _numUniqueChars--;
        return _number + AddPositions(value.Substring(1));
    }

    private static long Factorial(long n)
    {
        if (n == 0)
            return 1;
        return n * Factorial(n - 1);
    }

    public static void Main()
    {
        Tuple<string, int>[] testCases =
        {
            
            //new Tuple<string,int>("ABAB",2),
            //new Tuple<string,int>("A",1),
            //new Tuple<string,int>("AAAB",1),
            new Tuple<string,int>("BAAA",4),
            //new Tuple<string,int>("QUESTION",24527),
            //new Tuple<string,int>("BOOKKEEPER",10743),
        };

        foreach (var tc in testCases)
        {
            var position = ListPosition(tc.Item1);
            Console.WriteLine($"Word: {tc.Item1}\r\n\tExpected: {tc.Item2}\r\n\tActual: {position}");            
        }
        Console.ReadLine();
    }
}