using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task = ProjectManagement_Entity;
namespace ProjectManagement_BL
{
    public interface ITaskBL
    {
        IEnumerable<task.Task> GetAllTask();
        task.Task GetTaskById(int taskID);
        int AddTask(task.Task taskObj);
        int UpdateTask(task.Task taskObj);
        int DeleteTask(int taskID);
    }
}
