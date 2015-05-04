using System;
using System.Collections.Generic;
using System.IO;
using DynaStudios.DPCFLib.Solutions;
using NUnit.Framework;

namespace DPCFLibraryTest.Solution
{
    [TestFixture]
    public class SolutionTests
    {
        [Test]
        public void BuildSimpleSolution()
        {
            Assert.Throws<NullReferenceException>(() => new ProjectSolutionBuilder().Build());
        }

        [Test]
        public void BuildSimpleSolutionWithDescription()
        {
            var builder = new ProjectSolutionBuilder();

            var description = GetValidSampleSolutionDescription();

            builder.WithSolutionDescription(description);
            var result = builder.Build();

            Assert.NotNull(result);
            Assert.NotNull(result.Description);
            ValidateDescription(result.Description);
        }

        [Test]
        public void BuildSimpleSolutionWithDescriptionMissingProperty()
        {
            var builder = new ProjectSolutionBuilder();

            //Description is null
            Assert.Throws<ArgumentNullException>(() => builder.WithSolutionDescription(null));
            var description = new SolutionDescription();

            //Author is null
            Assert.Throws<ArgumentNullException>(() => builder.WithSolutionDescription(description));
            description.Author = "Patrick Trautmann";

            //Name is null
            Assert.Throws<ArgumentNullException>(() => builder.WithSolutionDescription(description));
            description.Name = "Testprojekt";

            //Version is null
            Assert.Throws<ArgumentNullException>(() => builder.WithSolutionDescription(description));
        }

        [Test]
        public void AddFile()
        {
            var description = GetValidSampleSolutionDescription();
            var projectFile = new ProjectFile
            {
                FileIdentifier = "Tomato.jpg",
                PhysicalFilepath = "Dummy"
            };

            //Value Dictionary need to be set after you added files
            var valueDictionary = new List<string>();

            var result = new ProjectSolutionBuilder()
                .WithSolutionDescription(description)
                .SetValueDictionary(valueDictionary)
                .AddToSolution(projectFile)
                .Build();

            Assert.NotNull(result);
            Assert.IsTrue(result.Files.Count == 1);
        }

        [Test]
        public void AddFilesWithMissingValueCollection()
        {
            var description = GetValidSampleSolutionDescription();
            var projectFile = new ProjectFile
            {
                FileIdentifier = "Tomato.jpg",
                PhysicalFilepath = "Dummy"
            };

            Assert.Throws<NullReferenceException>(
                () =>
                    new ProjectSolutionBuilder().WithSolutionDescription(description).AddToSolution(projectFile).Build());
        }

        [Test]
        public void AddFileMissingProperties()
        {
            var description = GetValidSampleSolutionDescription();
            var valueDictionary = new List<string>();

            ProjectFile projectFile = null;



            //Object is null
            Assert.Throws<ArgumentNullException>(
                () => new ProjectSolutionBuilder().WithSolutionDescription(description).SetValueDictionary(valueDictionary).AddToSolution(projectFile));

            projectFile = new ProjectFile();
            //Filepath is null or empty
            Assert.Throws<ArgumentNullException>(
                () => new ProjectSolutionBuilder().WithSolutionDescription(description).SetValueDictionary(valueDictionary).AddToSolution(projectFile));

            //File Identifier is null or empty
            projectFile.PhysicalFilepath = "DummyPath";
            Assert.Throws<ArgumentNullException>(
                () => new ProjectSolutionBuilder().WithSolutionDescription(description).SetValueDictionary(valueDictionary).AddToSolution(projectFile));

            //Everything is set
            projectFile.FileIdentifier = "Test";
            var result =
                new ProjectSolutionBuilder().WithSolutionDescription(description).SetValueDictionary(valueDictionary).AddToSolution(projectFile).Build();

            Assert.NotNull(result);
            Assert.IsTrue(result.Files.Count == 1);
        }

        [Test]
        public void AddMultipleFilesByArray()
        {
            var description = GetValidSampleSolutionDescription();
            var valueDictionary = new List<string>();

            ProjectFile[] files = {
                new ProjectFile {FileIdentifier = "Test", PhysicalFilepath = "DummyPath"},
                new ProjectFile {FileIdentifier = "Test2", PhysicalFilepath = "Another Path"},
            };

            var result = new ProjectSolutionBuilder()
                .WithSolutionDescription(description)
                .SetValueDictionary(valueDictionary)
                .AddToSolution(files)
                .Build();

            Assert.NotNull(result);
            Assert.IsTrue(result.Files.Count == 2);
        }

        [Test]
        public void AddMultipleFileByArrayError()
        {
            var description = GetValidSampleSolutionDescription();

            ProjectFile[] err = null;
            Assert.Throws<ArgumentNullException>(
                () => new ProjectSolutionBuilder().WithSolutionDescription(description).AddToSolution(err).Build());

            err = new ProjectFile[0];
            Assert.Throws<ArgumentNullException>(
                () => new ProjectSolutionBuilder().WithSolutionDescription(description).AddToSolution(err).Build());

            ProjectFile[] files = {
                new ProjectFile {FileIdentifier = "Test", PhysicalFilepath = "DummyPath"},
                new ProjectFile {FileIdentifier = "Test2"},
            };

            Assert.Throws<ArgumentNullException>(
                () => new ProjectSolutionBuilder().WithSolutionDescription(description).AddToSolution(files).Build());
        }

        [Test]
        public void BuildSolutionAndSerialize()
        {
            var description = GetValidSampleSolutionDescription();
            var result = new ProjectSolutionBuilder().WithSolutionDescription(description).Build();
            Assert.NotNull(result);

            var ms = ReadableSerializer<ProjectSolution>.Serialize(result);
            Assert.NotNull(ms);
        }

        [Test]
        public void BuildSolutionSerializeAndDeserialize()
        {
            var description = GetValidSampleSolutionDescription();
            var result = new ProjectSolutionBuilder().WithSolutionDescription(description).Build();

            ProjectSolution desO;
            using (var ms = ReadableSerializer<ProjectSolution>.Serialize(result))
            {
                ms.Seek(0, SeekOrigin.Begin);
                desO = ReadableSerializer<ProjectSolution>.Deserialize(ms);
            }
            Assert.NotNull(desO);
            Assert.NotNull(desO.Description);
            ValidateDescription(desO.Description);
        }

        #region Test Utils

        private SolutionDescription GetValidSampleSolutionDescription()
        {
            return new SolutionDescription
            {
                Author = "Patrick Trautmann",
                Name = "Sample Project",
                SolutionVersion = new ProjectVersion(1, 0, 0)
            };
        }

        private void ValidateDescription(SolutionDescription description)
        {
            Assert.IsTrue(description.Author.Equals("Patrick Trautmann"));
            Assert.IsTrue(description.Name.Equals("Sample Project"));
            Assert.IsTrue(description.SolutionVersion.Equals(new ProjectVersion(1, 0, 0)));
        }

        #endregion
    }
}