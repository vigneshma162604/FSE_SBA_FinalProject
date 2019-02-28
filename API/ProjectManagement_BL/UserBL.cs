using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement_Entity;
using ProjectManagement_DA;

namespace ProjectManagement_BL
{
    public class UserBL : IUserBL
    {
        private readonly IUserDA userContext;

        public UserBL(IUserDA userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Get All User
        /// </summary>
        /// <returns>IEnuemrable<User></returns>
        public IEnumerable<User> GetAllUser()
        {
            var users = userContext.GetAllUser();
            return users;
        }

        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="userID">User Id</param>
        /// <returns>User</returns>
        public User GetUserById(int userID)
        {
            return userContext.GetUserById(userID);
        }

        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="userID">User Id</param>
        /// <returns>User</returns>
        public IEnumerable<User> GetUserById(string searchText)
        {
            return userContext.SearchUsers(searchText);
        }

        /// <summary>
        /// Add New User
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>int</returns>
        public int AddUser(User user)
        {
            return userContext.AddUser(user);
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="userID">User Id</param>
        /// <returns>int</returns>
        public int DeleteUser(int userID)
        {
            return userContext.DeleteUser(userID);
        }

        /// <summary>
        /// Updated User
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>int</returns>
        public int UpdateUser(User user)
        {
            return userContext.UpdateUser(user);
        }
    }
}
