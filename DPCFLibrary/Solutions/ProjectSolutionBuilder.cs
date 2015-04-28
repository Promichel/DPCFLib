using System;
using System.Collections.Generic;
using DynaStudios.DPCFLib.Pattern;

namespace DynaStudios.DPCFLib.Solutions
{
    public class ProjectSolutionBuilder : IBuilder<ProjectSolution>
    {
        protected internal SolutionDescription Description { get; private set; }
        protected internal List<ProjectFile> Files { get; private set; }
        protected internal List<string> ValueDictionary { get; private set; } 

        public ProjectSolutionBuilder()
        {
            Files = new List<ProjectFile>();
        }

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

        public ProjectSolutionBuilder SetValueDictionary(List<string> valueDictionary)
        {
            ValueDictionary = valueDictionary;
            return this;
        }

        public ProjectSolutionBuilder AddToSolution(ProjectFile projectFile)
        {
            if (projectFile == null) throw new ArgumentNullException("projectFile");
            if (string.IsNullOrEmpty(projectFile.PhysicalFilepath))
                throw new ArgumentNullException("projectFile", "Filepath is null or empty");
            if (string.IsNullOrEmpty(projectFile.FileIdentifier))
                throw new ArgumentNullException("projectFile", "File Identifier is null or empty");

            Files.Add(projectFile);

            return this;
        }

        public ProjectSolutionBuilder AddToSolution(ProjectFile[] projectFile)
        {
            if (projectFile == null || projectFile.Length == 0)
                throw new ArgumentNullException("projectFile", "Array is null or empty");
            foreach (var file in projectFile)
            {
                AddToSolution(file);
            }

            return this;
        }

        public ProjectSolution Build()
        {
            if (Description == null)
            {
                throw new NullReferenceException("Description is null");
            }
            if (Files.Count > 0 && ValueDictionary == null)
            {
                throw new NullReferenceException("ValueDictionary is null");
            }

            return new ProjectSolution(this);
        }
    }
}