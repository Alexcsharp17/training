using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusCarrier.BLL.Interfaces;
using BusCarrier.DAL.Interfaces;
using BusCarrier.Domain.Entities;

namespace BusCarrier.BLL.Services
{
    public class StationService : IStationService
    {
        private readonly IRepository<Service> serviceRepository;

        public StationService(IRepository<Service> serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }

        public async Task CreateServiceAsync(Service service)
        {
            if (service != null)
            {
                await serviceRepository.AddAsync(service);
                await serviceRepository.SaveAsync();
            }
        }

        public async Task DeleteServiceAsync(int id)
        {
            await serviceRepository.Delete(id);
            await serviceRepository.SaveAsync();
        }
    }
}
