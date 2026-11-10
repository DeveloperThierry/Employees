using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public class UpdateRoleDto
    {
        public required string Title {get; set;}
        public string? Description {get; set;}
    }
}