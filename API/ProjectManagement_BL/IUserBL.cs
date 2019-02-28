using ProjectManagement_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_BL
{
    public interface IUserBL
    {
        IEnumerable<User> GetAllUser();
        User GetUserById(int userID);
        IEnumerable<User> SearchUsers(string searchText);
        int AddUser(User user);
        int UpdateUser(User user);
        int DeleteUser(int userID);
    }
}
