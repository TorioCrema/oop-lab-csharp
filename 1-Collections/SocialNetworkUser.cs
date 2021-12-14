using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            if (!_followedDictionary.Keys.Contains(group))
            {
                _followedDictionary.Add(group, new HashSet<TUser>());
            }

            return _followedDictionary[group].Add(user);
        }

        public IList<TUser> FollowedUsers
        {
            get
            {
                ISet<TUser> userList = new HashSet<TUser>();
                foreach (var users in _followedDictionary.Values)
                {
                    foreach (var elem in users)
                    {
                        userList.Add(elem);
                    }
                }

                return userList.ToList();
            }
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            if (!_followedDictionary.ContainsKey(group))
            {
                return new List<TUser>();
            }
            else
            {
                return new Collection<TUser>(_followedDictionary[group].ToList());
            }
        }
    }
}
