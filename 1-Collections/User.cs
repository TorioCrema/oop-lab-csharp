using System;

namespace Collections
{
    public class User : IUser
    {
        public User(string fullName, string username, uint? age)
        {
            FullName = fullName;
            Username = username ?? throw new ArgumentNullException();
            if (age.HasValue)
            {
                Age = age;
            }
        }

        public uint? Age { get; }

        public string FullName { get; }

        public string Username { get; }

        public bool IsAgeDefined => Age.HasValue;

        // TODO implement missing methods (try to autonomously figure out which are the necessary methods)
        public bool Equals(IUser other)
        {
            return Username == other.Username;
        }

        public override int GetHashCode()
        {
            return Username.GetHashCode();
        }

        public override string ToString()
        {
            return $"User({Username}" + $", {FullName}" + (IsAgeDefined ? $", {Age}" : "") + ")";
        }
    }
}
