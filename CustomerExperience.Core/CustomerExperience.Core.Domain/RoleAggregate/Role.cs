﻿
using CustomerExperience.Packages;

namespace CustomerExperience.Core.Domain.RoleAggregate
{
    public class Role: AggregateRootEntity
    {
        #region Members
        public string RoleName { get; private set; }

        private readonly List<User> _users = new();
        public virtual IReadOnlyCollection<User> Users => _users;
        #endregion

        #region Constructors
        private Role() { }

        public Role (string roleName)
        {
            RoleName = roleName;
        }
        #endregion

        #region Public Methods
        public void AddUser (string username, string password, int roleId , int customerId)
        {
            var user = new User (username, password,roleId , customerId);
            _users.Add(user);
        }

        public void RemoveUser (int userId)
        {
            var user = _users?.FirstOrDefault(s => s.Id == userId);
            _users?.Remove(user);
        }

        public void UpdateUserInfo(string username, string password, int roleId, int id, int customerId)
        {
            var user = _users?.FirstOrDefault(s => s.Id == id);
            if (user != null)
            {
                user.UpdateUserInfo(username, password, roleId, id, customerId);
            }
        }
        #endregion
    }
}