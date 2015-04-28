using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DynaStudios.DPCFLib.Solutions
{
    [Serializable]
    [DataContract]
    public class ProjectSolution
    {
        [DataMember]
        private SolutionDescription _description;

        [DataMember]
        private List<ProjectFile> _files;

        private List<string> _valueDictionary;
            
        [IgnoreDataMember]
        public SolutionDescription Description
        {
            get { return _description; }
            private set { _description = value; }
        }

        [IgnoreDataMember]
        public List<ProjectFile> Files
        {
            get { return _files; }
            private set { _files = value; }
        }

        [IgnoreDataMember]
        public List<string> ValueDictionary
        {
            get { return _valueDictionary; }
            private set { _valueDictionary = value; }
        }

        protected ProjectSolution()
        {
            
        }

        public ProjectSolution(ProjectSolutionBuilder builder) : this()
        {
            Description = builder.Description;
            Files = builder.Files;
            ValueDictionary = builder.ValueDictionary;
        }

    }
}
