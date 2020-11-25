using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusCarrier.DAL.Interfaces;
using BusCarrier.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusCarrier.DAL.Repositories
{
    public class StationRepository : Repository<Station>, IStationRepository
    {
        public StationRepository(DbContext context) : base(context)
        {
        }
        public async Task<Station> GetStationWithServices(int id)
        {
            return await this.context.Set<Station>()
                .Include(s => s.Services)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
