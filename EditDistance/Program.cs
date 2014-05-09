using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = "anagram";
            string y = "agnar";
            var dist1 = EditDistanceHelper.EditDistance(x, y, Diff1);
            var dist2 = EditDistanceHelper.EditDistance(x, y, Diff2);

            System.Console.WriteLine(String.Format("The edit distance between {0} and {1} for part (a) is {2}", x, y, dist1));
            System.Console.WriteLine(String.Format("The edit distance between {0} and {1} for part (b) is {2}", x, y, dist2));

            EditDistanceRecursive edr = new EditDistanceRecursive();
            string[] words = { "a", "ab", "abc", "abcd", "abcde", "abcdef", "abcdefg", "abcdefgh", "acbdefghi", "abcdefghij", "abcdefghijk" };

            foreach (string word in words)
            {
                edr.SetWords(word, word);
                edr.NumRecursiveCalls = 0;
                edr.EditDistance(word.Length - 1, word.Length - 1);
                System.Console.WriteLine(String.Format("There were {0} recursive calls for n = {1}", edr.NumRecursiveCalls, word.Length - 1));
            }
            System.Console.ReadLine();


        }

        static double Diff1(char a, char b)
        {
            if (a == b)
                return 0;
            return 1;
        }

        static double Diff2(char a, char b)
        {
            if (a == b)
                return 0;
            return 1 / 2;
        }
    }
}
