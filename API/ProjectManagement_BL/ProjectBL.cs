using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement_DA;
using ProjectManagement_Entity;
using System.Data.Entity;

namespace ProjectManagement_BL
{
    public class ProjectBL : IProjectBL
    {
        private readonly IProjectDA projectContext;

        public ProjectBL(IProjectDA projectContext)
        {
            this.projectContext = projectContext;
        }

        /// <summary>
        /// Get All Projects
        /// </summary>
        /// <returns>IEnuemrable<Project></returns>
        public IEnumerable<Project> GetAllProject()
        {
            var projects = projectContext.GetAllProject();
            return projects;
        }

        /// <summary>
        /// Get Project By Id
        /// </summary>
        /// <param name="projectID">Project Id</param>
        /// <returns>Project</returns>
        public Project GetProjectById(int projectID)
        {
            return projectContext.GetProjectById(projectID);
        }

        /// <summary>
        /// Add New Project
        /// </summary>
        /// <param name="project">Project</param>
        /// <returns>int</returns>
        public int AddProject(Project project)
        {
            return projectContext.AddProject(project);
        }

        /// <summary>
        /// Delete Project
        /// </summary>
        /// <param name="projectID">Project Id</param>
        /// <returns>int</returns>
        public int DeleteProject(int projectID)
        {
            return projectContext.DeleteProject(projectID);
        }

        /// <summary>
        /// Updated Project
        /// </summary>
        /// <param name="project">Project</param>
        /// <returns>int</returns>
        public int UpdateProject(Project project)
        {
            return projectContext.UpdateProject(project);
        }
    }
}
