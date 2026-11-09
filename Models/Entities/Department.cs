using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models.Entities
{
    public class Department
    {
        public Guid Id {get; set;}
        public required string Name {get; set;}

    }
}