using System;
using System.Collections.Generic;
using System.Text;

public static class Kata
{
    private static List<string> _codes = new List<string>
    {
        "F3RF5LF7",
        "FFFR345F2LL",
        "FFF(R3)45F2LL"
        ,"022L("
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
            { 'F',"pink" },{ 'L',"red" },{ 'R',"green" },
            { '(',"" },{ ')',"" }
        };
        for (int i = 0; i < 10; i++)
        {
            colors.Add((char)(i + 48)
                , "orange");
        }
        var previousColor = "";
        for (int i = 0; i < code.Length; i++)
        {
            var color = colors[code[i]];
            if (color != previousColor)
            {
                if (previousColor != "")
                {
                    sb.Append("</span>");
                }
                if (color != "")
                {
                    sb.Append($"<span style=\"color: {color}\">");
                }
            }
            sb.Append(code[i]);
            if (i == code.Length - 1 && color != "")
            {
                sb.Append("</span>");
            }
            previousColor = color;
        }
        return sb.ToString();
    }

    public static bool NoStyle(this string str)
    {
        return str == "";
    }
}