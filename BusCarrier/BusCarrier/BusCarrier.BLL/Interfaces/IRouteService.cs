using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusCarrier.Domain.Entities;

namespace BusCarrier.BLL.Interfaces
{
    public interface IRouteService
    {
        Task CreateRouteAsync(Route route);
        Task<List<Route>> GetRoutesAsync();
        Task<Route> GetRouteAsync(int id);
        Task DeleteRouteAsync(int id);
        Task UpdateRouteAsync(Route route);
        Task<List<RouteTemplate>> GetRouteTemplatesAsync();
        Task<RouteTemplate> GetRouteTemplateAsync(int id);
        Task DeleteRouteTemplateAsync(int id);
        Task UpdateRouteTemplateAsync(RouteTemplate routeTemplate);
        Task CreateRouteTemplateAsync(RouteTemplate routeTemplate);
    }
}
