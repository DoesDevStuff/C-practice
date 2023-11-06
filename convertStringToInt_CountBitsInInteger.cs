using System;

public class Main
{
    public static void Main(string[] args)
    {
        string str = "abcdaab";
        int num = stringToInteger(str);
        int result = countingBits(num);
        Console.WriteLine(num);
        Console.WriteLine();
        Console.WriteLine (result);
    }
    
    public static int stringToInteger(string s){
        int stringInInt = 0;
        foreach(char c in s){
            stringInInt++;
        }
        return stringInInt;    
    }
    
    public static int countingBits(int num){
        int count = 0;
        if(num <= 0){
            Console.WriteLine("String should not be empty, i.e number should be non zero");
        }
        
        while (num > 0){
            // we're goint to count the 1's
            if(num % 2 != 0){
                count++;
                num /= 2;
            }
        }
        return count;
    }
    
}
