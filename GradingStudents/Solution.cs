using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingStudents
{
    class Solution
    {
        static int[] GradingStudents(int[] grades)
        {
            var res = new int[grades.Length];

            for (int i = 0; i < grades.Length; i++)
            {
                var gradeItem = grades[i];
                if (gradeItem < 38)
                    res[i] = gradeItem;
                else
                {
                    var diffHigherMulOf5 = 5 - (gradeItem % 5);
                    if (diffHigherMulOf5 < 3)
                        res[i] = gradeItem + diffHigherMulOf5;
                    else
                        res[i] = gradeItem;
                }
            }

            return res;
        }

        static void Main(string[] args)
        {
            //TextWriter tw = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            if (n < 1 || n > 60)
                throw new Exception("n not in range");

            int[] grades = new int[n];

            for (int gradesItr = 0; gradesItr < n; gradesItr++)
            {
                int gradesItem = Convert.ToInt32(Console.ReadLine());

                if (gradesItem < 0 || gradesItem > 100)
                    throw new Exception("grade[i] not in range");

                grades[gradesItr] = gradesItem;
            }

            int[] result = GradingStudents(grades);

            //tw.WriteLine(string.Join("\n", result));

            //tw.Flush();
            //tw.Close();
        }
    }
}
