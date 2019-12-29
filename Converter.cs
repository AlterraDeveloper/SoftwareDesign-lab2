using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml;

namespace SoftwareDesign_lab2
{
    public abstract class Converter
    {
        protected List<IConvertible> Elements;

        public virtual void Convert(string inputPackagePath, string outputPackagePath)
        {
            Directory.CreateDirectory(Consts.DirectoryFromPath);
            Directory.CreateDirectory(Consts.DirectoryToPath);

            ZipFile.ExtractToDirectory(inputPackagePath,Consts.DirectoryFromPath);

            using (var stream = File.Create(Path.Combine(Consts.DirectoryToPath, Consts.XmlConfigFilePath)))
            {
                var xmlDoc = new XmlDocument();

                xmlDoc.AppendChild(xmlDoc.CreateElement("testinfo"));

                xmlDoc.Save(stream);
            }

            foreach (var mappedElement in Elements)
            {
                mappedElement.Convert(Consts.DirectoryFromPath, Consts.DirectoryToPath);
            }

            try
            {
                ZipFile.CreateFromDirectory(Consts.DirectoryToPath, outputPackagePath);
            }
            catch (IOException)
            {
                Console.WriteLine($"Convertation error : {outputPackagePath} already exists. Try another path...");
            }
            

            Directory.Delete(Consts.DirectoryFromPath,true);
            Directory.Delete(Consts.DirectoryToPath,true);
        }
    }
}
