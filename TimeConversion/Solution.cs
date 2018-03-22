using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeConversion
{
    class Solution
    {
        /*
        * Complete the timeConversion function below.
        */
        static string timeConversion(string s)
        {
            // AM/PM format 
            // hh:mm:ssAM or hh:mm:ssPM
            // 01<=hh<=12 and 00<=mm,ss<=59
            // Convert to 24 hour format : 12:00:00

            var am_pm = s.Substring(s.Length - 2);
            var timeWithoutAmPm = s.Substring(0, s.Length - 2);
            var hour = Convert.ToInt16(timeWithoutAmPm.Substring(0, 2));
            var timeWithoutHourAmPm = timeWithoutAmPm.Substring(2);
            int newHour = hour;

            string newTimeIn24HrFormat;
            switch (am_pm)
            {
                case "AM":
                    if (hour == 12)
                    {
                        newHour = 0;
                        newTimeIn24HrFormat = $"00{timeWithoutHourAmPm}";
                    }
                    else
                        newTimeIn24HrFormat = timeWithoutAmPm;

                    break;
                case "PM":
                    if (hour < 12)
                        newHour = hour + 12;

                    newTimeIn24HrFormat = $"{newHour}{timeWithoutHourAmPm}";

                    break;
                default:
                    return s;
            }

            return newTimeIn24HrFormat;
        }

        static void Main(string[] args)
        {
            //TextWriter tw = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string s = Console.ReadLine();

            string result = timeConversion(s);

            //tw.WriteLine(result);

            //tw.Flush();
            //tw.Close();
        }
    }
}
