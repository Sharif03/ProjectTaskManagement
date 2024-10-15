using ProjectManagement.Projects;
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
        public ProjectManagementDataSeederContributor(IRepository<Project, Guid> projectRepository)
        {
            _projectRepository = projectRepository;
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
            }
        }
    }
}
