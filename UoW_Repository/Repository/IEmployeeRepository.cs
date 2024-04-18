using System.Collections.Generic;
using UoW_Repository.Models;
using UoW_Repository.Models.ViewModel;

namespace UoW_Repository.Models.Repository
{
    public interface IEmployeeRepository
    {
        object GetColumnNames();
        EmployeesViewModel GetEmployeesData(int pageIndex, int pageSize, string sortColumn, string sortDirection, string searchTerm);

    }
}