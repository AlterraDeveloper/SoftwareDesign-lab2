using System.IO;

namespace SoftwareDesign_lab2
{
    internal class FileMapper : Mapper
    {
        public override void Map(string packageFromPath, string packageToPath)
        {
            var filename = GetParameterValueFromXml.Invoke(GetXmlConfig(packageFromPath));
            if (File.Exists(Path.Combine(packageFromPath,filename)))
                File.Copy(Path.Combine(packageFromPath, filename), Path.Combine(packageToPath, filename), true);
        }
    }
}
