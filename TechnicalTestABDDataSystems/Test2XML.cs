using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace TechnicalTestABDDataSystems
{
    class Test2XML
    {

        public bool test2_Xml()
        {
            // storage variables and using reference so we can later unit test methods with bool returns
            InputDocument xmlFileObject = new InputDocument();
            List<string[]> targetXMLContents = new List<string[]>();
            // small unit tests on code running
            bool loadedFile = LoadFromXMLFile(ref xmlFileObject);
            bool harvestedData = HarvestTargetXMLElements(ref xmlFileObject, ref targetXMLContents);
            bool printedData = PrintTargetXMLContent(ref targetXMLContents);
            Test2_UnitTests(loadedFile, harvestedData, printedData);
           

            return true;
        }

        private void Test2_UnitTests(bool loadedFile, bool harvestedData, bool printedData)
        {
            Assert.IsTrue(loadedFile);
            Assert.IsTrue(harvestedData);
            Assert.IsTrue(printedData);
        }

        private bool LoadFromXMLFile(ref InputDocument xmlFileObject)
        {
            // we use a serializer to read XML formatting into our generated class file we made from the XML (InputDocument)
            XmlSerializer serializer = new XmlSerializer(typeof(InputDocument));
            // Using a path to get current file in the context of the project directory path
            xmlFileObject = (InputDocument)serializer.Deserialize(new XmlTextReader(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\content.xml"))));
            return true;

        }

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
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        private bool PrintTargetXMLContent(ref List<string[]> targetXMLContents)
        {
            int i = 1;

            foreach (string[] targetXMLContent in targetXMLContents)
            {
                // print out lines of the XML contents that were found
                try
                {
                    Console.WriteLine("Result " + i + ": RefCode of " + targetXMLContent[0] + " contains " + targetXMLContent[1]);
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
    }




}
