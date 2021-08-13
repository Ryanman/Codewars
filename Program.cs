using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Kata
{
    private static Dictionary<char, int> _characterCounts;
    public static long ListPosition(string value)
    {
        _characterCounts = new Dictionary<char, int>()
        {
            {'A',0},
            {'B',0},
            {'C',0},
            {'D',0},
            {'E',0},
            {'F',0},
            {'G',0},
            {'H',0},
            {'I',0},
            {'J',0},
            {'K',0},
            {'L',0},
            {'M',0},
            {'N',0},
            {'O',0},
            {'P',0},
            {'Q',0},
            {'R',0},
            {'S',0},
            {'T',0},
            {'U',0},
            {'V',0},
            {'W',0},
            {'X',0},
            {'Y',0},
            {'Z',0},
        };
        foreach (var c in value)
        {
            _characterCounts[c]++;
        }        
        return AddPositions(value);
    }

    private static long AddPositions(string value)
    {
        if (value.Length == 1)
            return 1;
        var leadCharacter = value[0];
        long denom = 1;
        var partitionIndex = 0;
        var numPartitions = 0;
        foreach (var c in _characterCounts)
        {
            denom *= Factorial(c.Value == 0 ? 1 : c.Value);
            if (c.Key == leadCharacter)
                partitionIndex = numPartitions;
            numPartitions += c.Value;
        }
        var numPossibleWords = Factorial(value.Length) / denom;
        var partitionValue = (partitionIndex * numPossibleWords) / numPartitions;
        _characterCounts[leadCharacter]--;
        return partitionValue + AddPositions(value[1..]);
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
            
            new Tuple<string,int>("ABAB",2),
            new Tuple<string,int>("A",1),
            new Tuple<string,int>("AAAB",1),
            new Tuple<string,int>("BAAA",4),
            new Tuple<string,int>("QUESTION",24572),
            new Tuple<string,int>("BOOKKEEPER",10743),
        };

        foreach (var tc in testCases)
        {
            var position = ListPosition(tc.Item1);
            Console.WriteLine($"Word: {tc.Item1}\r\n\tExpected: {tc.Item2}\r\n\tActual: {position}");            
        }
        Console.ReadLine();
    }
}