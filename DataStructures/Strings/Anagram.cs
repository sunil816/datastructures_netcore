using System.Text;

namespace DataStructures.Strings;

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
        Dictionary<string, int> anagramHash = new Dictionary<string, int>();
        for(int stringLen=1;stringLen<s.Length;stringLen++)
        {
            slidingWindowStartIndex = 0;
            slidingWindowEndIndex = stringLen-1;
            countPerChar = GetCharToCountMap(s, slidingWindowStartIndex, slidingWindowEndIndex);
            
            var currentHash = GetHashForCurrentWindow(countPerChar);
            anagramHash.Add(currentHash, 0);
            while(slidingWindowEndIndex < s.Length-1)
            {
                slidingWindowEndIndex++;
                if(!countPerChar.ContainsKey(s.ElementAt(slidingWindowEndIndex)))
                {
                    countPerChar.Add(s.ElementAt(slidingWindowEndIndex), 0);
                }
                countPerChar[s.ElementAt(slidingWindowEndIndex)] = ++countPerChar[s.ElementAt(slidingWindowEndIndex)];
                countPerChar[s.ElementAt(slidingWindowStartIndex)] = --countPerChar[s.ElementAt(slidingWindowStartIndex)];
                slidingWindowStartIndex++;
                var currentHashAfterMod = GetHashForCurrentWindow(countPerChar);
                if(anagramHash.ContainsKey(currentHashAfterMod))
                {
                    anagramHash[currentHashAfterMod] = ++anagramHash[currentHashAfterMod];
                    count = count + anagramHash[currentHashAfterMod];
                }
                else
                {
                    anagramHash.Add(currentHashAfterMod, 0);
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
            s.Append(key);
            s.Append(countPerChar[key]);
        }
        return s.ToString();
    }
    
    public static Dictionary<char, int> GetCharToCountMap(string s, int startIndex, int endIndex)
    {
        Dictionary<char, int> countPerChar = new Dictionary<char, int>();
        for (char c = 'a'; c <= 'z'; c++)
        {
            countPerChar.Add(c, 0);
        }
        while(startIndex<=endIndex)
        {
            if(!countPerChar.ContainsKey(s.ElementAt(startIndex)))
            {
                countPerChar.Add(s.ElementAt(startIndex), 0);
            }
            countPerChar[s.ElementAt(startIndex)] = ++countPerChar[s.ElementAt(startIndex)];
            startIndex++;
        }
        return countPerChar;
    }

}
