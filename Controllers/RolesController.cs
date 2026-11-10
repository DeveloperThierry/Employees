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

        [HttpPost]
        public IActionResult AddRole(AddRoleDto roleDto)
        {
            var roleEntity = new Role()
            {
                Title=roleDto.Title,
                Description=roleDto.Description
            };
            context.Roles.Add(roleEntity);
            context.SaveChanges();
            return Ok(roleEntity);
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
            context.Roles.Remove(role);
            context.SaveChanges();
            return Ok();
        }
    }
}