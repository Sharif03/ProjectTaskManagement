using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace ProjectManagement.ProjectTasks
{
    public class ProjectTaskNameAlreadyExistsException : BusinessException
    {
        public ProjectTaskNameAlreadyExistsException(string name)
        : base(ProjectManagementDomainErrorCodes.ProjectTaskNameAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
