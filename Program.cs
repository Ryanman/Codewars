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
    private static StringBuilder sb;

    public static void Main()
    {
        var input = "";
        while (true)
        {
            Console.WriteLine($"Enter Number, or E for Exit");
            input = Console.ReadLine();
            if (input == "e")
                return;
            var result = Decompose(Convert.ToInt32(input));
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }

    public static string Decompose(long n)
    {
        sb = new StringBuilder();
        var result = DecomposeHelper(n - 1, n * n);
        if (result.Substring(result.Length - 2, 2) == " 1")
            return "Nothing";
        return result;
    }

    public static string DecomposeHelper (long n, long remainder)
    {
        //if (n == 0) return "1";
        if (remainder == 1) return "1";
        var square = n * n;
        string result;
        if (remainder - square >= 1)
        {
            result = DecomposeHelper(n, remainder - square);
            return $"{result} {n}";
        }   
        else
        {            
            result = DecomposeHelper(n - 1, remainder);
            return $"{result}";
        }        
    }
}