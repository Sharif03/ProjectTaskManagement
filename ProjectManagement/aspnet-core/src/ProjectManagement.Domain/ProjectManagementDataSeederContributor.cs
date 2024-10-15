using ProjectManagement.Projects;
using ProjectManagement.ProjectTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ProjectManagement
{
    public class ProjectManagementDataSeederContributor
    : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Project, Guid> _projectRepository;
        private readonly IRepository<ProjectTask, Guid> _projectTaskRepository;
        public ProjectManagementDataSeederContributor(IRepository<Project, Guid> projectRepository,
            IRepository<ProjectTask, Guid> projectTaskRepository)
        {
            _projectRepository = projectRepository;
            _projectTaskRepository = projectTaskRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _projectRepository.GetCountAsync() <= 0) 
            {
                // Projects data seeding
                var libraryProject = await _projectRepository.InsertAsync(
                    new Project
                    {
                        Name = "Library Management",
                        Code = "LM1",
                        StartDate = new DateTime(2024, 1, 1),
                        EndDate = new DateTime(2024, 5, 30),
                        Description = "Digital process of library management",
                        Status = ProjectStatus.New
                    },
                    autoSave: true
                );

                var taskProject = await _projectRepository.InsertAsync(
                    new Project
                    {
                        Name = "Task Management",
                        Code = "TM1",
                        StartDate = new DateTime(2024, 6, 1),
                        EndDate = new DateTime(2024, 12, 31),
                        Description = "Digital process of task management",
                        Status = ProjectStatus.New
                    },
                    autoSave: true
                );

                // Project tasks data seeding
                var task1 = new ProjectTask(Guid.NewGuid(), "Create Book entity", "CB1", libraryProject.Id, ProjectTaskStatus.New, false);
                await _projectTaskRepository.InsertAsync(task1, autoSave: true);

                var task2 = new ProjectTask(Guid.NewGuid(), "Create Task entity", "CT1", taskProject.Id, ProjectTaskStatus.New, false);
                await _projectTaskRepository.InsertAsync(task2, autoSave: true);
            }
        }
    }
}
