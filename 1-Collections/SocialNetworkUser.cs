using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {
        private readonly IDictionary<string, ISet<TUser>> _followedDictionary = new Dictionary<string, ISet<TUser>>();
        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age) {}

        public bool AddFollowedUser(string group, TUser user)
        {
            if (_followedDictionary.Keys.Contains(group) && _followedDictionary.TryGetValue(group, out var tempSet))
            {
                if (tempSet.Contains(user))
                {
                    return false;
                }
                tempSet.Add(user);
                return true;
            }

            ISet<TUser> userSet = new HashSet<TUser>();
            userSet.Add(user);
            _followedDictionary.Add(group, userSet);
            return true;
        }

        public IList<TUser> FollowedUsers
        {
            get
            {
                IList<TUser> userList = new List<TUser>();
                foreach (var users in _followedDictionary.Values.Select(s => s.ToList()))
                {
                    foreach (var elem in users)
                    {
                        userList.Add(elem);
                    }
                }

                return userList;
            }
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            throw new NotImplementedException("TODO construct and return a collection containing of all users followed by the current users, in group");
        }
    }
}
