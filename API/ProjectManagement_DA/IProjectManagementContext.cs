using ProjectManagement_Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_DA
{
    public interface IProjectManagementContext
    {
        DbSet<Project> Projects { get; set; }
        DbSet<ProjectManagement_Entity.Task> Tasks { get; set; }
        DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
