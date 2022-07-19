using Microsoft.AspNetCore.Identity;
using OpenSourceEntitys.Models.ModelControllers.ModelCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ModelCore
{
    public class ScopeAvailability : IScopeAvailability
    {
        public RoleManager<IdentityRole> RoleManager { get; set; }
    }
}
