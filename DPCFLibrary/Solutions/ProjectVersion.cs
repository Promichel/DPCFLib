using System;
using System.Globalization;
using System.Xml.Serialization;

namespace DynaStudios.DPCFLib.Solutions
{
    /// <summary>
    ///     Serializable version of the System.Version class.
    /// </summary>
    [Serializable]
    [XmlRoot("Version")]
    public class ProjectVersion : ICloneable, IComparable
    {
        private int _build;
        private int _major;
        private int _minor;
        private int _revision;

        /// <summary>
        ///     Creates a new <see cref="ProjectVersion" /> instance.
        /// </summary>
        public ProjectVersion()
        {
            _build = -1;
            _revision = -1;
            _major = 0;
            _minor = 0;
        }

        /// <summary>
        ///     Creates a new <see cref="ProjectVersion" /> instance.
        /// </summary>
        /// <param name="version">Version.</param>
        public ProjectVersion(string version)
        {
            _build = -1;
            _revision = -1;
            if (version == null)
            {
                throw new ArgumentNullException("version");
            }
            var chArray1 = new[] {'.'};
            var textArray1 = version.Split(chArray1);
            var num1 = textArray1.Length;
            if ((num1 < 2) || (num1 > 4))
            {
                throw new ArgumentException("Arg_VersionString");
            }
            _major = int.Parse(textArray1[0], CultureInfo.InvariantCulture);
            if (_major < 0)
            {
                throw new ArgumentOutOfRangeException("version", "ArgumentOutOfRange_Version");
            }
            _minor = int.Parse(textArray1[1], CultureInfo.InvariantCulture);
            if (_minor < 0)
            {
                throw new ArgumentOutOfRangeException("version", "ArgumentOutOfRange_Version");
            }
            num1 -= 2;
            if (num1 > 0)
            {
                _build = int.Parse(textArray1[2], CultureInfo.InvariantCulture);
                if (_build < 0)
                {
                    throw new ArgumentOutOfRangeException("version", "ArgumentOutOfRange_Version");
                }
                num1--;
                if (num1 > 0)
                {
                    _revision = int.Parse(textArray1[3], CultureInfo.InvariantCulture);
                    if (_revision < 0)
                    {
                        throw new ArgumentOutOfRangeException("version", "ArgumentOutOfRange_Version");
                    }
                }
            }
        }

        /// <summary>
        ///     Creates a new <see cref="ProjectVersion" /> instance.
        /// </summary>
        /// <param name="major">Major.</param>
        /// <param name="minor">Minor.</param>
        public ProjectVersion(int major, int minor)
        {
            _build = -1;
            _revision = -1;
            if (major < 0)
            {
                throw new ArgumentOutOfRangeException("major", "ArgumentOutOfRange_Version");
            }
            if (minor < 0)
            {
                throw new ArgumentOutOfRangeException("minor", "ArgumentOutOfRange_Version");
            }
            _major = major;
            _minor = minor;
            _major = major;
        }

        /// <summary>
        ///     Creates a new <see cref="ProjectVersion" /> instance.
        /// </summary>
        /// <param name="major">Major.</param>
        /// <param name="minor">Minor.</param>
        /// <param name="build">Build.</param>
        public ProjectVersion(int major, int minor, int build)
        {
            _build = -1;
            _revision = -1;
            if (major < 0)
            {
                throw new ArgumentOutOfRangeException("major", "ArgumentOutOfRange_Version");
            }
            if (minor < 0)
            {
                throw new ArgumentOutOfRangeException("minor", "ArgumentOutOfRange_Version");
            }
            if (build < 0)
            {
                throw new ArgumentOutOfRangeException("build", "ArgumentOutOfRange_Version");
            }
            _major = major;
            _minor = minor;
            _build = build;
        }

        /// <summary>
        ///     Creates a new <see cref="ProjectVersion" /> instance.
        /// </summary>
        /// <param name="major">Major.</param>
        /// <param name="minor">Minor.</param>
        /// <param name="build">Build.</param>
        /// <param name="revision">Revision.</param>
        public ProjectVersion(int major, int minor, int build, int revision)
        {
            _build = -1;
            _revision = -1;
            if (major < 0)
            {
                throw new ArgumentOutOfRangeException("major", "ArgumentOutOfRange_Version");
            }
            if (minor < 0)
            {
                throw new ArgumentOutOfRangeException("minor", "ArgumentOutOfRange_Version");
            }
            if (build < 0)
            {
                throw new ArgumentOutOfRangeException("build", "ArgumentOutOfRange_Version");
            }
            if (revision < 0)
            {
                throw new ArgumentOutOfRangeException("revision", "ArgumentOutOfRange_Version");
            }
            _major = major;
            _minor = minor;
            _build = build;
            _revision = revision;
        }

        /// <summary>
        ///     Gets the major.
        /// </summary>
        /// <value></value>
        public int Major
        {
            get { return _major; }
            set { _major = value; }
        }

        /// <summary>
        ///     Gets the minor.
        /// </summary>
        /// <value></value>
        public int Minor
        {
            get { return _minor; }
            set { _minor = value; }
        }

        /// <summary>
        ///     Gets the build.
        /// </summary>
        /// <value></value>
        public int Build
        {
            get { return _build; }
            set { _build = value; }
        }

        /// <summary>
        ///     Gets the revision.
        /// </summary>
        /// <value></value>
        public int Revision
        {
            get { return _revision; }
            set { _revision = value; }
        }

