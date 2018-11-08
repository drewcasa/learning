using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.Tree
{
    public class Palindrome
    {
        /// <summary>
        /// Given a list of unique words, find all pairs of 
        /// distinct indices (i, j) in the given list, so that 
        /// the concatenation of the two words, 
        /// i.e. words[i] + words[j] is a palindrome.
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<IList<int>> PalindromePairs(string[] words)
        {
            // put all words in trie O(n*m) // num words * avg length
            var t = new Trie();
            for (int i = 0; i < words.Length; i++)
            {
                var n = t.InsertReverse(words[i]);
                n.val = i; // need to keep index because that's our return value
            }

            // results will be list of pairs of indices
            var results = new List<int[]>();

            // for each word, follow path through trie.
            // if we match any, we have candidates for palindromes
            for (int i = 0; i < words.Length; i++)
            {
                TrieNode curr = t.Root;
                if (IsValidMatch(results, curr, words, i))
                    results.Add(new int[] { i, curr.val });

                foreach (char c in words[i])
                {
                    curr = curr.Children[c - 'a'];

                    if (curr is null) break;

                    if (IsValidMatch(results, curr, words, i))
                        results.Add(new int[] { i, curr.val });
                }

                // if there are still children words under our node,
                // they are candidates as well
                if (curr != null)
                    foreach (var remaining in curr.GetAllWords())
                        if (IsPalindrome(words[i], remaining.Word, words[i].Length))
                            results.Add(new int[] { i, remaining.val });
            }

            return results.ToArray();
        }

        private bool IsValidMatch(List<int[]> match, TrieNode node, string[] words, int wordIndex)
        {
            return (node.IsWord  // if node is a word
                && node.val != wordIndex //  not the current word
                && IsPalindrome(words[wordIndex], node.Word, node.Word.Length)); // palindrome
        }

        private bool IsPalindrome(string prefix, string suffix, int matchedLength)
        {
            return IsPalindrome(prefix + suffix, matchedLength);
        }

        public bool IsPalindrome(string word, int matchedLength = 0)
        {
            int len = word.Length;
            for (int i = matchedLength, j = len - (1 + matchedLength); i < len / 2; i++, j--)
                if (word[i] != word[j]) return false;
            return true;
        }

    }
}
