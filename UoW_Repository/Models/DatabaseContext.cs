using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace UoW_Repository.Models
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext() : base("EmployeeDbConnection")
        {
        }
        public DbSet<Employees> Employees { set; get; }
    }
}

