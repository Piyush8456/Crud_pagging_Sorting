using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UoW_Repository.Models
{
    public class Employees
    {
        //public enum EmployeeType
        //{
        //    FullStackDeveloper = 1,
        //    FrontEndDeveloper = 2,
        //    BackEndDeveloper = 3,
        //    Designer = 4,
        //    Tester = 5,
        //    HR = 6
        //}

        [Key]
        public int employeeId { get; set; }

        public string empCardID { get; set; } 

        public string firstName { get; set; } 

        public string lastName { get; set; } 

        public string mobileNumber { get; set; } 

        public int age { get; set; }

        public string email { get; set; } = "";

        public string gender { get; set; } = "";

        public int employeeType { get; set; } = 0;

        //public IEnumerable<SelectListItem> employeeTypes { get; set; }

        [DataType(DataType.Date)]
        public DateTime joiningDate { get; set; } =DateTime.Now;
    }


}