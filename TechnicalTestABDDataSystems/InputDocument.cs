namespace TechnicalTestABDDataSystems
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>

    /// <summary>
    /// This class is generated from the provided XML document structure using reflection in order to generate the class object representation of the XML so we can serialize it and use it
    /// </summary>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class InputDocument
    {

        private InputDocumentDeclarationList declarationListField;

        /// <remarks/>
        public InputDocumentDeclarationList DeclarationList
        {
            get
            {
                return this.declarationListField;
            }
            set
            {
                this.declarationListField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class InputDocumentDeclarationList
    {

        private InputDocumentDeclarationListDeclaration declarationField;

        /// <remarks/>
        public InputDocumentDeclarationListDeclaration Declaration
        {
            get
            {
                return this.declarationField;
            }
            set
            {
                this.declarationField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class InputDocumentDeclarationListDeclaration
    {

        private InputDocumentDeclarationListDeclarationDeclarationHeader declarationHeaderField;

        private string commandField;

        private decimal versionField;

        /// <remarks/>
        public InputDocumentDeclarationListDeclarationDeclarationHeader DeclarationHeader
        {
            get
            {
                return this.declarationHeaderField;
            }
            set
            {
                this.declarationHeaderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Command
        {
            get
            {
                return this.commandField;
            }
            set
            {
                this.commandField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class InputDocumentDeclarationListDeclarationDeclarationHeader
    {

        private string jurisdictionField;

        private string cWProcedureField;

        private string declarationDestinationField;

        private string documentRefField;

        private string siteIDField;

        private string accountCodeField;

        private InputDocumentDeclarationListDeclarationDeclarationHeaderReference[] referenceField;

        private InputDocumentDeclarationListDeclarationDeclarationHeaderCountry[] countryField;

        /// <remarks/>
        public string Jurisdiction
        {
            get
            {
                return this.jurisdictionField;
            }
            set
            {
                this.jurisdictionField = value;
            }
        }

        /// <remarks/>
        public string CWProcedure
        {
            get
            {
                return this.cWProcedureField;
            }
            set
            {
                this.cWProcedureField = value;
            }
        }

        /// <remarks/>
        public string DeclarationDestination
        {
            get
            {
                return this.declarationDestinationField;
            }
            set
            {
                this.declarationDestinationField = value;
            }
        }

        /// <remarks/>
        public string DocumentRef
        {
            get
            {
                return this.documentRefField;
            }
            set
            {
                this.documentRefField = value;
            }
        }

        /// <remarks/>
        public string SiteID
        {
            get
            {
                return this.siteIDField;
            }
            set
            {
                this.siteIDField = value;
            }
        }

        /// <remarks/>
        public string AccountCode
        {
            get
            {
                return this.accountCodeField;
            }
            set
            {
                this.accountCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Reference")]
        public InputDocumentDeclarationListDeclarationDeclarationHeaderReference[] Reference
        {
            get
            {
                return this.referenceField;
            }
            set
            {
                this.referenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Country")]
        public InputDocumentDeclarationListDeclarationDeclarationHeaderCountry[] Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class InputDocumentDeclarationListDeclarationDeclarationHeaderReference
    {

        private string refTextField;

        private string refCodeField;

        /// <remarks/>
        public string RefText
        {
            get
            {
                return this.refTextField;
            }
            set
            {
                this.refTextField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RefCode
        {
            get
            {
                return this.refCodeField;
            }
            set
            {
                this.refCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class InputDocumentDeclarationListDeclarationDeclarationHeaderCountry
    {

        private string codeTypeField;

        private string countryTypeField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeType
        {
            get
            {
                return this.codeTypeField;
            }
            set
            {
                this.codeTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CountryType
        {
            get
            {
                return this.countryTypeField;
            }
            set
            {
                this.countryTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


}
