using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Scratchpad
{
    static class Program
    {
        static void Main(string[] args)
        {
            //var a = new string[] { "pim", "pom","sander", "amy", "ann", "michael" };
            //var b = new string[] { "9999999", "777888999" };
            //var p = "88999";

            //var Y = 2014;
            //var A = "April";
            //var B = "May";
            //var W = "Wednesday";

            var A = 1;
            var B = 99999;

            //Console.WriteLine($"Solution: {solutionCarry(123, 456)}");
            //Console.WriteLine($"Solution: {solutionCarry(555, 555)}"); 
            //Console.WriteLine($"Solution: {solutionCarry(900, 11)}"); //0 expected, actual 3
            //Console.WriteLine($"Solution: {solutionCarry(145, 55)}");//2 expected, actual 1
            //Console.WriteLine($"Solution: {solutionCarry(0, 0)}");
            //Console.WriteLine($"Solution: {solutionCarry(1, 99999)}");
            //Console.WriteLine($"Solution: {solutionCarry(999045, 1055)}");
            //Console.WriteLine($"Solution: {solutionCarry(101, 809)}"); //1 expected, actual 2
            //Console.WriteLine($"Solution: {solutionCarry(189, 209)}"); //1 needed, actual 3

            var solution = findWord(new string[] { "U>N", "G>A", "R>Y", "H>U", "N>G", "A>R" }); // HUNGARY
            Console.WriteLine($"{solution}");
            solution = findWord(new string[] { "I>F", "W>I", "S>W", "F>T" }); // SWIFT
            Console.WriteLine($"{solution}");
            solution = findWord(new string[] { "R>T", "A>L", "P>O", "O>R", "G>A", "T>U", "U>G" }); // PORTUGAL
            Console.WriteLine($"{solution}");
            solution = findWord(new string[] { "W>I", "R>L", "T>Z", "Z>E", "S>W", "E>R", "L>A", "A>N", "N>D", "I>T" }); // SWITZERLAND
            Console.WriteLine($"{solution}");
        }

        public static string findWord(string[] A)
        {
            var leftLetters = A.Select(x => x[0]).ToList();
            var rightLetters = A.Select(x => x[2]).ToList();
            var letter = leftLetters
                .Except(rightLetters)
                .SingleOrDefault();

            var sb = new StringBuilder();

            for (int i = 0; i < A.Length; i++)
            {
                sb.Append(letter);
                letter = A.SingleOrDefault(x => x[0] == letter)[2];
            }
            sb.Append(letter);

            return sb.ToString();
        }

        public static int solutionCarry(int A, int B)
        {
            var numCarries = 0;
            var divisor = 1;
            var carry = false;
            while (A > 0 || B > 0)
            {
                var aNum = A % (divisor * 10);
                var bNum = B % (divisor* 10);

                var columnSum = ((aNum + bNum) / divisor) 
                    + (carry ? 1 : 0);

                if (columnSum >= 10)
                {
                    numCarries++;
                    carry = true;
                }
                else
                {
                    carry = false;
                }
                    

                A -= aNum;
                B -= bNum;
                divisor *= 10;
            }
            return numCarries;
        }

        public static bool solutionVertex2(int N, int[] A, int[] B)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var graph = new HashSet<string>();
            //Build graph
            for (int i = 0; i < A.Length; i++)
            {
                //Can we get string interpolation please?
                var forward = A[i].ToString() + "-" + B[i].ToString();
                graph.Add(forward);
                var backward = B[i].ToString() + "-" + A[i].ToString();
                graph.Add(backward);

            }
            //Attempt to traverse
            for (int i = 1; i < N; i++)
            {
                var key = i.ToString() + "-" + (i + 1).ToString();
                if (!graph.Contains(key))
                    return false;
            }
            return true;
        }

        public static bool solutionVertex(int N, int[] A, int[] B)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var graph = new Dictionary<int, List<int>>();
            //Build graph
            for (int i = 0; i < A.Length; i++)
            {
                var startNode = A[i];
                var endNode = B[i];
                if (!graph.ContainsKey(startNode))
                    graph.Add(startNode, new List<int>());
                if (!graph[startNode].Contains(endNode))
                    graph[startNode].Add(endNode);

                if (!graph.ContainsKey(endNode))
                    graph.Add(endNode, new List<int>());
                if (!graph[endNode].Contains(startNode))
                    graph[endNode].Add(startNode);

            }
            //Attempt to traverse
            for (int i = 1; i < N; i++)
            {
                if (!graph.ContainsKey(i))
                    return false;
                if (!graph[i].Contains(i + 1))
                    return false;
            }
            return true;
        }

        public static int solutionVacation(int Y, string A, string B, string W)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            //Departs monday, arrives sunday. Means only whole weeks
            //Get total days in vacation time
            //subtract days before the first monday
            //subtract days after last sunday

            var startMonth = DateTime.ParseExact(A, "MMMM", CultureInfo.CurrentCulture).Month;
            var endMonth = DateTime.ParseExact(B, "MMMM", CultureInfo.CurrentCulture).Month;

            var startDate = new DateTime(Y, startMonth, 1);
            var endDate = new DateTime(Y, endMonth, 1)
                .AddMonths(1).AddDays(-1);//Get end of month
            while (startDate.DayOfWeek != DayOfWeek.Monday)
            {
                startDate = startDate.AddDays(1);
            }
            while (endDate.DayOfWeek != DayOfWeek.Sunday)
            {
                endDate = endDate.AddDays(-1);
            }
            var totalDays = (endDate - startDate).Days + 1;
            return (totalDays) / 7;
        }

        public static string solutionPhoneString(string S)
        {
            var sb = new StringBuilder();
            var numInts = 0;
            for (int i = 0; i < S.Length; i++)
            {

                if (char.IsDigit(S[i]))
                {
                    numInts++;
                    string toAppend = (numInts % 3 == 0 && (i < S.Length - 1)) ?
                            S[i] + "-" :
                            S[i].ToString();
                    sb.Append(toAppend);
                }
            }
            if (sb.Length > 3
                && sb[sb.Length - 2] == '-')
            {
                var digit = sb[sb.Length - 3];
                sb[sb.Length - 3] = '-';
                sb[sb.Length - 2] = digit;

            }
            return sb.ToString();
        }

        public static string solutionPhoneSearch(string[] A, string[] B, string P)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var name = "";
            for (int i = 0; i < B.Length; i++)
            {
                if (!B[i].Contains(P))
                    continue;
                var foundName = A[i];
                if (name == "" || string.Compare(foundName, name) < 0)
                    name = foundName;
            }
            if (name == "")
                name = "NO CONTACT";
            return name;
        }
    }
}
