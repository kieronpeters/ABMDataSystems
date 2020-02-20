
using NUnit.Framework;
using System;
using System.IO;
using System.Web.Services;
using System.Xml;
using System.Xml.Serialization;

namespace Test3_WebService
{
    /// <summary>
    /// Summary description for WebService1
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
        private const string IncorrectDeclarationCommandXML = "<InputDocument><DeclarationList><Declaration Command=\"SPECIAL\" Version=\"5.13\"><DeclarationHeader><Jurisdiction>IE</Jurisdiction><CWProcedure>IMPORT</CWProcedure><DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination><DocumentRef>71Q0019681</DocumentRef><SiteID>DUB</SiteID><AccountCode>G0779837</AccountCode></DeclarationHeader></Declaration></DeclarationList></InputDocument>";
        private const string IncorrectSiteIdXML = "<InputDocument><DeclarationList><Declaration Command=\"DEFAULT\" Version=\"5.13\"><DeclarationHeader><Jurisdiction>IE</Jurisdiction><CWProcedure>IMPORT</CWProcedure><DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination><DocumentRef>71Q0019681</DocumentRef><SiteID>IND</SiteID><AccountCode>G0779837</AccountCode></DeclarationHeader></Declaration></DeclarationList></InputDocument>";


        // The three methods that call the main Service Method with the file to show this main method works as expected
        [WebMethod]
        public int TestParseCorrectXMLStructure()
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(CorrectXML);
            // I need to use this as we have no way to pass them in as a payload since using IIS Express is where the files are running from and not the local repository
            return ParseXMLStructre(document);
        }

        [WebMethod]
        public int TestParseIncorrectDeclarationCommandXMLStructure()
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(IncorrectDeclarationCommandXML);

            return ParseXMLStructre(document);
        }

        [WebMethod]
        public int TestParseIncorrectSiteIdXMLStructure()
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(IncorrectSiteIdXML);

            return ParseXMLStructre(document);
        }



        private int ParseXMLStructre(XmlDocument document)
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

        [Test]
        [WebMethod]
        public bool test3_UnitTests()
        {
            // sanity check Method that this will pass all cases defined as outline
            Assert.AreEqual(0,TestParseCorrectXMLStructure());
            Assert.AreEqual(-1,TestParseIncorrectDeclarationCommandXMLStructure());
            Assert.AreEqual(-2,TestParseIncorrectSiteIdXMLStructure());
            return true;
        }

    }
}
