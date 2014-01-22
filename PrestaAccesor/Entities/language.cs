using System;
using System.Xml;
using System.Xml.Serialization;

namespace PrestaAccesor.Entities
{
    [Serializable]
    public class language
    {
        [XmlAttribute]
        public int id { get; set; }

        // Value is reserved word from RestSharp for loading the CDATA content from the XML file.
        [XmlIgnore]
        public string Value { get; set; }

        [XmlText]
        public XmlNode[] CDataContent
        {
            get
            {
                var dummy = new XmlDocument();
                return new XmlNode[] { dummy.CreateCDataSection(Value) };
            }
            set
            {
                if (value == null)
                {
                    Value = null;
                    return;
                }

                if (value.Length != 1)
                {
                    throw new InvalidOperationException(
                    String.Format("Invalid array length {0}", value.Length));
                }

                var node0 = value[0];

                if (node0 == null)
                {
                    throw new InvalidOperationException(String.Format("Invalid node type {0}", node0.NodeType));
                }
                Value = node0.Value;

            }
        }
        ////public string link_rewrite { get; set; }
    }
}
