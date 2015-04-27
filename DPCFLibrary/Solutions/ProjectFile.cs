using System;
using System.Runtime.Serialization;

namespace DynaStudios.DPCFLib.Solutions
{
    [Serializable]
    public class ProjectFile
    {
        [DataMember]
        public string FileIdentifier { get; set; }
        [DataMember]
        public string StructureIdentifier { get; set; }
        [DataMember]
        public string PhysicalFilepath { get; set; }
        [DataMember]
        public FileCompression Compression { get; set; }
        public string CustomCompressionName { get; set; }

        public ProjectFile()
        {
            StructureIdentifier = String.Empty;
            Compression = FileCompression.Uncompressed;
        }
    }
}