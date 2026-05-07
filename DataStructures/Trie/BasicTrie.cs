namespace DataStructures.Trie;

public class TrieNode
{
    public char CurrentChar { set; get; }
    private Dictionary<char, TrieNode> Child { set; get; }
    public Boolean EndOfWord { private set; get; }
    
    public long NoOfTimesWordHasAppeared { private set; get; }
    
    public TrieNode(char currentChar, bool endOfWord)
    {
        CurrentChar = currentChar;
        Child = new Dictionary<char, TrieNode>();
        EndOfWord = endOfWord;
        NoOfTimesWordHasAppeared = endOfWord ? 1 : 0;
    }

    public void AddChildren(char childChar, TrieNode trieNode)
    {
        Child.Add(childChar, trieNode);
    }
    
    public void RemoveChildren(char childChar)
    {
        Child.Remove(childChar);
    }

    public bool IsChildPresent(char childChar)
    {
        return Child.ContainsKey(childChar);
    }

    public TrieNode GetChild(char childChar)
    {
        if (!IsChildPresent(childChar))
        {
            throw new Exception($"ChildNode not present for {childChar}");
        }

        return Child[childChar];
    }

    public List<char> GetAllChildChar()
    {
        return Child.Keys.ToList();
    }

    public bool HasChild()
    {
        return Child.Count > 0;
    }

    public void IncrementAppeared()
    {
        NoOfTimesWordHasAppeared++;
        EndOfWord = true;
    }

    public void SetEndNodeToFalse()
    {
        EndOfWord = false;
        NoOfTimesWordHasAppeared = 0;
    }
}
public class BasicTrie
{
    private TrieNode root;

    public BasicTrie(TrieNode root)
    {
        this.root = root;
    }

    public void Insert(string word)
    {
        var currentTrieNode = root;
        for (int startIndex = 0; startIndex < word.Length; startIndex++)
        {
            var currentChar = word[startIndex];
            if (currentTrieNode.IsChildPresent(currentChar))
            {
                currentTrieNode = currentTrieNode.GetChild(currentChar);
                if (startIndex == (word.Length - 1))
                {
                    currentTrieNode.IncrementAppeared();
                }
            }
            else
            {
                var isEndChar = startIndex == (word.Length - 1);
                var childNode = new TrieNode(currentChar, isEndChar);
                currentTrieNode.AddChildren(currentChar, childNode);
                currentTrieNode = childNode;
            }
        }
    }

    public long CountWordsEqualTo(string word)
    {
        long count = 0;
        var currentTrieNode = root;
        var found = true;
        for (int startIndex = 0; startIndex < word.Length; startIndex++)
        {
            var currentChar = word[startIndex];
            if (currentTrieNode.IsChildPresent(currentChar))
            {
                currentTrieNode = currentTrieNode.GetChild(currentChar);
            }
            else
            {
                found = false;
                break;
            }
        }

        if (found)
        {
            count = currentTrieNode.NoOfTimesWordHasAppeared;
        }
        return count;
    }

    public long CountWordsStartingWith(string word)
    {
        long count = 0;
        var currentTrieNode = root;
        var prefixFound = true;
        for (int startIndex = 0; startIndex < word.Length; startIndex++)
        {
            var currentChar = word[startIndex];
            if (currentTrieNode.IsChildPresent(currentChar))
            {
                currentTrieNode = currentTrieNode.GetChild(currentChar);
            }
            else
            {
                prefixFound = false;
                break;
            }
        }

        if (prefixFound)
        {
            count = GetTotalCountForPrefixStartsWith(currentTrieNode);
        }
        return count;
    }

    public void Erase(string word)
    {
        var currentTrieNode = root;
        var found = true;
        Stack<TrieNode> nodes = new Stack<TrieNode>();
        for (int startIndex = 0; startIndex < word.Length; startIndex++)
        {
            nodes.Push(currentTrieNode);
            var currentChar = word[startIndex];
            if (!currentTrieNode.IsChildPresent(currentChar))
            {
                found = false;
                break;
            }
            currentTrieNode = currentTrieNode.GetChild(currentChar);
        }
        if (!found)
        {
            return;
        }

        currentTrieNode.SetEndNodeToFalse();

        var parentNode = currentTrieNode;
        while (nodes.Count > 0 && !currentTrieNode.HasChild() && !currentTrieNode.EndOfWord)
        {
            parentNode = nodes.Pop();
            parentNode.RemoveChildren(currentTrieNode.CurrentChar);
            currentTrieNode = parentNode;
        }
    }

    private long GetTotalCountForPrefixStartsWith(TrieNode node)
    {
        if (node is null)
        {
            return 0;
        }

        long count = node.NoOfTimesWordHasAppeared;
        foreach (var childNodeChar in node.GetAllChildChar())
        {
            count += GetTotalCountForPrefixStartsWith(node.GetChild(childNodeChar));
        }
        return count;
    }
}