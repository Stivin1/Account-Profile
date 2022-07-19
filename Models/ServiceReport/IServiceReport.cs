using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ServiceReport
{
    public interface IServiceReport
    {
        public Task<Report> GetGeneratedFile(string UserId);
    }
}
