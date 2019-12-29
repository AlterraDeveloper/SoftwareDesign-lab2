using System;
using System.IO;
using System.Xml;

namespace SoftwareDesign_lab2
{
    public class Mapper : IConvertible
    {
        public Func<XmlDocument, string> GetParameterValueFromXml;

        public Func<string,XmlDocument,XmlDocument> PutParameterValueToXml;

        public virtual void Map(string packageFromPath, string packageToPath)
        {

        }

        public void Convert(string fromPackagePath, string toPackagePath)
        {
            var xmlConfigFrom = GetXmlConfig(fromPackagePath);

            var paramValue = GetParameterValueFromXml.Invoke(xmlConfigFrom);

            var xmlConfigTo = GetXmlConfig(toPackagePath);

            var xmlDoc = PutParameterValueToXml.Invoke(paramValue,xmlConfigTo);

            xmlConfigTo = xmlDoc;
            xmlConfigTo.Save(Path.Combine(Consts.DirectoryToPath,Consts.XmlConfigFilePath));

            Map(fromPackagePath, toPackagePath);
        }

        protected XmlDocument GetXmlConfig(string packagePath)
        {
            var xmlConfig = new XmlDocument();
            var xmlConfigFile = new DirectoryInfo(packagePath).GetFiles("*.xml")[0];
            xmlConfig.Load(xmlConfigFile.FullName);
            return xmlConfig;
        }
    }
}
