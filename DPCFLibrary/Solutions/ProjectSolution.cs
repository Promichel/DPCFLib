using System;
using System.Xml.Serialization;

namespace DynaStudios.DPCFLib.Solutions
{
    [Serializable]
    [XmlRoot("ProjectSolution")]
    public class ProjectSolution
    {
        public SolutionDescription Description { get; set; }

        public ProjectSolution()
        {
            
        }

        public ProjectSolution(ProjectSolutionBuilder builder)
        {
            Description = builder.Description;
        }
    }
}
