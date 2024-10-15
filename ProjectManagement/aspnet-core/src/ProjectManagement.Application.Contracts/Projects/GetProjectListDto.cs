using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ProjectManagement.Projects
{
    // Add a filter field to DTO for filtering purposes.
    public class GetProjectListDto : PagedAndSortedResultRequestDto
    {
        
        public string? Filter { get; set; }
    }
}
