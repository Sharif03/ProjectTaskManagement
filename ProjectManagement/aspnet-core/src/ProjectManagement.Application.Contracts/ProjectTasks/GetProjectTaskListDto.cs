using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ProjectManagement.ProjectTasks
{
    public class GetProjectTaskListDto : PagedAndSortedResultRequestDto
    {
        public List<Guid> ProjectIds { get; set; } = new List<Guid>(); // Multi-project filter
        public string? Filter { get; set; } // search name & code
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
