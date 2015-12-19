using System;
using System.IO;

namespace RemoveSundayData
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a file name.");
                Environment.Exit(0);
            }

            string fileName = args[0];
            string outputFileName = fileName + "noSunday";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(outputFileName))
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    //Console.Write(s + "\n");

                    int year = 0;
                    int month = 0;
                    int day = 0;
                    try
                    {
                        year = Int32.Parse(s.Substring(0, 4));
                        month = Int32.Parse(s.Substring(5, 2));
                        day = Int32.Parse(s.Substring(8, 2));
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                        Environment.Exit(0);
                    }

                    //Console.Write(year + "/" + month + "/" + day + "\n");
                    DateTime date = new DateTime(year, month, day);
                    //Console.Write(date + "\n");
                    //Console.Write(date.DayOfWeek + "\n");
                    if (date.DayOfWeek != DayOfWeek.Sunday)
                    {
                        file.WriteLine(s);
                    }


                    
                }
            }

        }
    }
}
