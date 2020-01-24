using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository.Implementation
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HimalayaDbContext _context;
        public DepartmentRepository(HimalayaDbContext Context)
        {
            this._context = Context;
        }
        public DepartmentModel Add(DepartmentModel department) //create
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
             //department.DepartmentId = _context.Max(e => e.id) + 1;
            //_context.Add(department);
            return department;
        }

        public DepartmentModel Delete(int id)  //delete
        {
            DepartmentModel department = _context.Departments.Find(id);
            if(department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();

            }
            return department;
        }

        public IEnumerable<DepartmentModel> GetAllDepartment() // index
        {
            return _context.Departments;
        }

        public DepartmentModel GetDepartment(int id) // details
        {
            return _context.Departments.Find(id);
        }

        public DepartmentModel Update(DepartmentModel department) // edit
        {
            var depart = _context.Departments.Attach(department);
            depart.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return department;
        }
    }
}
