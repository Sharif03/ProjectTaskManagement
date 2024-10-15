using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ProjectManagement.ProjectTasks
{
    public class ProjectLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
