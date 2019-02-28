using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement_Entity;
using ProjectManagement_DA.Model;
using task = ProjectManagement_Entity;

namespace ProjectManagement_DA
{
    public class TaskDA : ITaskDA
    {
        /// <summary>
        /// Get All Projects
        /// </summary>
        /// <returns>IEnuemrable<Project></returns>
        public IEnumerable<task.Task> GetAllTask()
        {
            using (ProjectManagementEntities projectMngtEntity = new ProjectManagementEntities())
            {
                var taskList = projectMngtEntity.tblTasks.ToList();
                return TransfereToTask(taskList);
            }
        }

        /// <summary>
        /// Get Task By Id
        /// </summary>
        /// <param name="taskID">Task Id</param>
        /// <returns>Task</returns>
        public task.Task GetTaskById(int taskID)
        {
            using (ProjectManagementEntities projectMngtEntity = new ProjectManagementEntities())
            {
                return TransfereToTask(projectMngtEntity.tblTasks.Where(w => w != null && w.TaskID == taskID).ToList()).FirstOrDefault();
            }
        }

        /// <summary>
        /// Add New Task
        /// </summary>
        /// <param name="task">Task</param>
        /// <returns>Int</returns>
        public int AddTask(task.Task task)
        {
            using (ProjectManagementEntities projectMngtEntity = new ProjectManagementEntities())
            {
                try
                {
                    projectMngtEntity.tblTasks.Add(TransfereTotblTask(new List<task.Task>() { task }).FirstOrDefault());
                    return projectMngtEntity.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        /// <summary>
        /// Updated Task
        /// </summary>
        /// <param name="task">Project</param>
        /// <returns>int</returns>
        public int UpdateTask(task.Task task)
        {
            using (ProjectManagementEntities projectMngtEntity = new ProjectManagementEntities())
            {
                var existingTask = projectMngtEntity.tblTasks.Find(task.TaskID);
                if (existingTask != null)
                {
                    existingTask.ParentID = task.ParentTaskId;
                    existingTask.ProjectID = task.ProjectId;
                    existingTask.Task = task.TaskDesc;
                    existingTask.StartDt = task.StartDate;
                    existingTask.EndDt = task.EndDate;
                    existingTask.Priority = task.Priority;
                    existingTask.Status = task.Status;

                    return projectMngtEntity.SaveChanges();
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// Delete Task
        /// </summary>
        /// <param name="taskID">Task ID</param>
        /// <returns>Int</returns>
        public int DeleteTask(int taskID)
        {
            using (ProjectManagementEntities projectMngtEntity = new ProjectManagementEntities())
            {
                var existingTask = projectMngtEntity.tblTasks.Where(w => w != null && w.TaskID == taskID).FirstOrDefault();
                if (existingTask != null)
                {
                    projectMngtEntity.tblTasks.Remove(existingTask);
                    return projectMngtEntity.SaveChanges();
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// Transfer To Model Task
        /// </summary>
        /// <param name="lstTask">List<Task></param>
        /// <returns>List<tblProject></returns>
        private List<tblTask> TransfereTotblTask(List<task.Task> lstTask)
        {
            return lstTask.Where(w => w != null).Select(s => new tblTask()
            {
                TaskID = s.TaskID,
                ParentID = s.ParentTaskId,
                ProjectID = s.ProjectId,
                Task = s.TaskDesc,
                StartDt = s.StartDate,
                EndDt = s.EndDate,
                Priority = s.Priority,
                Status = s.Status
            }).ToList();
        }

        /// <summary>
        /// Transfer To Entity Task
        /// </summary>
        /// <param name="lstTask">List<tblTask></param>
        /// <returns>List<Task></returns>
        private List<task.Task> TransfereToTask(List<tblTask> lstTask)
        {
            return lstTask.Where(w => w != null).Select(s => new task.Task()
            {
                TaskID = s.TaskID,
                ParentTaskId = s.ParentID,
                ProjectId = s.ProjectID,
                TaskDesc = s.Task,
                StartDate = s.StartDt,
                EndDate = s.EndDt,
                Priority = s.Priority,
                Status = Convert.ToBoolean(s.Status)

            }).ToList();
        }
    }
}
