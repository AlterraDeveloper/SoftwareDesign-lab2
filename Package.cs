using System.IO;
using System.IO.Compression;
using System.Xml;

namespace SoftwareDesign_lab2
{
    public class Package
    {
        public ZipArchive PackageZipArchive { get; set; }

        public XmlDocument Configuration { get; set; }

        private Package(string pathToPackage)
        {
            PackageZipArchive = new ZipArchive(new FileStream(pathToPackage, FileMode.Open), ZipArchiveMode.Update);

            Configuration = new XmlDocument();

            foreach (var zipArchiveEntry in PackageZipArchive.Entries)
            {
                if (zipArchiveEntry.FullName.EndsWith("xml"))
                {
                    Configuration.Load(zipArchiveEntry.Open());
                }
            }
        }
       
        public static Package GetPackage(string pathToPackage)
        {
            return new Package(pathToPackage);
        }
    }
}