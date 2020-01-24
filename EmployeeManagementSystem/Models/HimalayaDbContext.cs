using EmployeeManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class HimalayaDbContext : IdentityDbContext
    {
        public HimalayaDbContext(DbContextOptions<HimalayaDbContext> options) : base(options)
        {

        }
        public DbSet<DepartmentModel> Departments { set; get; }
        public DbSet<DesignationModel> Designations { set; get; }
        public DbSet<VacancyModel> Vacancies { set; get; }
        public DbSet<EmployeeModel> Employees { set; get; }
        public DbSet<LeaveModel> Leaves { set; get; }
        public DbSet<SalaryModel> Salaries { set; get; }
        public DbSet<LoginViewModel> Login { get; set; }
        public DbSet<RegisterViewModel> Register { get; set; }
    }
   
}
