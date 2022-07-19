using Microsoft.EntityFrameworkCore;
using OpenSourceEntitys.Models.EntityConfiguration.EntitySystem.ApplicationContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceEntitys.Models.ServiceReport
{
    public class ServiceProfileReport : IServiceReport
    {
        private EntitySourceContext EntitySourceContext { get; set; }

        public ServiceProfileReport
            (
            EntitySourceContext EntitySourceContext
            )
        {
            this.EntitySourceContext = EntitySourceContext;
        }

        public async Task<Report> GetGeneratedFile(string UserId)
        {
            var profilelist = await EntitySourceContext.Loggings.Include(t => t.User).Include(t => t.loggingInformation)
               .Include(t => t.User).Where(t => t.UserId == UserId && t.LoggingInformationId == 19).ToListAsync();

            byte[] rep = null;

            string text = null;

            foreach (var list in profilelist)
            {
                rep = Encoding.UTF8.GetBytes($"{list.User.UserName,-0}\t{list.loggingInformation.Name,-60}\t{list.DateCreate,-80}\n");

                text += Encoding.UTF8.GetString(rep);

            }
            Report Report = new Report
            {
                Reports = Encoding.UTF8.GetBytes(string.IsNullOrEmpty(text) ? "Данные отсутствуют" : text),
                Types = "text/plan"
            };

            return Report;
        }
    }
}
