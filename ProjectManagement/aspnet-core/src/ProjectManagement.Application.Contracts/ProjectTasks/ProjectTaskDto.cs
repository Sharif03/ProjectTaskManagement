using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ProjectManagement.ProjectTasks
{
    public class ProjectTaskDto : EntityDto<Guid>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        [Required]
        public ProjectTaskStatus Status { get; set; }
        public bool IsApproved { get; set; } // Include in the DTO
    }
}
