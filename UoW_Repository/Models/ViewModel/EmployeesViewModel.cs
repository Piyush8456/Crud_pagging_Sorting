using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace UoW_Repository.Models.ViewModel
{
    public enum EmployeeType
    {
        FullStackDeveloper = 1,
        FrontEndDeveloper = 2,
        BackEndDeveloper = 3,
        Designer = 4,
        Tester = 5,
        HR = 6
    }
    

public class EmployeesViewModel
    {
        [Display(Name = "Employee Id")]
        //[Required(ErrorMessage = "Please Enter Valid Employee Id.")]
        //[Range(1, 9999, ErrorMessage = "Employee Id must be a 4-digit number.")]
        public int employeeId { get; set; }

        [Display(Name = "Employee Card ID")]
        [Required(ErrorMessage = "Please Enter Valid Employee Card ID.")]
        [StringLength(6, MinimumLength = 4)]
        [RegularExpression("(?=.*[a-zA-Z])(?=.*[0-9])[a-zA-Z0-9]*$", ErrorMessage = "The Employee Card ID must contain at least one letter and one number and not allowed special symbol.")]
        public string empCardID { get; set; } 

        [Display(Name = "Firstname")]
        [Required(ErrorMessage = "Please Enter Valid Firstname.")]
        [StringLength(15, MinimumLength = 3)]
        public string firstName { get; set; }

        [Display(Name = "Lastname")]
        [Required(ErrorMessage = "Please Enter Valid Lastname.")]
        [StringLength(15, MinimumLength = 3)]
        public string lastName { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Please Enter Valid Mobile Number.")]
        [StringLength(maximumLength: 12, ErrorMessage = "Mobile Number must be between 10 and 12 digits.")]
        [RegularExpression(@"^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$", ErrorMessage = "Please enter a valid Indian mobile number.")]
        public string mobileNumber { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "Please Enter Valid Age")]
        [Range(18, 60, ErrorMessage = "Age Must Be Between 18 to 60")]
        public int age { get; set; } = 0;

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Enter a Valid Email")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string email { get; set; } = "";

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Must Select The Gender")]
        public string gender { get; set; } = "";

        [Display(Name = "Employee Type")]
        [Required(ErrorMessage = "Must Select The Employee Type")]
        public int employeeType { get; set; } = 0;

        public IEnumerable<SelectListItem> employeeTypes { get; set; }

        [Display(Name = "Joining Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Must Select The Joining Date")]
        public DateTime joiningDate { get; set; } = DateTime.Now;

        public List<Employees> FilteredResult { get; set; }

        //public IEnumerable<SelectListItem> employeeTypes { get; set; }

        public SelectList ColumnNames { get; set; }

        public string SelectedColumnName { get; set; }

        public string SelectedSortOrder { get; set; }

        public List<Employees> PaginatedResult { get; set; }

        public List<Employees> FullResult { get; set; }

        public List<Employees> SerchedTerm { get; set; }
    }
}