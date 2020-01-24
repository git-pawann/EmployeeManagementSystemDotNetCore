using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private HimalayaDbContext _context;
        public EmployeeRepository(HimalayaDbContext Context)
        {
            _context = Context;
        }
        public EmployeeModel Add(EmployeeModel employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return employee;
        }

        public EmployeeModel Delete(int id)
        {
            EmployeeModel employee = _context.Employees.Find(id);
            if(employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            return _context.Employees;
        }

        public EmployeeModel GetEmployee(int id)
        {
            return _context.Employees.Find(id);
        }

        public EmployeeModel Update(EmployeeModel employee)
        {
            var emp = _context.Employees.Attach(employee);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return employee;
        }
    }
}
