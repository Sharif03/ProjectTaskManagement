using AutoMapper;
using ProjectManagement.Projects;
using ProjectManagement.ProjectTasks;

namespace ProjectManagement;

public class ProjectManagementApplicationAutoMapperProfile : Profile
{
    public ProjectManagementApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Project, ProjectDto>();
        CreateMap<CreateUpdateProjectDto, Project>();

        CreateMap<ProjectTask, ProjectTaskDto>();
        CreateMap<Project, ProjectLookupDto>();
    }
}
