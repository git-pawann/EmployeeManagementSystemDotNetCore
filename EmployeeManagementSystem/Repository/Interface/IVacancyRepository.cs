using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository.Interface
{
    public interface IVacancyRepository
    {
        VacancyModel GetVacancy(int id);
        IEnumerable<VacancyModel> GetAllVacancy();
        VacancyModel Add(VacancyModel vacancy);
        VacancyModel Update(VacancyModel vacancy);
        VacancyModel Delete(int id);
    }
}
