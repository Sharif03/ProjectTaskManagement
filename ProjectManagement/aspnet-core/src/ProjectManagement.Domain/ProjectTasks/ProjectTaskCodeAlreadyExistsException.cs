using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace ProjectManagement.ProjectTasks
{
    public class ProjectTaskCodeAlreadyExistsException : BusinessException
    {
        public ProjectTaskCodeAlreadyExistsException(string code)
        : base(ProjectManagementDomainErrorCodes.ProjectTaskNameAlreadyExists)
        {
            WithData("code", code);
        }
    }
}
