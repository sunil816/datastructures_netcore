using Microsoft.VisualBasic.CompilerServices;

namespace DataStructures.Strings;

public class StringGeneral
{
    public string MinWindow(string s, string t) {
        if (t.Length > s.Length)
        {
            return string.Empty;
        }

        Dictionary<char, int> tCountMap = new ();
        Dictionary<char, int> sCountMap = new();
        for (int i = 0; i < t.Length; i++)
        {
            AddToCharCountDictionary(t, i, tCountMap);
            AddToCharCountDictionary(s, i, sCountMap);
        }
        int minLength = Int32.MaxValue;
        int startIndex = -1;
        for (int leftindex = 0, rightIndex = t.Length; leftindex < rightIndex;)
        {
            int currentWindowLength = (rightIndex - leftindex);
            var doesContain = DoesSearchStringContainsInInputSearch(sCountMap, tCountMap);
            if (doesContain)
            {
                if (minLength > currentWindowLength)
                {
                    startIndex = leftindex;
                    minLength = currentWindowLength;
                }

                sCountMap[s[leftindex]]--;
                leftindex++;
            }
            else
            {
                if (rightIndex >= s.Length)
                {
                    break;
                }
                AddToCharCountDictionary(s, rightIndex, sCountMap);
                rightIndex++;
            }
        }

        if (startIndex == -1)
        {
            return string.Empty;
        }

        return s.Substring(startIndex, minLength);
    }

    private bool DoesSearchStringContainsInInputSearch(Dictionary<char, int> input, Dictionary<char, int> search)
    {
        foreach (var searchKey in search.Keys)
        {
            if (!input.ContainsKey(searchKey) || input[searchKey] < search[searchKey])
            {
                return false;
            }
        }

        return true;
    }

    private static void AddToCharCountDictionary(string input, int index, Dictionary<char, int> charCountDictionary)
    {
        var elem = input[index];
        if (!charCountDictionary.ContainsKey(elem))
        {
            charCountDictionary.Add(elem, 0);
        }
        charCountDictionary[elem]++;
    }
}