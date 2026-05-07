using System.Text;
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
namespace DataStructures.Trees;

public class Anagram
{
    
}
class Result
{

    /*
     * Complete the 'sherlockAndAnagrams' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static int sherlockAndAnagrams(string s)
    {
        int slidingWindowStartIndex, slidingWindowEndIndex;
        Dictionary<char, int> countPerChar;
        int count = 0;
        HashSet<string> anagramHash = new HashSet<string>();
        for(int stringLen=1;stringLen<s.Length;stringLen++)
        {
            slidingWindowStartIndex = 0;
            slidingWindowEndIndex = stringLen-1;
            countPerChar = GetCharToCountMap(s, slidingWindowStartIndex, slidingWindowEndIndex);
            while(slidingWindowEndIndex < s.Length-1)
            {
                var currentHash = GetHashForCurrentWindow(countPerChar);
                slidingWindowEndIndex++;
                if(!countPerChar.ContainsKey(s.ElementAt(slidingWindowEndIndex)))
            {
                countPerChar.Add(s.ElementAt(slidingWindowEndIndex), 0);
            }
                countPerChar[s.ElementAt(slidingWindowEndIndex)] = countPerChar[s.ElementAt(slidingWindowEndIndex)]++;
                countPerChar[s.ElementAt(slidingWindowStartIndex)] = countPerChar[s.ElementAt(slidingWindowStartIndex)]--;
                slidingWindowStartIndex++;
                var currentHashAfterMod = GetHashForCurrentWindow(countPerChar);
                if(currentHash == currentHashAfterMod)
                {
                    count++;
                }
            }
        }
        return count;
    }
    
    public static string GetHashForCurrentWindow(Dictionary<char, int> countPerChar)
    {
        StringBuilder s = new StringBuilder();
        foreach(var key in countPerChar.Keys)
        {
            s.Append(key + countPerChar[key]);
        }
        return s.ToString();
    }
    
    public static Dictionary<char, int> GetCharToCountMap(string s, int startIndex, int endIndex)
    {
        Dictionary<char, int> countPerChar = new Dictionary<char, int>();
        while(startIndex<=endIndex)
        {
            if(!countPerChar.ContainsKey(s.ElementAt(startIndex)))
            {
                countPerChar.Add(s.ElementAt(startIndex), 0);
            }
            countPerChar[s.ElementAt(startIndex)]++;
            startIndex++;
        }
        return countPerChar;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = Result.sherlockAndAnagrams(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
