using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UoW_Repository.Models;
using UoW_Repository.Models.Repository;

namespace UoW_Repository.Repository.UnityOfWork
{
   public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _dbContext;
    public IEmployeeRepository Employees { get; private set; }
    public IGetEmployeesRepository GetEmployees { get; set; } 


        public UnitOfWork(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
        Employees = new EmployeeRepository(_dbContext);
            GetEmployees = new GetEmployeesRepository(_dbContext);
    }


        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}