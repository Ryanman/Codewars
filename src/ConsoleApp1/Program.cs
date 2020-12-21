using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Kata
{
    public static void Main()
    {
        var input = "";
        while (true)
        {
            Console.WriteLine($"Enter Number, or E for Exit");
            input = Console.ReadLine();
            if (input == "e")
                return;
            var encrypted = Encrypt("WEAREDISCOVEREDFLEEATONCE", 3);
            Console.WriteLine($"{encrypted}");
            Console.ReadLine();
        }
    }

    /*
     Do-while loop for string
    Use modulus for number of rails to determine increment or decrement for SB index
    if (0 or mod0) 
        toggle = !toggle
    Inc or Dec
     */
    public static string Encrypt(string str, int numberOfRails)
    {
        var rails = new Dictionary<int, StringBuilder>();
        for (int i = 0; i < numberOfRails; i++) 
        {
            rails.Add(i, new StringBuilder());
        }
        var ascend = false;
        var railIndex = 0;
        for (int i = 0; i < str.Length; i++)
        {
            if (railIndex == 0 || railIndex % numberOfRails == (numberOfRails - 1))
                ascend = !ascend;
            rails[railIndex].Append(str[i]);
            railIndex = (ascend == true) ?
                railIndex + 1 : railIndex -1;
        }
        for (int i = 1; i < numberOfRails; i++)
        {
            rails[0].Append(rails[i]);
        }
        return rails[0].ToString();
    }

    //Dis gon be harder
    /*
     * To build Rail 0: str[0] + str[ (numberOfRails -2) + 1 + (numberOfRails -2) ]
     * To build Rail [numRails]: str[numRails-1] + str[(numRails -2) + 1 + (numRails -2)]
     * To build Rail 1: str[1] + str[ ]
     */
    public static string Decrypt(string str, int numRails)
    {
        var rails = new Dictionary<int, StringBuilder>();
        for (int i = 0; i < numRails; i++)
        {
            rails.Add(i, new StringBuilder());
        }
        var ascend = false;
        var railIndex = 0;
        for (int i = str.Length; i < str.Length; i++)
        {
            if (railIndex == 0 || railIndex % numRails == (numRails - 1))
                ascend = !ascend;
            rails[railIndex].Append(str[i]);
            railIndex = (ascend == true) ?
                railIndex + 1 : railIndex - 1;
        }
        for (int i = 1; i < numRails; i++)
        {
            rails[0].Append(rails[i]);
        }
        return rails[0].ToString();
    }
}