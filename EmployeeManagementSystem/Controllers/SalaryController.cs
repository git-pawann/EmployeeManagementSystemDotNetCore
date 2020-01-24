using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    public class SalaryController : Controller
    {
        private ISalaryRepository _repository;
        public SalaryController(ISalaryRepository repo)
        {
            _repository = repo;
        }
        public IActionResult Index()
        {
            var data = _repository.GetAllSalary();
            return View("Index", data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SalaryModel sal)
        {
            if (ModelState.IsValid)
            {
                SalaryModel salary = _repository.Add(sal);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            SalaryModel salary = _repository.GetSalry(id.Value);
            SalaryModel sm = new SalaryModel()
            {
                SalaryId = salary.SalaryId,
                EmployeeId = salary.EmployeeId,
                DepartmentId = salary.DepartmentId,
                Amount = salary.Amount
            };
            return View(sm);
        }
        [HttpPost]
        public IActionResult Edit(SalaryModel model)
        {
            if (ModelState.IsValid)
            {
                SalaryModel salary = _repository.GetSalry(model.SalaryId);
                salary.SalaryId = model.SalaryId;
                salary.EmployeeId = model.EmployeeId;
                salary.DepartmentId = model.DepartmentId;
                salary.Amount = model.Amount;

                _repository.Update(salary);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            SalaryModel salary = _repository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            SalaryModel salary = _repository.GetSalry(id);
            return View(salary);
        }
    }
}
