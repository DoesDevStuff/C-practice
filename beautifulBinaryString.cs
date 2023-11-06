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

// does not contain substring "010"
// In ONE STEP, Alice can change a 0 to a 1 or vice versa. 

//Main bit::
// Count and print the minimum number of steps needed 
//to make Alice see the string as beautiful.

class Result
{
    public static int beautifulBinaryString(string s)
    {
        char[] array = s.ToCharArray();
        int count = 0;
        
        for(int i = 2; i < s.Length; i++){
            if( (array[i - 2] == '0') && (array[i - 1] == '1') && (array[i] == '0') ){
                array[i] = '1';
                count ++;
            }
        }
        return count;
    }

}

class Solution
{
    public static void Main(string[] args)
    {

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string b = Console.ReadLine();

        int result = Result.beautifulBinaryString(b);

        Console.WriteLine(result);
    }
}
