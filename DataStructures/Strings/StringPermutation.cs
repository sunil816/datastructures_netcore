namespace DataStructures.Strings;

public class StringPermutation
{
    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length)
        {
            return false;
        }
        Dictionary<char, int> s1Map = new Dictionary<char, int>();
        Dictionary<char, int> s2Map = new Dictionary<char, int>();
        for (int i = 0; i < s1.Length; i++)
        {
            AddToMap(s1, s1Map, i);
            AddToMap(s2, s2Map, i);
        }
        
        
        if (CheckIfEqual(s1Map, s2Map))
        {
            return true;
        }
        for (int j = s1.Length, i = 0; j < s2.Length; j++, i++)
        {
            --s2Map[s2[i]];
            AddToMap(s2, s2Map, j);
            if (CheckIfEqual(s1Map, s2Map))
            {
                return true;
            }
        }

        return false;

    }

    private static bool CheckIfEqual(Dictionary<char, int> s1Map, Dictionary<char, int> s2Map)
    {

        foreach (var s1MapKey in s1Map.Keys)
        {
            if (!s2Map.ContainsKey(s1MapKey) || s1Map[s1MapKey] != s2Map[s1MapKey])
            {
                return false;
            }
        }

        return true;
    }

    private static void AddToMap(string s1, Dictionary<char, int> s1Map, int i)
    {
        if (!s1Map.ContainsKey(s1[i]))
        {
            s1Map.Add(s1[i], 0);
        }

        s1Map[s1[i]] = s1Map[s1[i]] + 1;
    }
}