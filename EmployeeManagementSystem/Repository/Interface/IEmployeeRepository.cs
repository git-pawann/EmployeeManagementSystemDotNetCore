using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository.Interface
{
    public interface IEmployeeRepository
    {
        EmployeeModel GetEmployee(int id);
        IEnumerable<EmployeeModel> GetAllEmployee();
        EmployeeModel Add(EmployeeModel employee);
        EmployeeModel Update(EmployeeModel employee);
        EmployeeModel Delete(int id);
    }
}
