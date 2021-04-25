using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCRUD.Models
{
    public class EmployeeListDbContext : DbContext
    {
        public EmployeeListDbContext(DbContextOptions<EmployeeListDbContext> options)
            : base(options)
        {
        }

        public DbSet<AngularCRUD.Models.EmployeeList> EmployeeList { get; set; }
    }
}
