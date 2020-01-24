using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository.Implementation;
using EmployeeManagementSystem.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    public class DesignationController : Controller
    {
        private IDesignationRepository _repository;
        public DesignationController(IDesignationRepository repo)
        {
            _repository = repo;
                
        }
        public IActionResult Index()
        {
            var data = _repository.GetAllDesignation();
            return View("Index", data);
            
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DesignationModel des)
        {
            if (ModelState.IsValid)
            {
                DesignationModel designation = _repository.Add(des);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            DesignationModel designation = _repository.GetDesignation(id.Value);
            DesignationModel dm = new DesignationModel()
            {
                DesignationID = designation.DesignationID,
                DesignationName = designation.DesignationName,
                Description = designation.Description
            };
            return View(dm);
        }
        [HttpPost]
        public IActionResult Edit(DesignationModel model)
        {
            if (ModelState.IsValid)
            {
                DesignationModel designation = _repository.GetDesignation(model.DesignationID);
                designation.DesignationID = model.DesignationID;
                designation.DesignationName = model.DesignationName;
                designation.Description = model.Description;
                _repository.Update(designation);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            DesignationModel designation = _repository.Delete(id);
            return RedirectToAction("Index");

        }
        public IActionResult Details(int id)
        {
            DesignationModel designation = _repository.GetDesignation(id);
            return View(designation);

        }
    }
}
