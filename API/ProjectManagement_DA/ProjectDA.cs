using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement_Entity;
using ProjectManagement_DA.Model;
using System.Data.SqlClient;

namespace ProjectManagement_DA
{
    public class ProjectDA : IProjectDA
    {
        /// <summary>
        /// Get All Projects
        /// </summary>
        /// <returns>IEnuemrable<Project></returns>
        public IEnumerable<Project> GetAllProject()
        {
            using (ProjectManagementEntities projectMngtEntity = new ProjectManagementEntities())
            {
                var projectList = projectMngtEntity.tblProjects.ToList();
                return TransfereToProject(projectList);
            }
        }

        /// <summary>
        /// Get Project By Id
        /// </summary>
        /// <param name="projectID">Project Id</param>
        /// <returns>Project</returns>
        public Project GetProjectById(int projectID)
        {
            using (ProjectManagementEntities projectMngtEntity = new ProjectManagementEntities())
            {
                return TransfereToProject(projectMngtEntity.tblProjects.Where(w => w != null && w.ProjectID == projectID).ToList()).FirstOrDefault();
            }
        }

        public IEnumerable<User> SearchUsers(string searchText)
        {
            return _context.Users
                .Where(m => searchText == null || (m.FirstName.Contains(searchText) ||
                            m.LastName.Contains(searchText) || m.EmployeeId.Contains(searchText)))
                .OrderByDescending(m => m.Id)
                .ToList();
        }

        /// <summary>
        /// Add New Project
        /// </summary>
        /// <param name="project">Project</param>
        /// <returns>Boolean</returns>
        public int AddProject(Project project)
        {
            using (ProjectManagementEntities projectMngtEntity = new ProjectManagementEntities())
            {
                try
                {
                    projectMngtEntity.tblProjects.Add(TransfereTotblProject(new List<Project>() { project }).FirstOrDefault());
                    return projectMngtEntity.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Delete Project
        /// </summary>
        /// <param name="projectID">Project Id</param>
        /// <returns>Boolean</returns>
        public int DeleteProject(int projectID)
        {
            using (ProjectManagementEntities projectMngtEntity = new ProjectManagementEntities())
            {
                var existingProject = projectMngtEntity.tblProjects.Where(w => w != null && w.ProjectID == projectID).FirstOrDefault();
                if (existingProject != null)
                {
                    projectMngtEntity.tblProjects.Remove(existingProject);
                    return projectMngtEntity.SaveChanges();
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// Updated Project
        /// </summary>
        /// <param name="project">Project</param>
        /// <returns>Boolean</returns>
        public int UpdateProject(Project project)
        {
            using (ProjectManagementEntities projectMngtEntity = new ProjectManagementEntities())
            {
                var existingProject = projectMngtEntity.tblProjects.Find(project.ProjectID);
                if (existingProject != null)
                {
                    existingProject.ProjectName = project.ProjectName;
                    existingProject.StartDt = project.StartDate;
                    existingProject.EndDt = project.EndDate;
                    existingProject.Priority = project.Priority;

                    //projectMngtEntity.Entry(existingProject).State = System.Data.Entity.EntityState.Modified;
                    return projectMngtEntity.SaveChanges();
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// Transfer To Model Project
        /// </summary>
        /// <param name="lstProject">List<Project></param>
        /// <returns>List<tblProject></returns>
        private List<tblProject> TransfereTotblProject(List<Project> lstProject)
        {
            return lstProject.Where(w => w != null).Select(s => new tblProject()
            {
                ProjectID = s.ProjectID,
                ProjectName = s.ProjectName,
                StartDt = s.StartDate,
                EndDt = s.EndDate,
                Priority = s.Priority
            }).ToList();
        }

        /// <summary>
        /// Transfer To Entity Project
        /// </summary>
        /// <param name="lstProject">List<Project></param>
        /// <returns>List<Project></returns>
        private List<Project> TransfereToProject(List<tblProject> lstProject)
        {
            return lstProject.Where(w => w != null).Select(s => new Project()
            {
                ProjectID = s.ProjectID,
                ProjectName = s.ProjectName,
                StartDate = s.StartDt,
                EndDate = s.EndDt,
                Priority = s.Priority
            }).ToList();
        }
    }
}
