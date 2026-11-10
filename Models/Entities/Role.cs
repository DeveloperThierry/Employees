using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models.Entities
{
    public class Role
    {
        public Guid Id {get; set;}
        public required string Title {get; set;}
        public string? Description {get; set;}
    }
}