using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository.Implementation
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly HimalayaDbContext _context;
        public VacancyRepository(HimalayaDbContext Context)
        {
            this._context = Context;
        }
        public VacancyModel Add(VacancyModel vacancy)
        {
            _context.Vacancies.Add(vacancy);
            _context.SaveChanges();
            return vacancy;
        }

        public VacancyModel Delete(int id)
        {
            VacancyModel vacancy = _context.Vacancies.Find(id);
            if(vacancy != null)
            {
                _context.Vacancies.Remove(vacancy);
                _context.SaveChanges();
            }
            return vacancy;
        }

        public IEnumerable<VacancyModel> GetAllVacancy()
        {
            return _context.Vacancies;
        }

        public VacancyModel GetVacancy(int id)
        {
            return _context.Vacancies.Find(id);
        }

        public VacancyModel Update(VacancyModel vacancy)
        {
            var vac = _context.Vacancies.Attach(vacancy);
            vac.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return vacancy;
        }
    }
}
