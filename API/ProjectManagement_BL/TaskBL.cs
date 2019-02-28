using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement_Entity;
using ProjectManagement_DA;

namespace ProjectManagement_BL
{
    public class TaskBL : ITaskBL
    {
        private readonly ITaskDA taskContext;

        public TaskBL(ITaskDA taskContext)
        {
            this.taskContext = taskContext;
        }

        /// <summary>
        /// Get All Tasks
        /// </summary>
        /// <returns>IEnuemrable<Task></returns>
        public IEnumerable<ProjectManagement_Entity.Task> GetAllTask()
        {
            var tasks = taskContext.GetAllTask();
            return tasks;
        }

        /// <summary>
        /// Get Task By Id
        /// </summary>
        /// <param name="taskID">Task Id</param>
        /// <returns>Task</returns>
        public ProjectManagement_Entity.Task GetTaskById(int taskID)
        {
            return taskContext.GetTaskById(taskID);
        }

        /// <summary>
        /// Add New Task
        /// </summary>
        /// <param name="task">Task</param>
        /// <returns>int</returns>
        public int AddTask(ProjectManagement_Entity.Task task)
        {
            return taskContext.AddTask(task);
        }

        /// <summary>
        /// Delete Task
        /// </summary>
        /// <param name="taskID">Task Id</param>
        /// <returns>int</returns>
        public int DeleteTask(int taskID)
        {
            return taskContext.DeleteTask(taskID);
        }

        /// <summary>
        /// Updated Task
        /// </summary>
        /// <param name="task">Task</param>
        /// <returns>int</returns>
        public int UpdateTask(ProjectManagement_Entity.Task task)
        {
            return taskContext.UpdateTask(task);
        }

    }
}
