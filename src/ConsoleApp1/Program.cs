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

    public static void Main()
    {
        var input = "";
        while (true)
        {
            Console.WriteLine($"Enter Number, or E for Exit");
            input = Console.ReadLine();
            if (input == "e")
                return;

            int[] testCases = new int[] {
                //2,
                //3, 
                4,
                //5,6,7,8,9
                
            };
            for (int i = 0; i < testCases.Length; i++)
            {
                var result = partitionMetrics(testCases[i]);
                Console.WriteLine($"{testCases[i]}:\r\n\t {result.Item1} {result.Item2} {result.Item3}");
                Console.WriteLine($"\r\n\t {string.Join(", ", _productTracker)}");
                _productTracker.Clear();
            }
            Console.ReadLine();
        }
    }

    public static Tuple<int,double,double> partitionMetrics(int n)
    {
        _number = n;
        _productList.Clear();
        _productSum = 0;
        Helper(1, 0, 1);
        //With recurision, track range/average, and median.
        //Range: Min - Max (First and Last)
        //Average: Sum / Num
        //Median: Use LL, keep track of median node as you add them from recursion
        //if Odd Length, don't move median, and use just it
        //if even length, move, and use it and .Next()
        var median = (_productList.Count() % 2 == 0 ?
            (_median.Value + _median.Previous.Value) / 2 :
            (double)_median.Value);
        return new Tuple<int, double, double>(
            _productList.Last.Value - _productList.First.Value
            ,_productSum/_productList.Count()
            ,median);
    }

    private static void Helper(int product, int sum, int depth)
    {
        
            
        for (int i = 1; i < _number; i++)
        {
            if (depth == 1 && i >= 2)
            {
                var bp = 1;
            }
            //product *= i;
            sum += (i);
            if (sum == _number)
            {
                product = product * i;
                var node = new LinkedListNode<int>(product);
                _productSum += product;
                _productTracker.Add(product);
                _productList.AddLast(node);
                if (_productList.Count == 1)
                {
                    _median = node;
                    return;
                }
                if (_productList.Count % 2 == 0)
                {
                    _median = _median.Next;
                }
                return;
            }
            if (sum > _number || (sum == _productList.Last?.Value))
                return;
            if (sum < _number)
            {
                Helper(product * i, sum, depth + 1); //recurse to create longest product chain
                
            }
        }
    }

    public static string FormatDuration(int seconds)
    {
        if (seconds == 0)
            return "now";
        var units = new (string Name, int Seconds, int Num)[]
        {
            ("year",31536000,0),
            ("day",86400,0),
            ("hour",3600,0),
            ("minute",60,0),
            ("second",1,0)
        };
        var numUnits = 0;
        for (int i = 0; i < units.Length; i++)
        {
            units[i].Num = seconds / units[i].Seconds;
            seconds -= units[i].Num * units[i].Seconds;
            numUnits += (units[i].Num > 0 ? 1 : 0);
        }
        var sb = new StringBuilder();
        for (int i = 0; i < units.Length; i++)
        {
            if (units[i].Num == 0)
                continue;
            sb.Append($"{units[i].Num} {units[i].Name}{(units[i].Num == 1 ? "" : "s")}");
            if (numUnits > 1)
                sb.Append($"{(numUnits >= 3 ? ", ":" and ")}");
            numUnits--;
        }
        return sb.ToString();
    }
}