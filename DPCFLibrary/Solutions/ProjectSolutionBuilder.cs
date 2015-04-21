using System;
using DynaStudios.DPCFLib.Pattern;

namespace DynaStudios.DPCFLib.Solutions
{
    public class ProjectSolutionBuilder : IBuilder<ProjectSolution>
    {
        protected internal SolutionDescription Description { get; private set; }

        public ProjectSolutionBuilder WithSolutionDescription(SolutionDescription description)
        {
            if (description == null) throw new ArgumentNullException("description");
            if (description.Author == null)
                throw new ArgumentNullException("description", "Author is not allowed to be null");
            if (description.Name == null)
                throw new ArgumentNullException("description", "Name is not allowed to be null");
            if (description.SolutionVersion == null)
                throw new ArgumentNullException("description", "SolutionVersion is not allowed to be null");

            Description = description;

            return this;
        }

        public ProjectSolution Build()
        {
            return new ProjectSolution(this);
        }
    }
}