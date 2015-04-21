using System;

namespace DynaStudios.DPCFLib.Solutions
{
    [Serializable]
    public class SolutionDescription
    {
        public string Name { get; set; }
        public string Author { get; set; }     
        public ProjectVersion SolutionVersion { get; set; }
    }
}