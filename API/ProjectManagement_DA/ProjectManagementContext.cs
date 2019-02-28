using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement_Entity;

namespace ProjectManagement_DA
{
    public class ProjectManagementContext : DbContext, IProjectManagementContext
    {
        public ProjectManagementContext() : base("name=ProjectManagementConnection")
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectManagement_Entity.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
