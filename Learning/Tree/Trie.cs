using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Learning.Tree
{
    public class Solution
    {

        public string ReplaceWords(IList<string> dict, string sentence)
        {
            var trie = new Trie();
            foreach (var term in dict) trie.Insert(term);

            var words = sentence.Split(' '); // keep empty strings to retain whitespace.
            for (int i = 0; i < words.Length; i++)
            {
                string root = trie.FindFirstRoot(words[i]);
                if (root != null) words[i] = root;
            }
            return string.Join(" ", words);
        }


        public IList<string> FindWords(char[,] board, string[] words)
        {
            // add words to dictionary
            var d = new Trie();
            foreach (var word in words)
                d.AddWord(word);
            var matches = new HashSet<string>();

            // recursively search for matches through board, matching to trie
            for (int x = 0; x < board.GetLength(0); x++)
                for (int y = 0; y < board.GetLength(1); y++)
                    FindWords(d.Root, board, x, y, matches);

            return matches.ToArray();
        }

        private void FindWords(TrieNode d, char[,] board, int x, int y, HashSet<string> matches)
        {
            // if invalid position, return
            if (x < 0 || x >= board.GetLength(0)
                || y < 0 || y >= board.GetLength(1)
                || board[x, y] == '.') return;

            // current char
            char c = board[x, y];
            var next = d.Children[c - 'a'];
            if (next == null) return;

            // base case - if node is word, add to results but continue searching
            if (next.IsWord) matches.Add(next.Word);

            board[x, y] = '.';

            // look at valid positions, see if there's a matching word
            FindWords(next, board, x + 1, y, matches);
            FindWords(next, board, x - 1, y, matches);
            FindWords(next, board, x, y + 1, matches);
            FindWords(next, board, x, y - 1, matches);

            board[x, y] = c;
        }
    }

    public class Trie
    {
        public readonly TrieNode Root;

        /** Initialize your data structure here. */
        public Trie()
        {
            Root = new TrieNode();
        }

        /** Inserts a word into the trie. */
        public TrieNode Insert(string word)
        {
            var curr = Root;
            foreach (char c in word)
                curr = curr.AddOrGet(c);
            curr.IsWord = true;
            curr.Word = word;
            return curr;
        }

        /** Inserts a word into the trie in reverse order. */
        public TrieNode InsertReverse(string word)
        {
            var curr = Root;
            for (int i = word.Length - 1; i >= 0; i--)
                curr = curr.AddOrGet(word[i]);
            curr.IsWord = true;
            curr.Word = word;
            return curr;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            return SearchNode(word)?.IsWord ?? false;
        }

        /** Adds a word into the data structure. */
        public TrieNode AddWord(string word)
        {
            return Insert(word);
        }

        public string FindFirstRoot(string word)
        {
            var curr = Root;
            for (int i = 0; i < word.Length; i++)
            {
                if (curr.IsWord) return word.Substring(0, i);

                curr = curr.Children[word[i] - 'a'];
                if (curr is null) return null;
            }
            return null;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            return SearchNode(prefix) != null;
        }

        private TrieNode SearchNode(string prefix)
        {
            var curr = Root;
            foreach (char c in prefix)
            {
                curr = curr.Children[c - 'a'];
                if (curr is null) return curr;
            }
            return curr;
        }

    }

    public class TrieNode
    {
        public TrieNode[] Children;
        public bool IsWord;
        public string Word;
        public int val;

        public TrieNode()
        {
            Children = new TrieNode[26];
        }

        public TrieNode AddOrGet(char c)
        {
            if (Children[c - 'a'] is null)
                Children[c - 'a'] = (new TrieNode());
            return Children[c - 'a'];
        }

        public IEnumerable<TrieNode> GetAllWords()
        {
            var words = new List<TrieNode>();
            GetAllWords(words);
            return words;
        }

        private void GetAllWords(List<TrieNode> words)
        {
            foreach (var child in Children)
            {
                if (child != null)
                {
                    if (child.IsWord) words.Add(child);
                    child.GetAllWords(words);
                }
            }
        }

    }

    public class WordDictionary
    {

        Trie _trie;

        /** Initialize your data structure here. */
        public WordDictionary()
        {
            _trie = new Trie();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            _trie.Insert(word);
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            return SearchWildcard(_trie.Root, word, 0);
        }

        private bool SearchWildcard(TrieNode node, string word, int charIndex)
        {
            if (node is null) return false;
            if (charIndex == word.Length) return node.IsWord;

            char c = word[charIndex];
            if (c == '.')
            {
                return node.Children.Any(child => SearchWildcard(child, word, charIndex + 1));
            }
            else
            {
                return SearchWildcard(node.Children[c - 'a'], word, charIndex + 1);
            }
        }

    }

    /**
     * Your Trie object will be instantiated and called as such:
     * Trie obj = new Trie();
     * obj.Insert(word);
     * bool param_2 = obj.Search(word);
     * bool param_3 = obj.StartsWith(prefix);
     */
    public class MapSum
    {
        private TrieNode _root;

        /** Initialize your data structure here. */
        public MapSum()
        {
            _root = new TrieNode();
        }

        public void Insert(string key, int val)
        {
            var curr = _root;
            foreach (char c in key)
                curr = curr.AddOrGet(c);
            curr.IsWord = true;
            curr.val = val;
        }

        public int Sum(string prefix)
        {
            return GetSum(SearchNode(prefix));
        }

        private TrieNode SearchNode(string prefix)
        {
            var curr = _root;
            foreach (char c in prefix)
            {
                curr = curr.Children[c - 'a'];
                if (curr is null) return curr;
            }
            return curr;
        }

        private int GetSum(TrieNode node)
        {
            if (node is null) return 0;
            int sum = node.val;
            foreach (var child in node.Children)
                sum += GetSum(child);
            return sum;
        }

    }

}
