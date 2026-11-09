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
    public class DepartmentsController(ApplicationDbContext context) : Controller
    {
        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            var departments = context.Departments.ToList();
            return Ok(departments);
        }

        [HttpPost]
        public IActionResult AddDepartment(AddDepartmentDto departmentDto)
        {
            var departmentEntity = new Department()
            {
                Name=departmentDto.Name
            };
            context.Departments.Add(departmentEntity);
            context.SaveChanges();
            return Ok(departmentEntity);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateDepartment(Guid id, UpdateDepartmentDto departmentDto)
        {
            var department = context.Departments.Find(id);
            if(department is null) return NotFound();
            department.Name = departmentDto.Name;
            context.SaveChanges();
            return Ok(department);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult RemoveDepartment(Guid id)
        {
            var department = context.Departments.Find(id);
            if(department is null) return NotFound();
            context.Departments.Remove(department);
            context.SaveChanges();
            return Ok();
        }
    }
}