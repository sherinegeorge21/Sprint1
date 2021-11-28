using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication71.Models
{
    public interface IProjectRepository
    {
        List<Project> GetAllProjects();
        Project GetProjectByID(int id);
        Project AddProject(Project project);
        void DeleteProject(int id);
        bool UpdateProject(Project project);
    }
}
