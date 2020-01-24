using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    public class LeaveController : Controller
    {
        private ILeaveRepository _repository;
        public LeaveController(ILeaveRepository repo)
        {
            _repository = repo;
        }
        public IActionResult Index()
        {
            var data = _repository.GetAllLeave();
            return View("Index", data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LeaveModel lev)
        {
            if (ModelState.IsValid)
            {
                LeaveModel leave = _repository.Add(lev);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(int? id)
        {
            LeaveModel leave = _repository.GetLeave(id.Value);
            LeaveModel lm = new LeaveModel()
            {
                LeaveId = leave.LeaveId,
                LeaveType = leave.LeaveType,
                FromDate = leave.FromDate,
                ToDate = leave.ToDate,
                EmployeeId = leave.EmployeeId,
                NoOfDays = leave.NoOfDays,
                Description = leave.Description
            };
            return View(lm);
        }
        [HttpPost]
        public IActionResult Edit(LeaveModel model)
        {
            if (ModelState.IsValid)
            {
                LeaveModel leave = _repository.GetLeave(model.LeaveId);
                leave.LeaveId = model.LeaveId;
                leave.LeaveType = model.LeaveType;
                leave.FromDate = model.FromDate;
                leave.ToDate = model.ToDate;
                leave.EmployeeId = model.EmployeeId;
                leave.NoOfDays = model.NoOfDays;
                leave.Description = model.Description;

                _repository.Update(leave);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            LeaveModel leave = _repository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            LeaveModel leave = _repository.GetLeave(id);
            return View(leave);
        }
    }
}
