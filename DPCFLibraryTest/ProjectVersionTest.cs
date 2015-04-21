using System;
using DynaStudios.DPCFLib.Solutions;
using NUnit.Framework;

namespace DPCFLibraryTest
{
    [TestFixture]
    public class ProjectVersionTest
    {
        [Test]
        public void CreateProjectVersion1()
        {
            var version = new ProjectVersion
            {
                Major = 1,
                Minor = 0,
                Build = 0,
                Revision = 1
            };

            Assert.NotNull(version);
            Assert.IsTrue(version.ToString(1).Equals("1"));
        }

        [Test]
        public void CreateProjectVersion2()
        {
            var version = new ProjectVersion(1, 1);
            Assert.NotNull(version);
            Assert.IsTrue(version.Major == 1);
            Assert.IsTrue(version.Minor == 1);

            Assert.IsTrue(version.ToString().Equals("1.1"));

        }

        [Test]
        public void CreateProjectVersion2Error()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ProjectVersion(-1, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new ProjectVersion(1, -1));
        }

        [Test]
        public void CreateProjectVersion3()
        {
            var version = new ProjectVersion(1, 1, 1);
            Assert.NotNull(version);
            Assert.IsTrue(version.Major == 1);
            Assert.IsTrue(version.Minor == 1);
            Assert.IsTrue(version.Build == 1);

            Assert.IsTrue(version.ToString().Equals("1.1.1"));
        }

        [Test]
        public void CreateProjectVersion3Error()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ProjectVersion(-1, 1, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new ProjectVersion(1, -1, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new ProjectVersion(1, 1, -1));
        }

        [Test]
        public void CreateProjectVersion4()
        {
            var version = new ProjectVersion(1, 1, 1, 1);
            Assert.NotNull(version);
            Assert.IsTrue(version.Major == 1);
            Assert.IsTrue(version.Minor == 1);
            Assert.IsTrue(version.Build == 1);
            Assert.IsTrue(version.Revision == 1);

            Assert.IsTrue(version.ToString().Equals("1.1.1.1"));
        }

        [Test]
        public void CreateProjectVersion4Error()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ProjectVersion(-1, 1, 1, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new ProjectVersion(1, -1, 1, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new ProjectVersion(1, 1, -1, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new ProjectVersion(1, 1, 1, -1));
        }

        [Test]
        public void CreateProjectVersionFromString()
        {
            string nullString = null;
            Assert.Throws<ArgumentNullException>(() => new ProjectVersion(nullString));

            Assert.Throws<ArgumentException>(() => new ProjectVersion("1.1.1.1.1.1.1.1.1"));
            Assert.Throws<ArgumentException>(() => new ProjectVersion("1"));

            var version1 = new ProjectVersion("1.0");
            var version2 = new ProjectVersion("1.1.0");
            var version3 = new ProjectVersion("1.1.1.0");

            Assert.NotNull(version1);
            Assert.NotNull(version2);
            Assert.NotNull(version3);

            Assert.IsTrue(version2 == new ProjectVersion(1, 1, 0));

            Assert.Throws<ArgumentOutOfRangeException>(() => new ProjectVersion("-1.0.0.0"));
            Assert.Throws<ArgumentOutOfRangeException>(() => new ProjectVersion("1.-1.1.1"));
            Assert.Throws<ArgumentOutOfRangeException>(() => new ProjectVersion("1.1.-1.1"));
            Assert.Throws<ArgumentOutOfRangeException>(() => new ProjectVersion("1.1.1.-1"));
        }

        [Test]
        public void ReturnToString()
        {
            var version = new ProjectVersion();
            Assert.IsTrue(version.ToString(0).Equals(String.Empty));
            Assert.Throws<ArgumentException>(() => version.ToString(1));
            Assert.Throws<ArgumentException>(() => version.ToString(2));

            version = new ProjectVersion(1, 1, 1);
            Assert.IsTrue(version.ToString(3).Equals("1.1.1"));

            version = new ProjectVersion(1, 1, 1, 1);
            Assert.IsTrue(version.ToString(4).Equals("1.1.1.1"));

            version = new ProjectVersion(1, 1);
            Assert.Throws<ArgumentException>(() => version.ToString(3));
            version = new ProjectVersion(1, 1, 1);
            Assert.Throws<ArgumentException>(() => version.ToString(4));

            version = new ProjectVersion(1, 1, 1, 1);
            Assert.Throws<ArgumentException>(() => version.ToString(9999));
        }

        [Test]
        public void VersionEquals()
        {
            var version1 = new ProjectVersion(1, 1, 1, 1);
            var version2 = new ProjectVersion(1, 1, 1, 1);

            Assert.IsTrue(version1.Equals(version2));
        }

        [Test]
        public void VersionNotEquals()
        {
            var version1 = new ProjectVersion(1, 1, 1, 1);
            var version2 = new ProjectVersion(1, 1, 0, 1);

            Assert.IsTrue(!version1.Equals(version2));
        }

        [Test]
        public void VersionEqualsWrongObject()
        {
            var version1 = new ProjectVersion(1, 1, 1, 1);
            Assert.IsTrue(!version1.Equals("test"));            
        }

        [Test]
        public void CompareTo()
        {
            var version1 = new ProjectVersion(1, 1, 1, 1);
            var version2 = new ProjectVersion(1, 1, 0, 1);
            var version3 = new ProjectVersion(1, 1, 1, 1);
            var version4 = new ProjectVersion(1, 1, 1, 0);

            var version5 = new ProjectVersion(5, 1, 1, 1);
            var version6 = new ProjectVersion(5, 0, 1, 0);

            Assert.IsTrue(version1 > version2);
            Assert.IsTrue(version2 < version1);
            Assert.IsTrue(version1 == version3);
            Assert.IsTrue(version4 >= version2);
            Assert.IsTrue(version2 <= version4);
            Assert.IsTrue(version1 <= version3);
            Assert.IsTrue(version1 >= version3);
            Assert.IsTrue(version1 < version5);
            Assert.IsTrue(version4 < version3);
            Assert.IsTrue(version5 > version6);

            Assert.IsFalse(version1 < version2);
            Assert.IsFalse(version2 > version1);
            Assert.IsFalse(version4 <= version2);
            Assert.IsFalse(version2 >= version4);
            Assert.IsFalse(version1 >= version5);
            Assert.IsFalse(version4 > version3);
            Assert.IsFalse(version5 < version6);

            Assert.IsTrue(version1 != version2);
            Assert.IsTrue(version1 != null);

            Assert.Throws<ArgumentNullException>(() =>
            {
                if (null < version1) { }
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                if (null > version1) { }
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                if (null <= version1) { }
            });

            Assert.Throws<ArgumentNullException>(() => version1.CompareTo(null));
            Assert.Throws<ArgumentException>(() => version1.CompareTo(string.Empty));


        }

        [Test]
        public void CloneTest()
        {
            var version1 = new ProjectVersion(1, 1, 1, 1);
            var version2 = version1.Clone() as ProjectVersion;
            Assert.IsTrue(version1 == version2);
        }
    }
}
