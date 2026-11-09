using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models.Entities
{
    public class Employee
    {
        public Guid Id {get; set;}
        public required string Name {get; set;}
        public required string Email {get; set;}
        public string? Phone {get; set;}
        public decimal Salary {get; set;}

        public required Guid DepartmentId {get; set;}
        public Department Department {get; set;}
    }
}