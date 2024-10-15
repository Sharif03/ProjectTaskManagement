using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;

namespace ProjectManagement.Projects
{
    public class ProjectAppService :
      CrudAppService<
          Project, //The Project entity
          ProjectDto, //Used to show Projects
          Guid, //Primary key of the Project entity
          PagedAndSortedResultRequestDto, //Used for paging/sorting
          CreateUpdateProjectDto>, //Used to create/update a Project
      IProjectAppService //implement the IProjectAppService
    {


        private readonly IRepository<Project, Guid> _projectRepository;
        public ProjectAppService(IRepository<Project, Guid> repository)
            : base(repository)
        {
            _projectRepository = repository;
        }

        public override async Task<ProjectDto> CreateAsync(CreateUpdateProjectDto input)
        {
            // 1. Validate the input for business rules
            await ValidateProjectAsync(input);

            // 2. Call the base method to save the project
            return await base.CreateAsync(input);
        }

        public override async Task<ProjectDto> UpdateAsync(Guid id, CreateUpdateProjectDto input)
        {
            // 1. Validate the input for business rules
            await ValidateProjectAsync(input, id);

            // 2. Call the base method to update the project
            return await base.UpdateAsync(id, input);
        }

        private async Task ValidateProjectAsync(CreateUpdateProjectDto input, Guid? projectId = null)
        {
            // Check for duplicate Name and Code
            var duplicateProject = await _projectRepository.FirstOrDefaultAsync(p =>
                (p.Name.ToLower() == input.Name.ToLower() || p.Code.ToLower() == input.Code.ToLower())
                && (!projectId.HasValue || p.Id != projectId.Value));

            if (duplicateProject != null)
            {
                throw new BusinessException("Project name or code already exists")
                    .WithData("Name", input.Name)
                    .WithData("Code", input.Code);
            }

            // Validate StartDate and EndDate
            if (input.StartDate >= input.EndDate)
            {
                throw new BusinessException("The start date must be earlier than the end date.");
            }
        }

        public async Task<PagedResultDto<ProjectDto>> GetFiteredProjectListAsync(GetProjectListDto input)
        {
            var query = await _projectRepository.GetQueryableAsync();

            // Apply filtering logic
            if (!string.IsNullOrEmpty(input.Filter))
            {
                query = query.Where(p => p.Name.Contains(input.Filter) || p.Code.Contains(input.Filter));
            }

            var totalCount = await AsyncExecuter.CountAsync(query);
            var items = await AsyncExecuter.ToListAsync(query);

            return new PagedResultDto<ProjectDto>(totalCount, ObjectMapper.Map<List<Project>, List<ProjectDto>>(items));
        }

        public override async Task DeleteAsync(Guid id)
        {
            await _projectRepository.DeleteAsync(id);
        }
    }
}
