using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusCarrier.Domain.Entities;

namespace BusCarrier.DAL.Interfaces
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task<Service> GetService(int id);
    }
}
