using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace TechnicalTestABDDataSystems
{
    class Test2XML
    {

        private static string Xml = @"<InputDocument><DeclarationList><Declaration Command=""DEFAULT"" Version=\""5.13""><DeclarationHeader><Jurisdiction>IE</Jurisdiction><CWProcedure>IMPORT</CWProcedure><DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination><DocumentRef>71Q0019681</DocumentRef><SiteID>DUB</SiteID><AccountCode>G0779837</AccountCode><Reference RefCode = ""MWB"" >< RefText > 586133622 </ RefText ></ Reference >< Reference RefCode=""KEY""><RefText>DUB16049</RefText></Reference><Reference RefCode = ""CAR"" >< RefText > 71Q0019681</RefText></Reference><Reference RefCode = ""COM"" >< RefText > 71Q0019681</RefText></Reference><Reference RefCode = ""SRC"" >< RefText > ECUS </ RefText ></ Reference >< Reference RefCode=""TRV""><RefText>1</RefText></Reference><Reference RefCode = ""CAS"" >< RefText > 586133622 </ RefText ></ Reference >< Reference RefCode=""HWB""><RefText>586133622</RefText></Reference><Reference RefCode = ""UCR"" >< RefText > 586133622 </ RefText ></ Reference >< Country CodeType=""NUM"" CountryType=""Destination"" > IE</Country><Country CodeType = ""NUM"" CountryType=""Dispatch"">CN</Country></DeclarationHeader></DeclarationList></InputDocument>";

        public bool test2_Xml()
        {
            LoadFromXMLString(Xml);
            Console.WriteLine();
            return true;
        }

        private bool LoadFromXMLString(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(InputDocument));
            StringReader rdr = new StringReader(Xml);
            InputDocument resultingMessage = (InputDocument)serializer.Deserialize(rdr);
            resultingMessage.ToString();
            return true;

        }
    }




}
