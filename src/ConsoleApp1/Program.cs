using System;
using System.Collections.Generic;
using System.Globalization;
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

            var N = 4;
            var A = new int[] { 1, 2, 4, 4, 3 };
            var B = new int[] { 2, 3, 1, 3, 1 };

            var s = solutionVertex2(N, A, B);

            Console.WriteLine($"Solution: {s}");
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
