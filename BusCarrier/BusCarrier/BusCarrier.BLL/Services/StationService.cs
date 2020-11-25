using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusCarrier.BLL.Interfaces;
using BusCarrier.DAL.Interfaces;
using BusCarrier.DAL.Repositories;
using BusCarrier.Domain.Entities;

namespace BusCarrier.BLL.Services
{
    public class StationService : IStationService
    {
        private readonly IServiceRepository serviceRepository;
        private readonly IStationRepository stationRepository;
        private readonly IRepository<ServiceTemplate> serviceTemplateRepository;

        public StationService(IServiceRepository serviceRepository, IStationRepository stationRepository, IRepository<ServiceTemplate> serviceTemplateRepository)
        {
            this.serviceRepository = serviceRepository;
            this.stationRepository = stationRepository;
            this.serviceTemplateRepository = serviceTemplateRepository;
        }

        public async Task CreateServiceAsync(Service service)
        {
            if (service != null)
            {
                await serviceRepository.AddAsync(service);
                await serviceRepository.SaveAsync();
            }
        }
        public async Task<List<Service>> GetServicesAsync()
        {
           return  await serviceRepository.GetAll();
        }
        public async Task DeleteServiceAsync(int id)
        {
            await serviceRepository.Delete(id);
            await serviceRepository.SaveAsync();
        }
        public async Task<Service> GetServiceAsync(int id)
        {
            return await serviceRepository.GetService(id);
        }
        public async Task UpdateServiceAsync(Service service)
        {
            if (service != null)
            {
                serviceRepository.Update(service);
                await serviceRepository.SaveAsync();
            }
        }
        public async Task CreateStationAsync(Station station)
        {
            if (station != null)
            {
                await stationRepository.AddAsync(station);
                await stationRepository.SaveAsync();
            }
        }
        public async Task DeleteStationAsync(int id)
        {
            await stationRepository.Delete(id);
            await stationRepository.SaveAsync();
        }
        public async Task<Station> GetStationWithServicesAsync(int id)
        {
            return await stationRepository.GetStationWithServices(id);
        }
        public async Task<Station> GetStationAsync(int id)
        {
            return await stationRepository.GetByIdAsync(id);
        }

        public async Task<List<Station>> GetStationsAsync()
        {
            return await stationRepository.GetAll();
        }

        public async Task UpdateStationAsync(Station station)
        {
            if (station != null)
            {
                stationRepository.Update(station);
                await stationRepository.SaveAsync();
            }
        }
        public async Task CreateServiceTemplateAsync(ServiceTemplate serviceTemplate)
        {
            if (serviceTemplate != null)
            {
                await serviceTemplateRepository.AddAsync(serviceTemplate);
                await serviceTemplateRepository.SaveAsync();
            }
        }
        public async Task<List<ServiceTemplate>> GetServicesTemplatesAsync()
        {
            return await serviceTemplateRepository.GetAll();
        }
        public async Task DeleteServiceTemplateAsync(int id)
        {
            await serviceTemplateRepository.Delete(id);
            await serviceTemplateRepository.SaveAsync();
        }
        public async Task<ServiceTemplate> GetServiceTemplateAsync(int id)
        {
            return await serviceTemplateRepository.GetByIdAsync(id);
        }
        public async Task UpdateServiceTemplateAsync(ServiceTemplate serviceTemplate)
        {
            if (serviceTemplate != null)
            {
                serviceTemplateRepository.Update(serviceTemplate);
                await serviceTemplateRepository.SaveAsync();
            }
        }
    }
}
