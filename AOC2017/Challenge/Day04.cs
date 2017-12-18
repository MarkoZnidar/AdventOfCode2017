using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC2017.Challenge
{
    public class Day04
    {
        public List<string> ReadInputFromFile(string fileName)
        {
            var allInputLines = File.ReadLines(fileName);
            return allInputLines.ToList();
        }

        public bool isValidPassphraseLine(string passphrase)
        {
            var words = passphrase.Split(" ").ToList();
            var distinctWordsCount = (from word in words select word).Distinct().Count();

            return (words.Count == distinctWordsCount);
        }

        public int CountValidPassphrases(List<string> input)
        {
            var validPassphrasesCount = 0;

            foreach (var line in input)
            {
                if (isValidPassphraseLine(line))
                {
                    validPassphrasesCount += 1;
                }
            }

            return validPassphrasesCount;
        }

        public bool isValidAdvancedPassphraseLine(string passphrase)
        {
            var words = passphrase.Split(" ").ToList();
            for (int i = 0; i < words.Count; i++)
            {
                for (int j = 0; j < words.Count; j++)
                {
                    if (i == j)  //skip comparing to itself
                    {
                        continue;
                    }

                    if (words[i].Length == words[j].Length)
                    {
                        var word1Chars = words[i].ToCharArray();
                        var word2Chars = words[j].ToCharArray();

                        if (String.Concat(word1Chars.OrderBy(c => c)) == String.Concat(word2Chars.OrderBy(c => c)))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public int CountAdvancedValidPassphrases(List<string> input)
        {
            var validPassphrasesCount = 0;

            foreach (var line in input)
            {
                if (isValidAdvancedPassphraseLine(line))
                {
                    validPassphrasesCount += 1;
                }
            }

            return validPassphrasesCount;
        }

        public int CountAdvanedPassphrasePolicy(List<string> input)
        {
            var validPassphrasesCount = 0;

            foreach (var line in input)
            {
                if (isValidPassphraseLine(line) && isValidAdvancedPassphraseLine(line))
                {
                    validPassphrasesCount += 1;
                }
            }

            return validPassphrasesCount;
        }
    }
}