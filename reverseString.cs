using System;
using System.Diagnostics;

class Program
{
    static class WordTools
    {
        /// <summary>
        /// Receive string of words and return them in the reversed order.
        /// </summary>
        public static string ReverseWords(string sentence)
        {
            string[] words = sentence.Split(' ');
            Array.Reverse(words);
            return string.Join(" ", words);
        }
    }
    
     /// <summary>
    /// Receive string of words and return them in the reversed order.
    /// </summary>
    static class ManualStringReversal 
    {
        public static string ReverseSentenceManually(string sentence)
        {
            char[] characters = sentence.ToCharArray();
        
            // Reverse the entire sentence
            ReverseArray(characters, 0, characters.Length - 1);
        
            // Reverse each word in the sentence
            int start = 0;
            for (int end = 0; end < characters.Length; end++)
            {
                if (characters[end] == ' ')
                {
                    // Found a space, reverse the word
                    ReverseArray(characters, start, end - 1);
                    start = end + 1; // Move to the next word
                }
            }
        
            // Reverse the last word (or the only word if there's no space)
            ReverseArray(characters, start, characters.Length - 1);
        
            return new string(characters);
        }
        
        private static void ReverseArray(char[] array, int start, int end)
        {
            while (start < end)
            {
                // Swap characters at start and end indices
                char temp = array[start];
                array[start] = array[end];
                array[end] = temp;
        
                // Move indices towards each other
                start++;
                end--;
            }
        }
    }

// reversing individual charachters in array
    public static string ReverseString(string s)
    {
        char[] array = s.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }
        

    public static string ReverseStringDirect(string s)
    {
        char[] array = new char[s.Length];
        int forward = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            array[forward++] = s[i];
        }
        return new string(array);
    }

    static void Main()
    {
        int sum = 0;
        const int _max = 10000000;
        Console.WriteLine(ReverseString("test a string"));
        Console.WriteLine(ReverseStringDirect("test a string"));
        
        Console.WriteLine(ManualStringReversal.ReverseSentenceManually("test a string"));        
        const string s1 = "blue red green";
        string rev1 = WordTools.ReverseWords(s1);
        Console.WriteLine(rev1);
    }
}
