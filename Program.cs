using System;
using System.Collections.Generic;
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

            //var sw = new Stopwatch();

            //sw.Start();
            //for (int i = 0; i < 100000; i++)
            //{
            //    decompose(i);
            //}
            //sw.Stop();
            //Console.WriteLine($"Total Time: {sw.ElapsedMilliseconds}");
            //sw.Restart();
            //for (int i = 0; i < 100000; i++)
            //{
            //    decomposeNoRungs(i);
            //}
            //sw.Stop();
            //Console.WriteLine($"Total Time (no rungs): {sw.ElapsedMilliseconds}");
        }
    }

    public static string decompose(long n)
    {
        var remainder = n * n;
        /*I would like to be formally on the record as saying we could use the StringBuilder 
         * as our stack and that anyone who does that is a horrible person*/
        var nums = new Stack<long>();
        for (long i = n - 1; i > 0; i--)
        {            
            var square = i * i;
            remainder -= square;
            if (i == 1 && nums.Count > 0 && remainder != 0) //Bad Branch
            {
                var num = nums.Pop();
                remainder += (num * num) + 1;
                i = num;
                continue;
            }
            nums.Push(i);
            if (remainder == 0)
                break;
            //NextRung - without this operation, performance on high numbers is significantly degraded
            long nextRung = ((long)Math.Floor(Math.Sqrt(remainder)) + 1);
            i = Math.Min(i, nextRung);
            continue;
        }

        var sb = new StringBuilder();
        foreach (var item in nums)
            sb.Append($"{item} ");
        sb.Remove(sb.Length - 1, 1);
        return (remainder == 0) ? 
            sb.ToString() 
            : null;
    }

    public static string decomposeNoRungs(long n)
    {
        var remainder = n * n;
        /*I would like to be formally on the record as saying we could use the StringBuilder 
         * as our stack and that anyone who does that is a horrible person*/
        var nums = new Stack<long>();
        for (long i = n - 1; i > 0; i--)
        {
            var square = i * i;

            if (remainder - square < 0)
                continue;

            remainder -= square;
            if (remainder == 0)
            {
                nums.Push(i);
                break;//Success
            }
            if (i == 1 && nums.Count > 0) //Bad Branch
            {
                var num = nums.Pop();
                remainder += (num * num) + 1;
                i = num;
                continue;
            }
            nums.Push(i);
            continue;
        }

        var sb = new StringBuilder();
        foreach (var item in nums)
        {
            sb.Append($"{item} ");
        }
        return (remainder == 0) ?
            sb.ToString().Trim()
            : null;
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