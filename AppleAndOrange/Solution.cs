using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleAndOrange
{
    class Solution
    {
        /*
     * Complete the countApplesAndOranges function below.
     */
        static void countApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
        {
            int correct_apples = 0;
            int correct_oranges = 0;

            for (int i = 0; i < apples.Length; i++)
            {
                if (apples[i] < -100000 || apples[i] > 100000)
                    throw new Exception();

                var distance_from_a = a + apples[i];
                if (distance_from_a >= s && distance_from_a <= t)
                    correct_apples++;
            }

            for (int i = 0; i < oranges.Length; i++)
            {
                if (oranges[i] < -100000 || oranges[i] > 100000)
                    throw new Exception();

                var distance_from_b = b + oranges[i];
                if (distance_from_b >= s && distance_from_b <= t)
                    correct_oranges++;
            }

            Console.WriteLine(correct_apples);
            Console.WriteLine(correct_oranges);

        }

        static void Main(string[] args)
        {
            string[] st = Console.ReadLine().Split(' ');

            int s = Convert.ToInt32(st[0]);

            int t = Convert.ToInt32(st[1]);

            string[] ab = Console.ReadLine().Split(' ');

            int a = Convert.ToInt32(ab[0]);

            int b = Convert.ToInt32(ab[1]);

            string[] mn = Console.ReadLine().Split(' ');

            int m = Convert.ToInt32(mn[0]);

            int n = Convert.ToInt32(mn[1]);

            int[] apple = Array.ConvertAll(Console.ReadLine().Split(' '), appleTemp => Convert.ToInt32(appleTemp));

            int[] orange = Array.ConvertAll(Console.ReadLine().Split(' '), orangeTemp => Convert.ToInt32(orangeTemp));

            if (a >= s || s >= t || t >= b)
                throw new Exception($"Wrong inputs. Correct input should be : {a} < {s} < {t} < {b}");

            if (a < 1 || b < 1 || s < 1 || t < 1 || m < 1 || n < 1)
                throw new Exception();
            if(a > 100000 || b > 100000 || s > 100000 || t > 100000 || m > 100000 || n > 100000)
                throw new Exception();

            countApplesAndOranges(s, t, a, b, apple, orange);
        }
    }
}
