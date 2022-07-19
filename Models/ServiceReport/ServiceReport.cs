using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ServiceReport
{
    public class ServiceReport
    {
        private IServiceReport IServiceReport { get; set; }

        public ServiceReport(IServiceReport IServiceReport)
        {
            this.IServiceReport = IServiceReport;
        }

        public Task<Report> GetGeneratedFile(string UserId)
        {
            return IServiceReport.GetGeneratedFile(UserId);
        }
    }
}
