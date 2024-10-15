using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ProjectManagement.ProjectTasks
{
    public class ProjectTask : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid ProjectId { get; set; }
        public ProjectTaskStatus Status { get; set; }
        public bool IsApproved { get; set; } // Add ApprovalStatus property

        private ProjectTask(Guid guid)
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        public ProjectTask(Guid id, string name, string code, Guid projectId, ProjectTaskStatus status, bool isApproved) : base(id)
        {
            SetName(name);
            SetCode(code);
            ProjectId = projectId;
            Status = status;
            IsApproved = isApproved;
        }
        public void ApproveTask()
        {
            IsApproved = true; // Approve task
        }
        internal ProjectTask ChangeName(string name)
        {
            SetName(name);
            return this;
        }
        internal ProjectTask ChangeCode(string code)
        {
            SetCode(code);
            return this;
        }

        private void SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), maxLength: ProjectTaskConsts.MaxNameLength);
        }

        private void SetCode(string code)
        {
            Code = Check.NotNullOrWhiteSpace(code, nameof(code), maxLength: ProjectTaskConsts.MaxNameLength);
        }
    }
}
