using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository.Interface
{
    public interface IDepartmentRepository
    {
        DepartmentModel GetDepartment(int id);
        IEnumerable<DepartmentModel> GetAllDepartment();
        DepartmentModel Add(DepartmentModel department);
        DepartmentModel Update(DepartmentModel department);
        DepartmentModel Delete(int id);

    }
}
