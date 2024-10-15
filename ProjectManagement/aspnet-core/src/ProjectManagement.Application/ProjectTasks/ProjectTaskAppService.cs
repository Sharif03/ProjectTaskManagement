using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using System.Linq.Dynamic.Core;
using Volo.Abp.ObjectMapping;
using Volo.Abp;
using ProjectManagement.Projects;


namespace ProjectManagement.ProjectTasks
{
    public class ProjectTaskAppService : ProjectManagementAppService, IProjectTaskAppService
    {
        //private readonly IProjectTaskRepository _projectTaskRepository;
        private readonly ProjectTaskManager _projectTaskManager;
        private readonly IRepository<ProjectTask, Guid> _projectTaskRepository;
        private readonly IRepository<Project, Guid> _projectRepository;
        public ProjectTaskAppService(ProjectTaskManager projectTaskManager,
            IRepository<ProjectTask, Guid> projectTaskRepository, IRepository<Project, Guid> projectRepository)
        {
            _projectTaskManager = projectTaskManager;
            _projectTaskRepository = projectTaskRepository;
            _projectRepository = projectRepository;
        }
        public async Task<ProjectTaskDto> GetAsync(Guid id)
        {
            var projectTask = await _projectTaskRepository.GetAsync(id);
            return ObjectMapper.Map<ProjectTask, ProjectTaskDto>(projectTask);
        }

        public async Task<PagedResultDto<ProjectTaskDto>> GetListAsync(GetProjectTaskListDto input)
        {
            var query = await _projectTaskRepository.GetQueryableAsync();

            // Join with Project to get ProjectName
            var projectQuery = from task in query
                               join project in await _projectRepository.GetQueryableAsync()
                               on task.ProjectId equals project.Id
                               select new { task, project };

            // Filter by ProjectIds
            if (input.ProjectIds != null && input.ProjectIds.Count > 0)
            {
                projectQuery = projectQuery.Where(p => input.ProjectIds.Contains(p.project.Id));
            }

            // Apply filtering logic for name and code
            if (!string.IsNullOrEmpty(input.Filter))
            {
                projectQuery = projectQuery.Where(p => p.task.Name.Contains(input.Filter) || p.task.Code.Contains(input.Filter));
            }

            // Apply sorting on project name when it loading
            projectQuery = projectQuery.OrderBy(p => p.task.Name); // Ensure we are ordering the projectQuery


            // Calculate total count before pagination
            var totalCount = await AsyncExecuter.CountAsync(projectQuery);

            // Apply pagination
            var pagedQuery = projectQuery.Skip(input.SkipCount).Take(input.MaxResultCount);

            // Retrieve the final list of tasks
            var items = await AsyncExecuter.ToListAsync(pagedQuery);

            var projectTaskDtos = items.Select(i => new ProjectTaskDto
            {
                Id = i.task.Id,
                Name = i.task.Name,
                Code = i.task.Code,
                Status = i.task.Status,
                ProjectName = i.project.Name, // Set the ProjectName here
                IsApproved = i.task.IsApproved
            }).ToList();

            return new PagedResultDto<ProjectTaskDto>(totalCount, projectTaskDtos);
        }
        public async Task<ProjectTaskDto> CreateAsync(CreateProjectTaskDto input)
        {
            var projectTask = await _projectTaskManager.CreateAsync(
                input.Name,
                input.Code,
                input.ProjectId,
                (ProjectStatus)input.Status,
                input.IsApproved
            );

            await _projectTaskRepository.InsertAsync(projectTask);
            var result = ObjectMapper.Map<ProjectTask, ProjectTaskDto>(projectTask);

            return result;
        }
        public async Task UpdateAsync(Guid id, UpdateProjectTaskDto input)
        {
            var projectTask = await _projectTaskRepository.GetAsync(id);

            if (projectTask.Name != input.Name)
            {
                await _projectTaskManager.ChangeNameAsync(projectTask, input.Name);
            }

            if (projectTask.Code != input.Code)
            {
                await _projectTaskManager.ChangeCodeAsync(projectTask, input.Code);
            }

            projectTask.Status = input.Status;
            projectTask.ProjectId = input.ProjectId;

            await _projectTaskRepository.UpdateAsync(projectTask);
        }
        public async Task DeleteAsync(Guid id)
        {
            await _projectTaskRepository.DeleteAsync(id);
        }

        // Get project list
        public async Task<ListResultDto<ProjectLookupDto>> GetProjectLookupAsync()
        {
            var projects = await _projectRepository.GetListAsync();
            var result = new ListResultDto<ProjectLookupDto>(ObjectMapper.Map<List<Project>, List<ProjectLookupDto>>(projects));

            return result;
        }

        // Method to approve the task
        public async Task ApproveTaskAsync(Guid id)
        {
            var projectTask = await _projectTaskRepository.GetAsync(id);
            if(projectTask == null)
            {
                throw new BusinessException("No project task selected for approval");
            }
            projectTask.IsApproved = true;
            await _projectTaskRepository.UpdateAsync(projectTask);
        }

    }
}
