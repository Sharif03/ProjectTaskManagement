using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.ProjectTasks
{
    public class CreateProjectTaskDto
    {
        [Required]
        [StringLength(ProjectTaskConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(ProjectTaskConsts.MaxNameLength)]
        public string Code { get; set; }
        public Guid ProjectId { get; set; }
        public ProjectTaskStatus Status { get; set; }
        public bool IsApproved { get; set; } = false; // Default not approved
    }
}
