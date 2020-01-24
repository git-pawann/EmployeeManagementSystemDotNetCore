using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository.Interface
{
    public interface ILeaveRepository
    {
        LeaveModel GetLeave(int id);
        IEnumerable<LeaveModel> GetAllLeave();
        LeaveModel Add(LeaveModel leave);
        LeaveModel Update(LeaveModel leave);
        LeaveModel Delete(int id);
    }
}
