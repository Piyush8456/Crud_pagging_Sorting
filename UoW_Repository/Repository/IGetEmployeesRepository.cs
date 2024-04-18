using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UoW_Repository.Models;
using UoW_Repository.Models.ViewModel;

namespace UoW_Repository.Repository
{
    public interface IGetEmployeesRepository
    {
        List<Employees> GetEmployeeData();
        List<Employees> InsertData(EmployeesViewModel viewModel);
        EmployeesViewModel Edit(string Id);
        EmployeesViewModel Edit(EmployeesViewModel model);
        void Delete(int Id);
    };
}