        #region ICloneable Members

        /// <summary>
        ///     Clones this instance.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var version1 = new ProjectVersion
            {
                Major = _major,
                Minor = _minor,
                Build = _build,
                Revision = _revision
            };
            return version1;
        }

        #endregion

        /// <summary>
        ///     Compares to.
        /// </summary>
        /// <param name="version">Obj.</param>
        /// <returns></returns>
        public int CompareTo(object version)
        {
            if (version == null)
            {
                throw new ArgumentNullException("version");
            }
            if (!(version is ProjectVersion))
            {
                throw new ArgumentException("Arg_MustBeVersion");
            }
            var version1 = (ProjectVersion) version;
            if (_major != version1.Major)
            {
                if (_major > version1.Major)
                {
                    return 1;
                }
                return -1;
            }
            if (_minor != version1.Minor)
            {
                if (_minor > version1.Minor)
                {
                    return 1;
                }
                return -1;
            }
            if (_build != version1.Build)
            {
                if (_build > version1.Build)
                {
                    return 1;
                }
                return -1;
            }
            if (_revision == version1.Revision)
            {
                return 0;
            }
            if (_revision > version1.Revision)
            {
                return 1;
            }
            return -1;
        }

        /// <summary>
        /// Operator ==s the specified v1.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        /// <returns></returns>
        public static bool operator ==(ProjectVersion v1, ProjectVersion v2)
        {
            if (ReferenceEquals(v1, null))
            {
                return ReferenceEquals(v2, null);
            }
            return v1.Equals(v2);
        }
        /// <summary>
        /// Operator &gt;s the specified v1.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        /// <returns></returns>
        public static bool operator >(ProjectVersion v1, ProjectVersion v2)
        {
            if (v1 == null)
            {
                throw new ArgumentNullException("v1");
            }
            return (v2 < v1);
        }
        /// <summary>
        /// Operator &gt;=s the specified v1.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        /// <returns></returns>
        public static bool operator >=(ProjectVersion v1, ProjectVersion v2)
        {
            return (v2 <= v1);
        }
        /// <summary>
        /// Operator !=s the specified v1.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        /// <returns></returns>
        public static bool operator !=(ProjectVersion v1, ProjectVersion v2)
        {
            return !v1.Equals(v2);
        }
        /// <summary>
        /// Operator &lt;s the specified v1.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        /// <returns></returns>
        public static bool operator <(ProjectVersion v1, ProjectVersion v2)
        {
            if (v1 == null)
            {
                throw new ArgumentNullException("v1");
            }
            return (v1.CompareTo(v2) < 0);
        }
        /// <summary>
        /// Operator &lt;=s the specified v1.
        /// </summary>
        /// <param name="v1">V1.</param>
        /// <param name="v2">V2.</param>
        /// <returns></returns>
        public static bool operator <=(ProjectVersion v1, ProjectVersion v2)
        {
            if (v1 == null)
            {
                throw new ArgumentNullException("v1");
            }
            return (v1.CompareTo(v2) <= 0);
        }

        /// <summary>
        ///     Equalss the specified obj.
        /// </summary>
        /// <param name="obj">Obj.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is ProjectVersion))
            {
                return false;
            }
            var version1 = (ProjectVersion) obj;
            return ((_major == version1.Major) && (_minor == version1.Minor)) && (_build == version1.Build) &&
                   (_revision == version1.Revision);
        }

        /// <summary>
        ///     Gets the hash code.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var num1 = 0;
            num1 |= ((_major & 15) << 0x1c);
            num1 |= ((_minor & 0xff) << 20);
            num1 |= ((_build & 0xff) << 12);
            return (num1 | _revision & 0xfff);
        }

        /// <summary>
        ///     Toes the string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (_build == -1)
            {
                return ToString(2);
            }
            if (_revision == -1)
            {
                return ToString(3);
            }
            return ToString(4);
        }


        /// <summary>
        ///     Toes the string.
        /// </summary>
        /// <param name="fieldCount">Field count.</param>
        /// <returns></returns>
        public string ToString(int fieldCount)
        {
            object[] objArray1;
            switch (fieldCount)
            {
                case 0:
                {
                    return string.Empty;
                }
                case 1:
                {
                    if (_major == 0)
                    {
                        throw new ArgumentException("Major Version is not set");
                    }
                    return (_major.ToString());
                }
                case 2:
                {
                    if (_major == 0)
                    {
                        throw new ArgumentException("Major Version not set");
                    }
                    return (_major + "." + _minor);

                }
            }
            if (_build == -1)
            {
                throw new ArgumentException(string.Format("ArgumentOutOfRange_Bounds_Lower_Upper {0},{1}", "0", "2"),
                    "fieldCount");
            }
            if (fieldCount == 3)
            {
                objArray1 = new object[] {_major, ".", _minor, ".", _build};
                return string.Concat(objArray1);
            }
            if (_revision == -1)
            {
                throw new ArgumentException(string.Format("ArgumentOutOfRange_Bounds_Lower_Upper {0},{1}", "0", "3"),
                    "fieldCount");
            }
            if (fieldCount == 4)
            {
                objArray1 = new object[] {_major, ".", _minor, ".", _build, ".", _revision};
                return string.Concat(objArray1);
            }
            throw new ArgumentException(string.Format("ArgumentOutOfRange_Bounds_Lower_Upper {0},{1}", "0", "4"),
                "fieldCount");
        }
    }
}