
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

        private const string CorrectXML = "<InputDocument><DeclarationList><Declaration Command=\"DEFAULT\" Version=\"5.13\"><DeclarationHeader><Jurisdiction>IE</Jurisdiction><CWProcedure>IMPORT</CWProcedure><DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination><DocumentRef>71Q0019681</DocumentRef><SiteID>DUB</SiteID><AccountCode>G0779837</AccountCode></DeclarationHeader></Declaration></DeclarationList></InputDocument>";
        private const string IncorrectDeclarationCommandXML = "<InputDocument><DeclarationList><Declaration Command=\"SPECIAL\" Version=\"5.13\"><DeclarationHeader><Jurisdiction>IE</Jurisdiction><CWProcedure>IMPORT</CWProcedure><DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination><DocumentRef>71Q0019681</DocumentRef><SiteID>DUB</SiteID><AccountCode>G0779837</AccountCode></DeclarationHeader></Declaration></DeclarationList></InputDocument>";
        private const string IncorrectSiteIdXML = "<InputDocument><DeclarationList><Declaration Command=\"DEFAULT\" Version=\"5.13\"><DeclarationHeader><Jurisdiction>IE</Jurisdiction><CWProcedure>IMPORT</CWProcedure><DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination><DocumentRef>71Q0019681</DocumentRef><SiteID>IND</SiteID><AccountCode>G0779837</AccountCode></DeclarationHeader></Declaration></DeclarationList></InputDocument>";



        [WebMethod]
        public int TestParseCorrectXMLStructure()
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(CorrectXML);
            
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

            try
            {
                // we use a serializer to read XML formatting into our generated class file we made from the XML (InputDocument)
                XmlSerializer serializer = new XmlSerializer(typeof(InputDocument));

                InputDocument response;
                using (XmlReader reader = new XmlNodeReader(document))
                {
                    response = (InputDocument)serializer.Deserialize(reader);
                }

                if (response.DeclarationList.Declaration.Command != "DEFAULT") return -1;
                if (response.DeclarationList.Declaration.DeclarationHeader.SiteID != "DUB") return -2;

                return 0;
            } catch (Exception)
            {
                return -3;
            }
            
        }

    }
}
