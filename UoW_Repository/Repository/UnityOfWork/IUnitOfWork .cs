using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UoW_Repository.Models.Repository;


namespace UoW_Repository.Repository.UnityOfWork
{
    public interface IUnitOfWork :IDisposable
    {
        IEmployeeRepository Employees { get; }
        IGetEmployeesRepository GetEmployees { get; }
        void Save();
    }
}