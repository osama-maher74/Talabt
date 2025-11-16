using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LinkDev.Talabat.Domain.Entites.Identity
{
    public class ApplicationUser: IdentityUser
    {
        public required string DisplayName { get; set; }
        public virtual Address? Address { get; set; }
    }
}
