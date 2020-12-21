using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Kata
{
    private static List<string> _codes = new List<string>
    {
        "F3RF5LF7",
        "FFFR345F2LL"
    };

    private static Dictionary<char, string> _colors = new Dictionary<char, string>
    {
        { 'F',"pink" },
        { 'L',"red" },
        { 'R',"green" }
    };

    public static void Main()
    {
        var input = "";
        while (true)
        {
            Console.WriteLine($"Enter Number, or E for Exit");
            input = Console.ReadLine();
            if (input == "e")
                return;

            foreach (var code in _codes)
            {
                Console.WriteLine($"Code: {code}\r\n\t{Highlight(code)}");
            }
            Console.ReadLine();

        }
    }

    public static string Highlight(string code)
    {
        var sb = new StringBuilder();
        var colors = new Dictionary<char, string>
        {
            { 'F',"pink" },
            { 'L',"red" },
            { 'R',"green" },
            { '(',"" },
            { ')',"" }
        };
        for (int i = 0; i < 10; i++)
        {
            colors.Add(i.ToString()[0], "orange");
        }
        var previousColor = "start";
        code = "(" + code;
        for (int i = 1; i < code.Length; i++)
        {
            var color = colors[code[i]];
            if (color != previousColor && color != "")
            {
                sb.Append($"</span><span style=\"color: {color}\">");
            }
            if (color == ""
                && previousColor != "")
            {
                sb.Append("</span>");
            }
            sb.Append(code[i]);
            if (i == code.Length - 1 && previousColor != "")
            {
                sb.Append("</span>");
            }
            previousColor = color;
        }
        //foreach (var ch in code)
        //{
        //    var color = colors[ch];
        //    if (color == "" && previousColor != "")
        //    {
        //        sb.Append("</span>");
        //    }
        //    if (color != previousColor && color != "")
        //    {
        //        sb.Append($"</span><span style=\"color: {color}\">");
        //    }
        //    sb.Append(ch);
        //    previousColor = color;
        //}
        return sb.ToString(7,sb.Length-7);
    }
}