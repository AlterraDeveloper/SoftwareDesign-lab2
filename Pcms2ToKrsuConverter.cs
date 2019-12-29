using System.Collections.Generic;
using System.Xml;

namespace SoftwareDesign_lab2
{
    public class Pcms2ToKrsuConverter : Converter
    {
        public Pcms2ToKrsuConverter()
        {
            Elements = new List<IConvertible>
            {
                new FileMapper()
                {
                    GetParameterValueFromXml = (xmlDoc) =>
                        {
                            var node = xmlDoc.SelectSingleNode("/problem/judging/script/verifier/binary");
                            return node?.Attributes["file"].InnerText;
                        },
                    PutParameterValueToXml = (paramValue,xmlDoc) =>
                    {
                        var newElement = xmlDoc.CreateElement("checker");
                        newElement.InnerText = paramValue;
                        xmlDoc["testinfo"]?.AppendChild(newElement);
                        return xmlDoc;
                    }
                }
            };
        }
    }
}
