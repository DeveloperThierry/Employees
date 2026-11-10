using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using app.Data;
using app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace app.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController(ApplicationDbContext context) : Controller
    {
       [HttpGet]
       public IActionResult GetAllRoles()
        {
            var roles = context.Roles.ToList();
            return Ok(roles);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetRoleById(Guid id)
        {
            var role = context.Roles.Find(id);
            if(role is null) return NotFound();
            return Ok(role);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateRole(Guid id, UpdateRoleDto roleDto)
        {
            var role = context.Roles.Find(id);
            if(role is null) return NotFound();
            role.Title = roleDto.Title;
            role.Description = roleDto.Description;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteRole(Guid id)
        {
            var role = context.Roles.Find(id);
            if(role is null) return NotFound();
            context.Remove(role);
            return Ok();
        }
    }
}