using System;
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
            var result = new ProjectSolutionBuilder().Build();

            Assert.NotNull(result);
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
            Assert.IsTrue(result.Description.Author.Equals("Patrick Trautmann"));
            Assert.IsTrue(result.Description.Name.Equals("Sample Project"));
            Assert.IsTrue(result.Description.SolutionVersion.Equals(new Version(1, 0, 0)));
        }

        [Test]
        public void BuildSimpleSolutionWithDescriptionMissingProperty()
        {
            var description = new SolutionDescription
            {
                Author = "Patrick Trautmann",
                Name = "Test"
            };

            var builder = new ProjectSolutionBuilder();
            Assert.Throws<ArgumentNullException>(() => builder.WithSolutionDescription(description));
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

        #region Sample Creators

        private SolutionDescription GetValidSampleSolutionDescription()
        {
            return new SolutionDescription
            {
                Author = "Patrick Trautmann",
                Name = "Sample Project",
                SolutionVersion = new Version(1, 0, 0)
            };
        }

        #endregion
    }
}