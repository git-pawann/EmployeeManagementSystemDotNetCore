using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _repository;
        public EmployeeController(IEmployeeRepository repo)
        {
            _repository = repo;
        }
        public IActionResult Index()
        {
            var data = _repository.GetAllEmployee();
            return View("Index", data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeModel emp)
        {
            if (ModelState.IsValid)
            {
                EmployeeModel employee = _repository.Add(emp);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        [Authorize]
        public IActionResult Edit(int? id)
        {
            EmployeeModel employee = _repository.GetEmployee(id.Value);
            EmployeeModel em = new EmployeeModel()
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                Email = employee.Email,
                DepartmentId = employee.DepartmentId,
                DesignationID = employee.DesignationID,
                Address = employee.Address,
                Gender = employee.Gender,
                Date = employee.Date
            };
            return View(em);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                EmployeeModel employee = _repository.GetEmployee(model.EmployeeId);
                employee.EmployeeId = model.EmployeeId;
                employee.EmployeeName = model.EmployeeName;
                employee.DepartmentId = model.DepartmentId;
                employee.DesignationID = model.DesignationID;
                employee.Email = model.Email;
                employee.Address = model.Address;
                employee.Gender = model.Gender;
                employee.Date = model.Date;

                _repository.Update(employee);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            EmployeeModel employee = _repository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            EmployeeModel employee = _repository.GetEmployee(id);
            return View(employee);
        }
    }
}
