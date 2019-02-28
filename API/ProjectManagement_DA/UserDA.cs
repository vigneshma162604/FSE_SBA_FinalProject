using ProjectManagement_DA.Model;
using ProjectManagement_Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement_DA
{
    public class UserDA : IUserDA
    {
        /// <summary>
        /// Get All User
        /// </summary>
        /// <returns>IEnuemrable<User></returns>
        public IEnumerable<User> GetAllUser()
        {
            using (ProjectManagementEntities projectMngtEntity = new ProjectManagementEntities())
            {
                var userList = projectMngtEntity.tblUsers.ToList();
                return TransferToUser(userList);
            }
        }

        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="userID">User Id</param>
        /// <returns>User</returns>
        public User GetUserById(int userID)
        {
            using (ProjectManagementEntities projectMngtEntity = new ProjectManagementEntities())
            {
                return TransferToUser(projectMngtEntity.tblUsers.Where(w => w != null && w.UserID == userID).ToList()).FirstOrDefault();
            }
        }


        public IEnumerable<User> SearchUsers(string searchText)
        {
            using (ProjectManagementEntities projectMngtEntity = new ProjectManagementEntities())
            {
                return TransferToUser(projectMngtEntity.tblUsers.Where(w => w != null && w.FirstName.Contains(searchText)).OrderBy(o=> o.EmployeeID).ToList()).FirstOrDefault();
            }
        }

        /// <summary>
        /// Add New User
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Int</returns>
        public int AddUser(User user)
        {
            using (ProjectManagementEntities projectMngtEntity = new ProjectManagementEntities())
            {
                try
                {
                    projectMngtEntity.tblUsers.Add(TransferTotblUser(new List<User>() { user }).FirstOrDefault());
                    return projectMngtEntity.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Updated User
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>int</returns>
        public int UpdateUser(User user)
        {
            using (ProjectManagementEntities projectMngtEntity = new ProjectManagementEntities())
            {
                var existingUser = projectMngtEntity.tblUsers.Find(user.UserID);
                if (existingUser != null)
                {
                    existingUser.FirstName = user.FirstName;
                    existingUser.LastName = user.LastName;
                    existingUser.EmployeeID = user.EmployeeID;
                    existingUser.ProjectID = user.ProjectID;
                    existingUser.TaskID = user.TaskID;

                    return projectMngtEntity.SaveChanges();
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="userID">User ID</param>
        /// <returns>Int</returns>
        public int DeleteUser(int userID)
        {
            using (ProjectManagementEntities projectMngtEntity = new ProjectManagementEntities())
            {
                var existingTask = projectMngtEntity.tblUsers.Where(w => w != null && w.UserID== userID).FirstOrDefault();
                if (existingTask != null)
                {
                    projectMngtEntity.tblUsers.Remove(existingTask);
                    return projectMngtEntity.SaveChanges();
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// Transfer To Model User
        /// </summary>
        /// <param name="lstUser">List<User></param>
        /// <returns>List<tblUser></returns>
        private List<tblUser> TransferTotblUser(List<User> lstUser)
        {
            return lstUser.Where(w => w != null).Select(s => new tblUser()
            {
                UserID = s.UserID,
                EmployeeID = s.EmployeeID,
                FirstName = s.FirstName,
                LastName = s.LastName
            }).ToList();
        }

        /// <summary>
        /// Transfer To Entity User
        /// </summary>
        /// <param name="lstUser">List<tblUser></param>
        /// <returns>List<User></returns>
        private List<User> TransferToUser(List<tblUser> lstUser)
        {
            return lstUser.Where(w => w != null).Select(s => new User()
            {
                UserID = s.UserID,
                EmployeeID = s.EmployeeID,
                FirstName = s.FirstName,
                LastName = s.LastName
            }).ToList();
        }
    }
}
