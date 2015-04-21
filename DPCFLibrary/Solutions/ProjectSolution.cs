using System;

namespace DynaStudios.DPCFLib.Solutions
{
    [Serializable]
    public class ProjectSolution
    {
        public SolutionDescription Description { get; set; }

        protected ProjectSolution()
        {
            
        }

        public ProjectSolution(ProjectSolutionBuilder builder)
        {
            Description = builder.Description;
        }
    }
}
