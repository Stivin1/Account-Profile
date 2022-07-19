using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelControllers.ModelCore
{
    public interface IScopeAvailability
    {
        public RoleManager<IdentityRole> RoleManager { get; set; }
    }
}
