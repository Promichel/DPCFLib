using System;
using System.Runtime.Serialization;

namespace DynaStudios.DPCFLib.Solutions
{
    [Serializable]
    public class SolutionDescription
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public ProjectVersion SolutionVersion { get; set; }
    }
}