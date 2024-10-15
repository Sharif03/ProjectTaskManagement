using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Projects
{
    public class CreateUpdateProjectDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(128)]
        public string Code { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)] 
        public DateTime StartDate { get; set; } = DateTime.Now;
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } = DateTime.Now;
        [Required]
        public string Description { get; set; }
        [Required]
        public ProjectStatus Status { get; set; }
    }
}
