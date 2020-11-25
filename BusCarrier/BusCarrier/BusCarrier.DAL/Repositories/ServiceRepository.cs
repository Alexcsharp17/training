using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusCarrier.DAL.Interfaces;
using BusCarrier.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusCarrier.DAL.Repositories
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(DbContext context) : base(context)
        {
        }
        public async Task<Service> GetService(int id)
        {
            return await this.context.Set<Service>()
                .Include(s => s.ServiceTemplate)
                .FirstOrDefaultAsync(s => s.Id == id);
        }


    }
}
