using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    public class VacancyController : Controller
    {
        private IVacancyRepository _repository;
        public VacancyController(IVacancyRepository repo)
        {
            _repository = repo;
        }
        public IActionResult Index()
        {
            var data = _repository.GetAllVacancy();
            return View("Index", data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(VacancyModel vac)
        {
            if (ModelState.IsValid)
            {
                VacancyModel vacancy = _repository.Add(vac);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            VacancyModel vacancy = _repository.GetVacancy(id.Value);
            VacancyModel vm = new VacancyModel()
            {
                VacancyId = vacancy.VacancyId,
                VacancyTitle = vacancy.VacancyTitle,
                Description = vacancy.Description,
                DesignationID = vacancy.DesignationID
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(VacancyModel model)
        {
            if (ModelState.IsValid)
            {
                VacancyModel vacancy = _repository.GetVacancy(model.VacancyId);
                vacancy.VacancyTitle = model.VacancyTitle;
                vacancy.Description = model.Description;
                vacancy.DesignationID = model.DesignationID;
                _repository.Update(vacancy);

                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            VacancyModel vacancy = _repository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            VacancyModel vacancy = _repository.GetVacancy(id);
            return View(vacancy);
        }
    }
}
