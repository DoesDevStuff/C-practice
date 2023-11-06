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

class Result
{
    public static bool organizingContainers(int[,] matrix, int size)
    {
        int[] noOfContainer = new int[size];
        int[] noOfBalls = new int[size];
        
        int ballsInContainer, ballType;
        
        for(int i = 0; i < size; i++){
            ballsInContainer = 0; 
            ballType = 0;

            for(int j = 0; j < size; j++) {
                ballsInContainer += matrix[i, j];
                ballType += matrix[j, i];    
            }

            noOfContainer[i] = ballsInContainer;
            noOfBalls[i] = ballType;
        }
        
        Array.Sort(noOfContainer);
        Array.Sort(noOfBalls);
        
        for(int i = 0; i < size; i++){
            if( noOfContainer[i] != noOfBalls[i] ){
                return false;
            }
        }
        return true;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int q = Int32.Parse(Console.ReadLine());
        int[,] matrix;
        
        for(int i = 0; i < q; i++){
            int n = Int32.Parse(Console.ReadLine());
            matrix = new int[n, n];
            
            for(int j = 0; j < n; j++){
                int[] row = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
                
                for(int k = 0; k < n; k++)
                matrix[j, k] = row[k];
            }
            
            if(Result.organizingContainers(matrix, n) ){
                Console.WriteLine("Possible");
            }
            else{
                Console.WriteLine("Impossible");    
            }
            
        }
    }
}
