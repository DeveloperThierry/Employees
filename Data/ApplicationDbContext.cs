using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace app.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):DbContext(options)
    {
        public DbSet<Employee> Employees {get; set;}
        public DbSet<Department> Departments {get; set;}
    }
}