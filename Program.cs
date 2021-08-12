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
        return 1;
    }

    public static void Main()
    {
        Tuple<string, int>[] testCases =
        {
            new Tuple<string,int>("A",1),
            new Tuple<string,int>("ABAB",2),
            new Tuple<string,int>("AAAB",1),
            new Tuple<string,int>("BAAA",4),
            new Tuple<string,int>("QUESTION",24527),
            new Tuple<string,int>("BOOKKEEPER",10743),
        };

        foreach (var tc in testCases)
        {
            var position = ListPosition(tc.Item1);
            Console.WriteLine($"Word: {tc.Item1}\r\n\tExpected: {tc.Item2}\r\n\tActual: {position}");
        }
        
    }
}