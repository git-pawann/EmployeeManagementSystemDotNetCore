using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository.Interface
{
    public interface IDesignationRepository
    {
        DesignationModel GetDesignation(int id);
        IEnumerable<DesignationModel> GetAllDesignation();
        DesignationModel Add(DesignationModel designation);
        DesignationModel Update(DesignationModel designation);
        DesignationModel Delete(int id);
    }
}
