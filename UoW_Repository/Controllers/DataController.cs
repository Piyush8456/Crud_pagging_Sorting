using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UoW_Repository.Models;
using UoW_Repository.Models.ViewModel;
using UoW_Repository.Repository.UnityOfWork;

namespace UoW_Repository.Controllers
{

    public class DataController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly DatabaseContext _dbContext;

        public DataController()
        {
            _dbContext = new DatabaseContext();
            _unitOfWork = new UnitOfWork(_dbContext);
        }

        public ActionResult Sp_Data(int? page, string sortColumn, string sortDirection, string searchString)
        {
            var columnNames = _unitOfWork.Employees.GetColumnNames();
            return View(columnNames);

        }


        public ActionResult GetEmployees()
        {
            try
            {
                var allData = _unitOfWork.GetEmployees.GetEmployeeData();

                var viewModel = new List<EmployeesViewModel>
                {
                     new EmployeesViewModel
                     {
                        FilteredResult = allData
                     }
                };
                return View(viewModel);

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpGet]
        public ActionResult InsertData()
        {
            try
            {
                var model = new EmployeesViewModel
                {
                    employeeTypes = GetEmployeeTypes()
                };
                return View(model);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }


        IEnumerable<SelectListItem> GetEmployeeTypes()
        {
            var employeeTypes = new List<SelectListItem>
    {
        //new SelectListItem { Value = "0", Text = "--Select Employee Type--" },
        new SelectListItem { Value = "1", Text = "FrontEnd Devloper" },
        new SelectListItem { Value = "2", Text = "BackEnd Devloper" },
        new SelectListItem { Value = "3", Text = "Designer" },
        new SelectListItem { Value = "4", Text = "Tester" },
        new SelectListItem { Value = "5", Text = "BDE" },
        new SelectListItem { Value = "6", Text = "HR" },
    };
            return employeeTypes;
        }

        [HttpPost]
        public ActionResult InsertData(EmployeesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var insertedEmployees = _unitOfWork.GetEmployees.InsertData(model);
                    _unitOfWork.Save();
                    TempData["AlertMessage"] = "Data Added Successfully....!";

                    return RedirectToAction("Sp_Data", "Data");
                }
                else
                {

                    return Json(new { success = false, message = "Invalid data. Please check your inputs." });
                }
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = "An error occurred while inserting employee data", error = ex.Message });
            }
        }



        public ActionResult SpData(int pageNumber, int pageSize, string sortColumn, string sortDirection, string searchTerm)
          {
            try
            {
                if (TempData["AlertMessage"] != null)
                {
                    ViewBag.AlertMessage = TempData["AlertMessage"];
                }
                var ViewModel = _unitOfWork.Employees.GetEmployeesData(pageNumber, pageSize, sortColumn, sortDirection, searchTerm);
                Console.WriteLine(ViewModel);
                return Json(ViewModel, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }

        }
        public ActionResult Edit(string Id)
        {
            try
            {
                var model = _unitOfWork.GetEmployees.Edit(Id);
                return View(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpPost]
        public ActionResult Edit(EmployeesViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var updatedViewModel = _unitOfWork.GetEmployees.Edit(viewModel);
                    if (updatedViewModel != null)
                    {

                        return RedirectToAction("Sp_Data", "Data");
                    }
                    else
                    {
                        return RedirectToAction("Error", "Data");
                    }
                }
                catch (Exception ex)
                {

                    return RedirectToAction("Error", "Data");
                }
            }
            else
            {
                return View(viewModel);
            }
        }

        public ActionResult Delete(int Id)
        {
            _unitOfWork.GetEmployees.Delete(Id);

            return RedirectToAction("Sp_Data");
        }



    }
}