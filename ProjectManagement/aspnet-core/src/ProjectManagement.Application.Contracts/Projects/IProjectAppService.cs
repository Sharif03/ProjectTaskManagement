using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ProjectManagement.Projects
{
    public interface IProjectAppService : 
        ICrudAppService< //Defines CRUD methods
        ProjectDto, //Used to show projects
        Guid, //Primary key of the project entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateProjectDto> //Used to create/update a project
    {

    }
}   
