using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository.Implementation;
using EmployeeManagementSystem.Repository.Interface;
//using EmployeeManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        //dependency injection
        private IDepartmentRepository _repository;
        public DepartmentController(IDepartmentRepository repo)
        {
            _repository = repo;
        }
        public IActionResult Index()
        {
            var data = _repository.GetAllDepartment();
            return View("Index", data);
            
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentModel dep)
        {
            if (ModelState.IsValid)
            {
                DepartmentModel department = _repository.Add(dep);
                return RedirectToAction("Index");

                
                //    DepartmentModel department = new DepartmentModel()
                //    {
                //        DepartmentId = model.DepartmentId,
                //        DepartmentName = model.DepartmentName,
                //        Description = model.Description
                //    };
                //    _repository.Add(department);
                //    return RedirectToAction("DepartmentModel");
                //}
                //return View(model);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            DepartmentModel department = _repository.GetDepartment(id.Value);
            DepartmentModel devm = new DepartmentModel()
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName,
                Description = department.Description
            };
            return View(devm);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                DepartmentModel department = _repository.GetDepartment(model.DepartmentId);
                department.DepartmentId = model.DepartmentId;
                department.DepartmentName = model.DepartmentName;
                department.Description = model.Description;
                _repository.Update(department);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            DepartmentModel department = _repository.Delete(id);
            return RedirectToAction("Index");
            
        }
        public IActionResult Details(int id)
        {
            DepartmentModel department = _repository.GetDepartment(id);
            return View(department);
            

        }
    }
}
