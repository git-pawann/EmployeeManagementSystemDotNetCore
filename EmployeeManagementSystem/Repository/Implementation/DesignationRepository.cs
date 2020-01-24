using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository.Implementation
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly HimalayaDbContext _context;
        public DesignationRepository(HimalayaDbContext context)
        {
            this._context = context;
        }
        public DesignationModel Add(DesignationModel designaiton) //create
        {
            _context.Designations.Add(designaiton);
            _context.SaveChanges();
            //department.DepartmentId = _context.Max(e => e.id) + 1;
            //_context.Add(department);
            return designaiton;
        }


        public DesignationModel Delete(int id)
        {
            DesignationModel designation = _context.Designations.Find(id);
            if(designation != null)
            {
                _context.Designations.Remove(designation);
                _context.SaveChanges();
            }
            return designation;
        }

        public IEnumerable<DesignationModel> GetAllDesignation()
        {
            return _context.Designations;
        }

        public DesignationModel GetDesignation(int id)
        {
            return _context.Designations.Find(id);
        }

        public DesignationModel Update(DesignationModel designation)
        {
            var desg = _context.Designations.Attach(designation);
            desg.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return designation;
        }
    }
}
