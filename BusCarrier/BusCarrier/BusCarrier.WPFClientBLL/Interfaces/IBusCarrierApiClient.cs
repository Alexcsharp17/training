using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusCarrier.Domain.Entities;

namespace BusCarrier.WPFClientBLL.Interfaces
{
    public interface IBusCarrierWebApiClient
    {
        Task<Route> GetRoute(int id);
        Task<List<Route>> GetRoutes(int id);
        Task AddRoute(Route newRoute);
        Task UpdateRoute(Route updateRoute);
        Task DeleteRoute(int id);
        Task<RouteTemplate> GetRouteTemplate(int id);
        Task<List<Route>> GetRouteTemplates(int id);
        Task AddRouteTemplate(RouteTemplate newRoute);
        Task UpdateRouteTemplate(RouteTemplate updateRoute);
        Task DeleteRouteTemplate(int id);
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
