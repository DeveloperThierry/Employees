using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using app.Data;
using app.Models;
using app.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(ApplicationDbContext context) : Controller
    {
       [HttpGet]
       public IActionResult GetAllEmployees()
        {
            var allEmployees = context.Employees.ToList();
            return Ok(allEmployees);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = context.Employees.Find(id);
            if(employee is null) return NotFound();
            return Ok(employee);
        }


        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee()
            {
                Name=addEmployeeDto.Name,
                Email=addEmployeeDto.Email,
                Phone=addEmployeeDto.Phone,
                Salary=addEmployeeDto.Salary
            };
            context.Employees.Add(employeeEntity);
            context.SaveChanges();
            return Ok(employeeEntity);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = context.Employees.Find(id);
            if(employee is null) return NotFound();
            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            context.SaveChanges();
            return Ok(employee);
        }

    }
}