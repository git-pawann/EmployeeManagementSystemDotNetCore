using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository.Interface
{
    public interface ISalaryRepository
    {
        SalaryModel GetSalry(int id);
        IEnumerable<SalaryModel> GetAllSalary();
        SalaryModel Add(SalaryModel salary);
        SalaryModel Update(SalaryModel salary);
        SalaryModel Delete(int id);
    }
}
