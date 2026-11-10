using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public class AddRoleDto
    {
        public required string Title {get; set;}
        public string? Description {get; set;}
    }
}