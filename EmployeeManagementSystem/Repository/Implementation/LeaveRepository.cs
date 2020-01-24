using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository.Implementation
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly HimalayaDbContext _context;
        public LeaveRepository(HimalayaDbContext context)
        {
            this._context = context;
        }
        public LeaveModel Add(LeaveModel leave)
        {
            _context.Leaves.Add(leave);
            _context.SaveChanges();
            return leave;
        }

        public LeaveModel Delete(int id)
        {
            LeaveModel leave = _context.Leaves.Find(id);
            if (leave != null)
            {
                _context.Leaves.Remove(leave);
                _context.SaveChanges();
            }
            return leave;
        }

        public IEnumerable<LeaveModel> GetAllLeave()
        {
            return _context.Leaves;
        }

        public LeaveModel GetLeave(int id)
        {
            return _context.Leaves.Find(id);
        }

        public LeaveModel Update(LeaveModel leave)
        {
            var lea = _context.Leaves.Attach(leave);
            lea.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return leave;
        }
    }
}
