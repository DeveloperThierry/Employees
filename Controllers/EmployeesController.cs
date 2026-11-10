using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using app.Data;
using app.Models;
using app.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var allEmployees = context.Employees.Include(e => e.Department).ToList();
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
            var department = context.Departments.Find(addEmployeeDto.DepartmentId);
            if(department is null) return NotFound("Department not found");
            var employeeEntity = new Employee()
            {
                Name=addEmployeeDto.Name,
                Email=addEmployeeDto.Email,
                Phone=addEmployeeDto.Phone,
                Salary=addEmployeeDto.Salary,
                DepartmentId=addEmployeeDto.DepartmentId
                
            };
            employeeEntity.Department = department;
            context.Employees.Add(employeeEntity);
            context.SaveChanges();
            return Ok(employeeEntity);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = context.Employees.Find(id);
            if(employee is null) return NotFound();
            var department = context.Departments.Find(updateEmployeeDto.DepartmentId);
            if(department is null) return NotFound("Department not found");
            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.DepartmentId = updateEmployeeDto.DepartmentId;
            employee.Department = department;
            context.SaveChanges();
            return Ok(employee);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult RemoveEmployee(Guid id)
        {
            var employee = context.Employees.Find(id);
            if(employee is null) return NotFound();
            context.Employees.Remove(employee);
            context.SaveChanges();
            return Ok();

        }

    }
}