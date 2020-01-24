using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class VacancyModel
    {
        [Key]
        public int VacancyId { get; set; }
        public string VacancyTitle { get; set; }
        public int NoOfPosts { get; set; }
        public string Description { get; set; }
        [ForeignKey ("Designation")]
        public int DesignationID { get; set; }
    }
}
