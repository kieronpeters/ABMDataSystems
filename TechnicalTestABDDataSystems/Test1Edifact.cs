using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TechnicalTestABDDataSystems
{
    /// <summary>
    /// This class is for the Edifact solution it will run the code to show the output as expected and is unit testable
    /// </summary>
    class Test1Edifact
    {
        // This is our Edifact that we will be parsing the results from
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

        /// <summary>
        /// This method is our main test, we use it to call our functions that are more descriptive of what they are doing
        /// </summary>
        public bool test1_Edifact()
        {
            List<string[]> results = new List<string[]>();

            // split on newline, then select lines starting with LOC+ 
            string[] lines = getLines(Edifact);
            // creating the results by using reference to our results list of string array
            bool resultsBuilt = buildResults(ref results, lines);
            // we now pass in the results in order to print them out onto the console
            bool renderedResults = renderResults(ref results);
            // This is the unit tests we run and assert true for they pass and complete successfully
            test1_UnitTests(resultsBuilt, renderedResults);
            Console.WriteLine();
            // This return helps us test this as a single isolated module, it will be the entry point for the full application and has the facility to be unit testable
            return true;
        }

        /// <summary>
        /// This is a test method, and checks the results coming back from building and rendering the results in the console
        /// </summary>
        [Test]
        private void test1_UnitTests(bool resultsBuilt, bool renderedResults)
        {
            // small unit tests to check results were gathered and shown as expected
            Assert.True(resultsBuilt);
            Assert.True(renderedResults);
        }

        /// <summary>
        /// This function builds up results by parsing the edifact and stores them in our list of string array objects to use later
        /// </summary>
        private static bool buildResults(ref List<string[]> results, string[] lines)
        {

            try
            {
                // we are looping through all of the matching lines with LOC+ in them from the edifact and will attempt to build up a list after removing the '+' delimiter
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
                // exception is used in case index of array references on trimmed items does not exist or has no matches, this returns false as failed to complete
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// This method takes our list and foreach result we found, prints out the contents of the array in each item of the list as a formatted string
        /// </summary>
        private static bool renderResults(ref List<string[]> results)
        {
            int i = 1;
            
            foreach (string[] result in results)
            {
                // print out lines of the results found
                try
                {
                    // This loops through all of the string array of results and prints them out to the console so we can see the expected output is correct and as expected
                    Console.WriteLine("Result " + i + ": " + result[0] + " and " + result[1]);
                    i++;

                }
                catch (Exception e)
                {
                    // exception here handles index out of bounds and null objects being called and returns false that this failed to complete
                    Console.WriteLine(e.Message);
                    return false;
                }

            }
            return true;
        }

        /// <summary>
        /// This method takes the initial edifact string and gets out the lines that match the beginning of what we want to
        /// parse through, and discards the rest, returning a string array of matching lines only
        /// </summary>
        private static string[] getLines(string edifact)
        {
            // Here I split off the new lines and remove empty lines, then only return lines starting with LOC+ to parse all relevant lines
            string[] lines = edifact.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return lines.Where(line => line.StartsWith("LOC+")).ToArray();
        }



    }




}
