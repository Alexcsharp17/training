using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusCarrier.Domain.Entities;

namespace BusCarrier.BLL.Interfaces
{
    public interface IStationService
    {
        Task CreateServiceAsync(Service service);
        Task<List<Service>> GetServicesAsync();
        Task DeleteServiceAsync(int id);
        Task<Service> GetServiceAsync(int id);
        Task UpdateServiceAsync(Service service);
        Task CreateStationAsync(Station station);
        Task DeleteStationAsync(int id);
        Task<Station> GetStationWithServicesAsync(int id);
        Task<Station> GetStationAsync(int id);
        Task<List<Station>> GetStationsAsync();
        Task UpdateStationAsync(Station station);
        Task CreateServiceTemplateAsync(ServiceTemplate serviceTemplate);
        Task<List<ServiceTemplate>> GetServicesTemplatesAsync();
        Task DeleteServiceTemplateAsync(int id);
        Task<ServiceTemplate> GetServiceTemplateAsync(int id);
        Task UpdateServiceTemplateAsync(ServiceTemplate serviceTemplate);
    }
}
