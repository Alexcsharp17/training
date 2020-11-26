using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusCarrier.Domain.Entities;

namespace BusCarrier.WPFClientBLL.Interfaces
{
    public interface IStationsWebApiClient
    {
        Task<Station> GetStation(int id);
        Task<List<Station>> GetStations(int id);
        Task AddStation(Station station);
        Task UpdateStation(Route station);
        Task DeleteStation(int id);
        Task<Service> GetService(int id);
        Task<List<Service>> GetServices(int id);
        Task AddService(Service service);
        Task UpdateService(Service service);
        Task DeleteService(int id);
        Task<ServiceTemplate> GetServiceTemplate(int id);
        Task<List<ServiceTemplate>> GetServiceTemplates(int id);
        Task AddServiceTemplate(ServiceTemplate service);
        Task UpdateServiceTemplate(ServiceTemplate service);
        Task DeleteServiceTemplate(int id);
    }
}
