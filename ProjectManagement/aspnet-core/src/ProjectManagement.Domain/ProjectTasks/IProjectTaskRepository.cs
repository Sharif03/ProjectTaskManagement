using ProjectManagement.ProjectTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ProjectManagemente.ProjectTasks
{
    public interface IProjectTaskRepository : IRepository<ProjectTask, Guid>
    {
        Task<ProjectTask> FindByNameAsync(string name);
        Task<ProjectTask> FindByCodeAsync(string code);
        Task<List<ProjectTask>> GetListAsync(int skipCount, int maxResultCount, 
            string sorting, string filter = null);
    }
}
