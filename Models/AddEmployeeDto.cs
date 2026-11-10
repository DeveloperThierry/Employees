using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public class AddEmployeeDto
    {
        public required string Name {get; set;}
        public required string Email {get; set;}
        public string? Phone {get; set;}
        public decimal Salary {get; set;}
        public Guid DepartmentId {get; set;}
        public Guid RoleId {get; set;}
    }
}