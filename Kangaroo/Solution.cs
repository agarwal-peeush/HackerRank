using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangaroo
{
    class Solution
    {
        static string kangaroo(int x1, int v1, int x2, int v2)
        {
            int d1 = x1;
            int d2 = x2;

            for (int i = 0; i < 10000; i++)
            {
                d1 += v1;
                d2 += v2;

                if (d1 == d2)
                    return "YES";
            }

            return "NO";
        }

        static void Main(String[] args)
        {
            string[] tokens_x1 = Console.ReadLine().Split(' ');
            int x1 = Convert.ToInt32(tokens_x1[0]);
            int v1 = Convert.ToInt32(tokens_x1[1]);
            int x2 = Convert.ToInt32(tokens_x1[2]);
            int v2 = Convert.ToInt32(tokens_x1[3]);

            if( x2 > x1 && v2 > v1)
            {
                Console.WriteLine("NO");
                return;
            }

            if (x1 < 0 || x1 > 10000)
                throw new Exception();

            if (x2 < 0 || x2 > 10000)
                throw new Exception();

            if (v1 < 1 || v1 > 10000)
                throw new Exception();

            if (v2 < 1 || v2 > 10000)
                throw new Exception();

            string result = kangaroo(x1, v1, x2, v2);
            Console.WriteLine(result);
        }
    }
}
