using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

//  determine whether a string is funny or not. To determine whether a string is funny, create a copy of the string in reverse e.g. 
//Iterating through each string, compare the absolute difference in the ascii values of the characters at positions 0 and 1, 1 and 2 and so on to the end. 
// If the list of absolute differences is the same for both strings, they are funny.

class Result
{
    public static string funnyString(string s)
    {
        string funny = "Funny";
        int stringLength = s.Length;
        
        for(int i = 1; i < stringLength; i++){
            // 
            if( (Math.Abs(s[i] - s[i - 1])) != 
                (Math.Abs(s[ (stringLength -1) - (i)] - s[(stringLength -1) - (i - 1)]))
            ){
                funny = "Not Funny";
                break;
            }
        }
        
        return funny;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int q = Int32.Parse(Console.ReadLine());

        for (int i = 0; i < q; i++)
        {
            string s = Console.ReadLine();

            string result = Result.funnyString(s);
            Console.WriteLine(result);
        }
    }
}
