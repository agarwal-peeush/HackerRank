using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulStrings
{
    class Solution
    {
        static void Main(string[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            var str = Console.ReadLine().Split(' ').First();
            //UnitTest(); return;

            //str = new String('g', 1000000);
            //str = new String('g', 2000);

            if (str.Length < 3 || str.Length > 1000000)
                throw new Exception("String length is not in range");

            Bstrings(str); return;

            Console.WriteLine(BeautifulStringsCount(str));
        }

        private static void UnitTest()
        {
            AssertTrue("abcdefg", 1, 2, "adefg");
            AssertTrue("abcdefg", 0, 2, "bdefg");
            AssertTrue("abcdefg", 2, 5, "abdeg");
            AssertTrue("abcdefg", 1, 5, "acdeg");
            AssertTrue("abcdefg", 1, 6, "acdef");
            AssertTrue("abcdefg", 0, 6, "bcdef");
        }

        private static void AssertTrue(string str, int index1, int index2, string expected)
        {
            var actual = TrimCharacters(str, index1, index2);
            if (actual != expected)
                throw new Exception();
        }

        private static string TrimCharacters(string str, int index1, int index2)
        {
            if (index1 > index2
                || index1 < 0
                || index2 >= str.Length)
                throw new NotImplementedException();

            var startIndex = 0;
            var endIndex = str.Length - 1;

            //if (index1 == 0)
            //    startIndex = 1;

            //if (index2 == str.Length - 1)
            //    endIndex = str.Length - 2;

            return str.Substring(startIndex, (index1 - startIndex))
                + str.Substring(index1 + 1, (index2 - index1 - 1))
                + str.Substring(index2 + 1);
        }

        /* str = {abba}
         * The following strings can be derived by removing 2 characters from S: ab,bb,ba,ab,ba,aa and bb.
         * This gives us our set of unique beautiful strings, B = {ab,ba,aa,bb}. As |B|=4, we print 4.
         */
        static int BeautifulStringsCount(string str)
        {
            var beautifulStrings = new HashSet<string>();

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = str.Length - 1; j > i; j--)
                {
                    var trimmed_str = TrimCharacters(str, i, j);
                    beautifulStrings.Add(trimmed_str);
                }
            }

            return beautifulStrings.Count;
        }

        //static void BeautifulStrings(string str, int index1, int index2, HashSet<string> strings)
        //{
        //    if (index1 >= index2)
        //        return;

        //    var sub = TrimCharacters(str, index1, index2);
        //    strings.Add(sub);
        //}




        static void Bstrings(string str)
        {
            int N = 1000500;
            int[] p = new int[N];
            char[] c = new char[N];
            long[,] f = new long[3, N];

            int idx = 0;
            int n = str.Length;
            for (int i = 0; i < n; ++i)
            {
                if (i + 1 < n && str.ElementAt(i) == str.ElementAt(i + 1))
                    p[1 + idx]++;
                else
                {
                    c[1 + idx] = str.ElementAt(i);
                    p[1 + idx++]++;
                }
            }

            n = idx;
            f[0, 0] = 1L;
            for (int i = 0; i < n; ++i)
            {
                f[0, i + 1] += f[0, i];
                f[1, i + 1] += f[1, i];
                f[2, i + 1] += f[2, i];
                if (p[i + 1] >= 2)
                    f[2, i + 1] += f[0, i];

                if (p[i + 1] >= 1)
                {
                    if (i + 2 <= n && p[i + 1] == 1 && c[i] == c[i + 2])
                        f[2, i + 2] -= 1;

                    f[1, i + 1] += f[0, i];
                    f[2, i + 1] += f[1, i];
                }
            }

            Console.WriteLine(f[2, n]);
        }
    }
}
