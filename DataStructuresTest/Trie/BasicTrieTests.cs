using DataStructures.Trie;

namespace DataStructuresTest.Trie;

public class BasicTrieTests
{
    [Test]
    public void InsertAndCountWordsEqualTo()
    {
        var root = new TrieNode('\0', false);
        var trie = new BasicTrie(root);

        trie.Insert("apple");
        trie.Insert("apple");
        trie.Insert("app");

        Assert.That(trie.CountWordsEqualTo("apple"), Is.EqualTo(2));
        Assert.That(trie.CountWordsEqualTo("app"), Is.EqualTo(1));
        Assert.That(trie.CountWordsEqualTo("appl"), Is.EqualTo(0));
    }

    [Test]
    public void CountWordsStartingWithTest()
    {
        var root = new TrieNode('\0', false);
        var trie = new BasicTrie(root);

        trie.Insert("apple");
        trie.Insert("app");
        trie.Insert("application");
        trie.Insert("bat");

        Assert.That(trie.CountWordsStartingWith("app"), Is.EqualTo(3));
        Assert.That(trie.CountWordsStartingWith("apple"), Is.EqualTo(1));
        Assert.That(trie.CountWordsStartingWith("bat"), Is.EqualTo(1));
        Assert.That(trie.CountWordsStartingWith("cat"), Is.EqualTo(0));
    }

    [Test]
    public void EraseTest()
    {
        var root = new TrieNode('\0', false);
        var trie = new BasicTrie(root);

        trie.Insert("apple");
        trie.Insert("app");
        
        Assert.That(trie.CountWordsEqualTo("apple"), Is.EqualTo(1));
        Assert.That(trie.CountWordsEqualTo("app"), Is.EqualTo(1));

        trie.Erase("apple");
        Assert.That(trie.CountWordsEqualTo("apple"), Is.EqualTo(0));
        Assert.That(trie.CountWordsEqualTo("app"), Is.EqualTo(1));
        Assert.That(trie.CountWordsStartingWith("app"), Is.EqualTo(1));
    }
}
