using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markov_Chain
{
    class Program
    {
        public static List<string> getDataFromFile()
        {
            StreamReader _getText = new StreamReader("Sample.txt", System.Text.Encoding.Default);
            string[] _ttx = _getText.ReadToEnd().Split();
            List<string> _text = new List<string>();

            for (int i = 0; i < _ttx.Length; i++)
                _text.Add(_ttx[i]);

            return _text;
        }

        public static List<(string, string)> MakePairs(List<string> _words)
        {
            List<(string, string)> _add = new List<(string, string)>();
            for (int i = 0; i < _words.Count - 1; i++)
            {
                _add.Add((_words[i], _words[i + 1]));
            }

            return _add;
        }

        public static string GetRandom(List<string> words)
        {
            string _exx = words[new Random().Next(0, words.Count)];
            return _exx;
        }
        static void Main(string[] args)
        {
            List<string> _words = getDataFromFile();
            List<(string, string)> pairs = MakePairs(_words);
            string _firstWord = GetRandom(_words);
            List<string> chain = new List<string>();
            Dictionary<string, List<string>> word_dict = new Dictionary<string, List<string>>();

            foreach(var pair in pairs)
            {
                if (word_dict.ContainsKey(pair.Item1))
                {
                    //translation.Append(pair.Item2);
                    word_dict[pair.Item1].Add(pair.Item2);
                }
                else
                {
                    word_dict[pair.Item1] = new List<string> { pair.Item2 };
                }
            }

            while(_firstWord.ToLower() == _firstWord)
            {
                chain.Add(_firstWord);
                int n_words = 20;
                _firstWord = GetRandom(_words);

                for (int i = 0; i < n_words; i++)
                {
                    chain.Add(GetRandom(word_dict[chain[chain.Count - 1]]));
                    Console.Write($"{chain[i]} ");
                }
            }

            //for (int i = 0; i < 100; i++)

            Console.ReadLine();
        }
    }
}
