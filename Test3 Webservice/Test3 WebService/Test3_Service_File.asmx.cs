using NUnit.Framework;
using System;
using System.Web.Services;
using System.Xml;
using System.Xml.Serialization;

namespace Test3_WebService
{
    /// <summary>
    /// This Webservice parses an XML document passed in and returns you a response code if the input is valid or not, codes are represented in the relevant documentation
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        // adding as strings rather than files in the project as this runs on an instance of IIS Express where the files are not held so we need to use string representation of these
        private const string CorrectXML = "<InputDocument><DeclarationList><Declaration Command=\"DEFAULT\" Version=\"5.13\"><DeclarationHeader><Jurisdiction>IE</Jurisdiction><CWProcedure>IMPORT</CWProcedure><DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination><DocumentRef>71Q0019681</DocumentRef><SiteID>DUB</SiteID><AccountCode>G0779837</AccountCode></DeclarationHeader></Declaration></DeclarationList></InputDocument>";
        // this has SPECIAL for the normal expected DEFAULT in the Declaration Command Attribute
        private const string IncorrectDeclarationCommandXML = "<InputDocument><DeclarationList><Declaration Command=\"SPECIAL\" Version=\"5.13\"><DeclarationHeader><Jurisdiction>IE</Jurisdiction><CWProcedure>IMPORT</CWProcedure><DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination><DocumentRef>71Q0019681</DocumentRef><SiteID>DUB</SiteID><AccountCode>G0779837</AccountCode></DeclarationHeader></Declaration></DeclarationList></InputDocument>";
        // This has an incorrect site ID attribute of IND rather than the expected DUB value
        private const string IncorrectSiteIdXML = "<InputDocument><DeclarationList><Declaration Command=\"DEFAULT\" Version=\"5.13\"><DeclarationHeader><Jurisdiction>IE</Jurisdiction><CWProcedure>IMPORT</CWProcedure><DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination><DocumentRef>71Q0019681</DocumentRef><SiteID>IND</SiteID><AccountCode>G0779837</AccountCode></DeclarationHeader></Declaration></DeclarationList></InputDocument>";

        /// <summary>
        /// This WebMethod is also a Test of the Main Service function for parsing and returning the status code of the XMLDocument that was passed in as the payload to it
        /// It covers the case of a success return status code of 0
        /// </summary>
        // The three methods that call the main Service Method with the file to show this main method works as expected
        [WebMethod][Test]
        public int TestParseCorrectXMLStructure()
        {
            // Here we load in the correct document based on our string
            XmlDocument document = new XmlDocument();
            document.LoadXml(CorrectXML);
            // I need to use this as we have no way to pass them in as a payload since using IIS Express is where the files are running from and not the local repository
            return ParseXMLStructre(document);
        }

        /// <summary>
        /// This WebMethod is also a Test of the Main Service function for parsing and returning the status code of the XMLDocument that was passed in as the payload to it
        /// It covers the case of an incorrect declaration command and returns a status code of -1
        /// </summary>
        [WebMethod][Test]
        public int TestParseIncorrectDeclarationCommandXMLStructure()
        {
            // Here we use the incorrect declaration command attribute XML string to get an xml document and call the webservice
            XmlDocument document = new XmlDocument();
            document.LoadXml(IncorrectDeclarationCommandXML);

            return ParseXMLStructre(document);
        }

        /// <summary>
        /// This WebMethod is also a Test of the Main Service function for parsing and returning the status code of the XMLDocument that was passed in as the payload to it
        /// It covers the case of an incorrect Site Id and returns a status code of -2
        /// </summary>
        [WebMethod][Test]
        public int TestParseIncorrectSiteIdXMLStructure()
        {
            // Here we use the incorrect Site Id attribute XML string to get an xml document and call the webservice
            XmlDocument document = new XmlDocument();
            document.LoadXml(IncorrectSiteIdXML);

            return ParseXMLStructre(document);
        }


        /// <summary>
        /// This WebMethod is the primary service, this can be called directly with the XMLDocument payload and will return the status code of the document format if it is correct or incorrect
        /// It can be used with any XML or format sent in, returning -3 for invalid format in case anything is passed in or doesn't match the expected formats we are covering
        /// </summary>
        [WebMethod]
        public int ParseXMLStructre(XmlDocument document)
        {
            // This method could be a WebMethod that would be used on it's own, but I have no way to upload directly to this using the browser the three .xml files you see in the solution explorer
            // I use this by calling it three times, once for each type of response code we expect, when you run these three methods, you get the expected response code from the XML files being wrong or correct
            try
            {
                // we use a serializer to read XML formatting into our generated class file we made from the XML (InputDocument)
                XmlSerializer serializer = new XmlSerializer(typeof(InputDocument));

                // reading the data and checking the two instances with our InputDocument class representation to return error codes in the API
                InputDocument response;
                using (XmlReader reader = new XmlNodeReader(document))
                {
                    response = (InputDocument)serializer.Deserialize(reader);
                }
                // return -1 code for "Invalid Command Specified"
                if (response.DeclarationList.Declaration.Command != "DEFAULT") return -1;
                // return -2 code for "Invalid Site Specified"
                if (response.DeclarationList.Declaration.DeclarationHeader.SiteID != "DUB") return -2;

                return 0;
            } catch (Exception)
            {
                // default returning -3 for any other XML format or incorrect unparsable XML file or simple text entered in the document uploaded by the user of the WebService
                return -3;
            }
            
        }


        /// <summary>
        /// This WebMethod is also a Test - We use this to run all three tests and assert they pass with returing a true on assertions
        /// </summary>
        [Test]
        [WebMethod]
        public bool test3_UnitTests()
        {
            // sanity check Method that this will pass all cases defined as outline
            Assert.AreEqual(0,TestParseCorrectXMLStructure());
            Assert.AreEqual(-1,TestParseIncorrectDeclarationCommandXMLStructure());
            Assert.AreEqual(-2,TestParseIncorrectSiteIdXMLStructure());
            // Wer return the overall result at the end to confirm that all three tests didnt stop the function before it ran to completion
            return true;
        }

    }
}
