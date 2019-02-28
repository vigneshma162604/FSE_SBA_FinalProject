using ProjectManagement_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_BL
{
    public interface IProjectBL
    {
        IEnumerable<Project> GetAllProject();
        Project GetProjectById(int projectID);
        int AddProject(Project project);
        int UpdateProject(Project project);
        int DeleteProject(int projectID);
    }
}
