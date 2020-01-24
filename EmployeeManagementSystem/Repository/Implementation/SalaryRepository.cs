using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository.Implementation
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly HimalayaDbContext _context;
        public SalaryRepository(HimalayaDbContext context)
        {
            this._context = context;
        }
        public SalaryModel Add(SalaryModel salary)
        {
            _context.Salaries.Add(salary);
            _context.SaveChanges();
            return salary;
        }

        public SalaryModel Delete(int id)
        {
            SalaryModel salary = _context.Salaries.Find(id);
            if(salary != null)
            {
                _context.Salaries.Remove(salary);
                _context.SaveChanges();
            }
            return salary;
        }

        public IEnumerable<SalaryModel> GetAllSalary()
        {
            return _context.Salaries;
        }

        public SalaryModel GetSalry(int id)
        {
            return _context.Salaries.Find(id);
        }

        public SalaryModel Update(SalaryModel salary)
        {
            var sal = _context.Salaries.Attach(salary);
            sal.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return salary;
        }
    }
}
