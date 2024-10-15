using AutoMapper;
using ProjectManagement.Projects;

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
    }
}
