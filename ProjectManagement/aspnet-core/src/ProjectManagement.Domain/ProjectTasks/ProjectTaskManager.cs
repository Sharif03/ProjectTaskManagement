using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Services;
using ProjectManagement.Projects;
using Volo.Abp.Domain.Repositories;

namespace ProjectManagement.ProjectTasks
{
    public class ProjectTaskManager : DomainService
    {
        
        //private readonly IProjectTaskRepository _taskRepository;
        private readonly IRepository<ProjectTask, Guid> _repository;
        public ProjectTaskManager(IRepository<ProjectTask, Guid> repository) 
        {
            _repository = repository;
        }

        public async Task<ProjectTask> CreateAsync(string name, string code, Guid projectId, ProjectStatus status, bool isApproved)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            var existingTaskName = await FindByNameAsync(name);
            if (existingTaskName != null)
            {
                throw new ProjectTaskNameAlreadyExistsException(name);
            }

            Check.NotNullOrWhiteSpace(code, nameof(code));
            var existingTaskCode = await FindByCodeAsync(code);
            if (existingTaskCode != null)
            {
                throw new ProjectTaskCodeAlreadyExistsException(code);
            }

            return new ProjectTask(GuidGenerator.Create(), name, code, projectId, (ProjectTaskStatus)status, isApproved);
        }

        public async Task ApproveTaskAsync(ProjectTask projectTask)
        {
            projectTask.ApproveTask(); // Approve the task
        }
        public async Task ChangeNameAsync(ProjectTask task, string newName)
        {
            Check.NotNull(task, nameof(task));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingTask = await FindByNameAsync(newName);
            if (existingTask != null && existingTask.Id != task.Id)
            {
                throw new ProjectTaskNameAlreadyExistsException(newName);
            }

            task.ChangeName(newName);
        }

        public async Task ChangeCodeAsync(ProjectTask task, string newCode)
        {
            Check.NotNull(task, nameof(task));
            Check.NotNullOrWhiteSpace(newCode, nameof(newCode));

            var existingTask = await FindByCodeAsync(newCode);
            if (existingTask != null && existingTask.Id != task.Id)
            {
                throw new ProjectTaskCodeAlreadyExistsException(newCode);
            }

            task.ChangeCode(newCode);
        }

        private async Task<ProjectTask> FindByNameAsync(string name)
        {
            return await _repository.FirstOrDefaultAsync(task => task.Name == name);
        }

        private async Task<ProjectTask> FindByCodeAsync(string code)
        {
            return await _repository.FirstOrDefaultAsync(task => task.Code == code);
        }
    }
}
