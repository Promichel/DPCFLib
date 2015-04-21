using System;

namespace DynaStudios.DPCFLib.Solutions
{
    [Serializable]
    public class SolutionDescription
    {
        public string Name { get; set; }
        public Version SolutionVersion { get; set; }
        public string Author { get; set; }
    }
}