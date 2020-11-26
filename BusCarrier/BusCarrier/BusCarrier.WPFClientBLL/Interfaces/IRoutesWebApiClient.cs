using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusCarrier.Domain.Entities;

namespace BusCarrier.WPFClientBLL.Interfaces
{
    public interface IRoutesWebApiClient
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
    }
}
