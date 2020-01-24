using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class DepartmentModel
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        [Display (Name = "Department name")]
        public string DepartmentName { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

    }
}
