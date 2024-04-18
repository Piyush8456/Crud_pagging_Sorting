using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UoW_Repository.Models;
using System.Linq.Dynamic.Core;
using UoW_Repository.Models.ViewModel;
using System.Web.Mvc;
using System.Data.Entity;
using UoW_Repository.Models.Repository;

namespace UoW_Repository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseContext _dbContext;


        public EmployeeRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public object GetColumnNames()
        {
            EmployeesViewModel empsData = new EmployeesViewModel();

            var columns = typeof(Employees).GetProperties().Select(p => p.Name).ToList();

            empsData.ColumnNames = new SelectList(columns);

            return empsData;
        }

        public EmployeesViewModel GetEmployeesData(int pageIndex, int pageSize, string sortColumn, string sortDirection, string searchTerm)
        {
            try
            {
                int pageNumber = pageIndex;

                var fullResult = _dbContext.Database.SqlQuery<Employees>("exec Emps_Data").ToList();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    fullResult = fullResult.Where(e => e.firstName.Contains(searchTerm) ||
                                                       e.lastName.Contains(searchTerm) ||
                                                       e.mobileNumber.Contains(searchTerm)).ToList();
                }

                var orderedResult = fullResult.AsQueryable().OrderBy(sortColumn + " " + sortDirection);
                var filteredResult = orderedResult
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();


                var viewModel = new EmployeesViewModel
                {
                    FilteredResult = filteredResult.ToList(),
                    FullResult = fullResult,
                    SelectedColumnName = sortColumn,
                    SelectedSortOrder = sortDirection,
                    SerchedTerm = fullResult
                };
                return viewModel;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new EmployeesViewModel();
            }
        }

    }

}
