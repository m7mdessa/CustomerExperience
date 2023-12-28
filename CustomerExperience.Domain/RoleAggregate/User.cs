using CustomerExperience.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerExperience.Domain.RoleAggregate
{
    public class User: AuditableEntity
    {
        #region Members
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public int RoleId { get; private set; }
        public Role ? Role { get; private set; }

        #endregion

        #region Constructors
        private User() { }
        internal User (string username, string password, int roleId)
        {
            UserName = username;
            Password = password;
            RoleId = roleId;
        }

        #endregion

        #region Internal Methods
        internal void UpdateUserInfo(string username , string password , int roleId , int id)
        {
            UserName = username;
            Password = password;
            RoleId = roleId;
            Id = id;
        }

        #endregion
    }
}
