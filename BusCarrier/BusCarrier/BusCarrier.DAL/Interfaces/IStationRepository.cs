using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusCarrier.Domain.Entities;

namespace BusCarrier.DAL.Interfaces
{
    public interface IStationRepository : IRepository<Station>
    {
        Task<Station> GetStationWithServices(int id);
    }
}
