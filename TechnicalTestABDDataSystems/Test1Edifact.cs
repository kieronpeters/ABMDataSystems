using System;
using System.Collections.Generic;
using System.Linq;

namespace TechnicalTestABDDataSystems
{
    class Test1Edifact
    {

        private static string Edifact = @"UNA:+.? '
UNB+UNOC:3+2021000969+4441963198+180525:1225+3VAL2MJV6EH9IX+KMSV7HMD+CUSDECU-IE++1++1'
UNH+EDIFACT+CUSDEC:D:96B:UN:145050'
BGM+ZEM:::EX+09SEE7JPUV5HC06IC6+Z'
LOC+17+IT044100'
LOC+18+SOL'
LOC+35+SE'
LOC+36+TZ'
LOC+116+SE003033'
DTM+9:20090527:102'
DTM+268:20090626:102'
DTM+182:20090527:102'";

        public bool test1_Edifact()
        {
            List<string[]> results = new List<string[]>();

            // split on newline, then select lines starting with LOC+ 
            string[] lines = getLines(Edifact);

            buildResults(ref results, lines);
            renderResults(ref results);
            Console.WriteLine();
            return true;
        }

        private static bool buildResults(ref List<string[]> results, string[] lines)
        {

            try
            {
                foreach (string line in lines)
                {

                    // remove unclean string with ' at the end
                    string trimmedLine = line.Substring(0, line.IndexOf('\''));

                    // split on the delimiter
                    string[] items = trimmedLine.Split('+').ToArray();

                    // add sections 2 and three to a tuple and add it to our list
                    results.Add(new string[] { items[1], items[2] });
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        private static bool renderResults(ref List<string[]> results)
        {
            int i = 1;

            foreach (string[] result in results)
            {
                // print out lines of the results found
                try
                {
                    Console.WriteLine("Result " + i + ": " + result[0] + " and " + result[1]);
                    i++;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }

            }
            return true;
        }

        private static string[] getLines(string edifact)
        {
            string[] lines = edifact.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return lines.Where(line => line.StartsWith("LOC+")).ToArray();
        }



    }




}
