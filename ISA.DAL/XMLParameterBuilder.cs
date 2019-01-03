using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ISA.DAL
{
    public class XMLParameterBuilder 
    {
        XmlDocument xmlData;

        public string Text
        {
            get
            {
                return xmlData.OuterXml;
            }

        }
        
        public XMLParameterBuilder()
        {
            xmlData = new XmlDocument();
            xmlData.LoadXml("<root><row/></root>");
        }

        public void AddParameter(string name, string value)
        {
            XmlNode objNode;
            XmlAttribute  objAttr;
            if (value != "")
            {
                objNode = xmlData.SelectSingleNode("root/row");
                objAttr = xmlData.CreateAttribute(name);
                objAttr.Value = value;
                objAttr.Attributes.SetNamedItem(objAttr);
            }
        }


    }     
}

   