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

            //Test Cases
            Console.WriteLine(11);
            Console.WriteLine(Decompose(11));
            Console.WriteLine(50);
            Console.WriteLine(Decompose(50));
            Console.WriteLine(4);
            Console.WriteLine(Decompose(4));
            Console.ReadLine();
        }
    }

    public static string Decompose(long n)
    {
        sb = new StringBuilder();
        var result = DecomposeHelper(n - 1, n * n);
        if (result[0] == 'N')
            return "Nothing";
        return result;
    }

    public static string DecomposeHelper (long n, long remainder)
    {
        if (remainder == 1) return "1";
        if (remainder == 0) return $"{n}";        
        if (n == 1 || remainder < 1)
        {
            return "Nothing";
        }
        string result;
        result = DecomposeHelper(n - 1, remainder - (n*n));
        if (result[0] == 'N') //Broken Branch
        {
            result = DecomposeHelper(n - 1, remainder);
            return $"{result}";
        }
        return $"{result} {n}";
    }
}