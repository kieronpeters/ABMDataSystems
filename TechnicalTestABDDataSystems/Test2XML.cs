using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace TechnicalTestABDDataSystems
{
    /// <summary>
    /// This class is used for the first XML parsing question to find refcodes matching what we want
    /// </summary>
    class Test2XML
    {
        /// <summary>
        /// This method is used as the main entry point of the applcation, will run the code, and is testable with boolean return values
        /// </summary>
        public bool test2_Xml()
        {
            // storage variables and using reference so we can later unit test methods with bool returns
            InputDocument xmlFileObject = new InputDocument();
            List<string[]> targetXMLContents = new List<string[]>();
            // small unit tests on code running, verifies that results are as expected when the functions complete without exceptions
            bool loadedFile = LoadFromXMLFile(ref xmlFileObject);
            bool harvestedData = HarvestTargetXMLElements(ref xmlFileObject, ref targetXMLContents);
            bool printedData = PrintTargetXMLContent(ref targetXMLContents);
            // executing tests here
            Test2_UnitTests(loadedFile, harvestedData, printedData);
            Console.WriteLine();
            // Overall test passes so we return true, this can be executed to call all tests of these methods, unit testables as a full module
            return true;
        }

        /// <summary>
        /// This method verifies that all the three methods called in the main method have returned as valid and passed, can be used in a test suite for validation reasons
        /// </summary>
        [Test]
        private void Test2_UnitTests(bool loadedFile, bool harvestedData, bool printedData)
        {
            //assert all operations are completing successfully
            Assert.IsTrue(loadedFile);
            Assert.IsTrue(harvestedData);
            Assert.IsTrue(printedData);
        }

        /// <summary>
        /// This method takes the file content.xml we have included in this project and fills our object representation of it with the XML files contents
        /// </summary>
        private bool LoadFromXMLFile(ref InputDocument xmlFileObject)
        {
            // we use a serializer to read XML formatting into our generated class file we made from the XML (InputDocument)
            XmlSerializer serializer = new XmlSerializer(typeof(InputDocument));
            // Using a path to get current file in the context of the project directory path
            xmlFileObject = (InputDocument)serializer.Deserialize(new XmlTextReader(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\content.xml"))));
            return true;

        }

        /// <summary>
        /// This method takes our object, and fills in a list of string array that scans for the target elements that match what we want, if it does, we extract the content of the refText value
        /// </summary>
        private bool HarvestTargetXMLElements(ref InputDocument xmlFileObject, ref List<string[]> targetXMLContents)
        {
            try
            {
                // collecting all xml reference tags from the object
                InputDocumentDeclarationListDeclarationDeclarationHeaderReference[] references = xmlFileObject.DeclarationList.Declaration.DeclarationHeader.Reference;

                foreach (InputDocumentDeclarationListDeclarationDeclarationHeaderReference reference in references)
                {
                    // finding target tags with the three refcodes and adding to our list to save targetXMLcontents
                    if (reference.RefCode.Equals("MWB") || reference.RefCode.Equals("TRV") || reference.RefCode.Equals("CAR"))
                    {
                        targetXMLContents.Add(new string[] { reference.RefCode, reference.RefText });
                    }
                }

            } catch (Exception e)
            {
                // this exception is used to handle issues with null objects, null references and comparing something that is non-string
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// This method takes our list of contents we collected and prints them out on the console as formatted strings, one on each line that is in each list of string array
        /// </summary>
        private bool PrintTargetXMLContent(ref List<string[]> targetXMLContents)
        {
            int i = 1;

            foreach (string[] targetXMLContent in targetXMLContents)
            {
                // print out lines of the XML contents that were found
                try
                {
                    // This line builds up the string we output to the console, it is looping each string array and printing out the two contents formatted
                    Console.WriteLine("Result " + i + ": RefCode of " + targetXMLContent[0] + " contains " + targetXMLContent[1]);
                    i++;
                }
                catch (Exception e)
                {
                    // The default exception handler is used for index out of bounds and null object expections
                    Console.WriteLine(e.Message);
                    return false;
                }
            }

            return true;
        }
    }

}
