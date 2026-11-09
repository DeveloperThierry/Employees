using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public class UpdateEmployeeDto
    {
        public required string Name {get; set;}
        public required string Email {get; set;}
        public string? Phone {get; set;}
        public Guid DepartmentId {get; set;}

    }
}