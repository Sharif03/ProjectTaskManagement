using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ProjectManagement.ProjectTasks
{
    public interface IProjectTaskAppService : IApplicationService
    {
        Task<ProjectTaskDto> GetAsync(Guid id);
        Task<PagedResultDto<ProjectTaskDto>> GetListAsync(GetProjectTaskListDto input);

        Task<ProjectTaskDto> CreateAsync(CreateProjectTaskDto input);

        Task UpdateAsync(Guid id, UpdateProjectTaskDto input);

        Task DeleteAsync(Guid id);
        // Load project list into task list page to assign project into new task
        Task<ListResultDto<ProjectLookupDto>> GetProjectLookupAsync();
    }
}
