using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UoW_Repository.Models;
using UoW_Repository.Models.ViewModel;


namespace UoW_Repository.Repository
{
    public class GetEmployeesRepository : IGetEmployeesRepository
    {
        private readonly DatabaseContext _dbContext;



        public GetEmployeesRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IEnumerable<SelectListItem> GetEmployeeTypes()
        {
            var employeeTypes = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "FrontEnd Developer" },
                new SelectListItem { Value = "2", Text = "BackEnd Developer" },
                new SelectListItem { Value = "3", Text = "Designer" },
                new SelectListItem { Value = "4", Text = "Tester" },
                new SelectListItem { Value = "5", Text = "BDE" },
                new SelectListItem { Value = "6", Text = "HR" },
            };
            return employeeTypes;
        }

        public List<Employees> GetEmployeeData()
        {
            try
            {
                return _dbContext.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpPost]
        public List<Employees> InsertData(EmployeesViewModel model)
        {
            var viewModel = new EmployeesViewModel();

            try
            {
                var employee = new Employees
                {
                    
                    firstName = model.firstName,
                    empCardID = model.empCardID,
                    lastName = model.lastName,
                    age = model.age,
                    gender = model.gender,
                    mobileNumber = model.mobileNumber,
                    email = model.email,
                    employeeType = model.employeeType,
                    joiningDate = model.joiningDate
                };
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
                return _dbContext.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public EmployeesViewModel Edit(string Id)
        {
            try
            {


                int EmpId = Convert.ToInt32(Id);
                var Emp = _dbContext.Employees.Find(EmpId);

                var model = new EmployeesViewModel
                {
                  
                    employeeId = Emp.employeeId,
                    //empCardId = Emp.empCardId,
                    firstName = Emp.firstName,
                    lastName = Emp.lastName,
                    age = Emp.age,
                    gender = Emp.gender,
                    mobileNumber = Emp.mobileNumber,
                    email = Emp.email,
                    employeeType = Emp.employeeType,
                    joiningDate = Emp.joiningDate,
                    employeeTypes = GetEmployeeTypes()
                };
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public EmployeesViewModel Edit(EmployeesViewModel model)
        {
            try
            {
                int employeeId = model.employeeId;
                var data = _dbContext.Employees.Find(employeeId);
                if (data != null)
                {
                
                    data.firstName = model.firstName;
                    //data.empCardId = model.empCardId;
                    data.lastName = model.lastName;
                    data.age = model.age;
                    data.mobileNumber = model.mobileNumber;
                    data.email = model.email;
                    data.gender = model.gender;
                    data.employeeType = model.employeeType;
                    data.joiningDate = model.joiningDate;

                    _dbContext.SaveChanges();

                    return model;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Delete(int Id)
        {
            var data = _dbContext.Employees.Find(Id);

            _dbContext.Employees.Remove(data);
            _dbContext.SaveChanges();
        }

    }



    }
