using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class LeaveModel
    {
        [Key]
        public int LeaveId { get; set; }
        public string LeaveType { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public int NoOfDays { get; set; }
        public string Description { get; set; }
    }
}
