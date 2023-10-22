using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Kata
{
    private static int _remainder;    
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
            Console.WriteLine(decompose(11));
            Console.WriteLine(50);
            Console.WriteLine(decompose(50));
            Console.WriteLine(4);
            Console.WriteLine(decompose(4));
            Console.ReadLine();
        }
    }

    public static string decompose(long n)
    {
        var remainder = n * n;
        var nums = new Stack<long>();
        for (long i = n - 1; i > 0; i--)
        {            
            var square = i * i;

            if (remainder - square >= 0)
            {
                remainder -= square;
                if (remainder == 0)
                {
                    nums.Push(i);
                    break;//Success
                }
                if (i == 1) // Bad Branch
                {
                    var num = nums.Pop();
                    remainder += (num * num) + 1;
                    i = num;
                    continue;
                }
                nums.Push(i);
                continue;
            }
            if (remainder - square < 0)        
            {                
                continue;                
            }
            return null;//We'll go to 0 next and so we're done
        }

        var sb = new StringBuilder();
        foreach (var item in nums)
        {
            sb.Append($"{item} ");
        }
        return sb.ToString();
    }

    //public string decompose(long n)
    //{
    //    var result = decomposehelper(n - 1, n * n);
    //    return result;
    //}

    //public string decomposehelper(long n, long remainder)
    //{
    //    if (remainder == 1) return "1";
    //    if (remainder == 0) return $"{n}";
    //    if (n == 1 || remainder < 1)
    //        return null;
    //    if (decomposehelper(n - 1, remainder - (n * n)) == null) //Broken Branch
    //    {
    //        return decomposehelper(n - 1, remainder);
    //    }
    //    return $"{decomposehelper(n - 1, remainder - (n * n))} {n}";
    //}
}