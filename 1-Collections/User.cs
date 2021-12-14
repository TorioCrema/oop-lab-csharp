using System;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;

namespace Collections
{
    public class User : IUser
    {
        public User(string fullName, string username, uint? age)
        {
            Username = username ?? throw new ArgumentNullException();
            FullName = fullName;
            Age = age;
        }

        public uint? Age { get; }

        public string FullName { get; }

        public string Username { get; }

        public bool IsAgeDefined => Age.HasValue;

        // TODO implement missing methods (try to autonomously figure out which are the necessary methods)
        public bool Equals(IUser other)
        {
            return Username == other.Username && FullName == other.FullName && Age == other.Age;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((IUser)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Username, FullName, Age);
        }

        public override string ToString()
        {
            return $"User({Username}" + $", {FullName}" + (IsAgeDefined ? $", {Age}" : "") + ")";
        }
    }
}
