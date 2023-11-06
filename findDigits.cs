using System;
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

class Result
{
    /*
     * Complete the 'findDigits' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER n as parameter.
     */

    public static int findDigits(int n)
    {
        int[] divisors = getDivisors(n);
        int count = 0;

        for (int i = 0; i < divisors.Length; i++)
        {
            if ((divisors[i] != 0) && (n % divisors[i] == 0))
            {
                count++;
            }
        }
        return count;
    }

    public static int[] getDivisors(long num)
    {
        int digits = (int)(Math.Log10(num) + 1);
        int[] arr = new int[digits];

        for (int i = 0; i < digits; i++)
        {
            arr[i] = (int)(num % 10);
            num /= 10;
        }
        return arr;
    }
}

class Solution
{
    static void Main(string[] args)
    {
        int t = Int32.Parse(Console.ReadLine());

        for (int i = 0; i < t; i++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            int result = Result.findDigits(n);

            Console.WriteLine(result);
        }
    }
}
