using ProjectManagement_Entity;
using System.Collections.Generic;

namespace ProjectManagement_DA
{
    public interface IUserDA
    {
        IEnumerable<User> GetAllUser();
        User GetUserById(int userID);
        IEnumerable<User> SearchUsers(string searchText);
        int AddUser(User user);
        int UpdateUser(User user);
        int DeleteUser(int userID);
    }
}
