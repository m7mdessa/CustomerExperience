﻿using CustomerExperience.Packages;

namespace CustomerExperience.Core.Domain.RoleAggregate
{
    public class User: AuditableEntity
    {
        #region Members
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public int CustomerId { get; private set; }
        public int RoleId { get; private set; }
        public Role ? Role { get; private set; }

        #endregion

        #region Constructors
        private User() { }
        internal User (string username, string password, int roleId, int customerId)
        {
            UserName = username;
            Password = password;
            RoleId = roleId;
            CustomerId = customerId;
        }

        #endregion

        #region Internal Methods
        internal void UpdateUserInfo(string username , string password , int roleId , int id, int customerId)
        {
            UserName = username;
            Password = password;
            RoleId = roleId;
            Id = id;
            CustomerId = customerId;
        }

        #endregion
    }
}
