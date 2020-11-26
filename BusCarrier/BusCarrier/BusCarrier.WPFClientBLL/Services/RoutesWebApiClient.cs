using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusCarrier.Domain.Entities;
using BusCarrier.WPFClientBLL.Interfaces;
using BusCarrier.WPFClientBLL.Model;
using BusCarrier.WPFClientBLL.Util;
using Newtonsoft.Json;

namespace BusCarrier.WPFClientBLL.Services
{
    class RoutesWebApiClient : IRoutesWebApiClient
    {
        private readonly WebApisModel config;

        public RoutesWebApiClient(WebApisModel config)
        {
            this.config = config;
        }

        public async Task<Route> GetRoute(int id)
        {
            var route = $"{config.WebApi}{WebApiRoutes.GET_ROUTE}{id}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.GET);
            return JsonConvert.DeserializeObject<Route>(await response.Content.ReadAsStringAsync());
        }
        public async Task<List<Route>> GetRoutes(int id)
        {
            var route = $"{config.WebApi}{WebApiRoutes.GET_ROUTES}{id}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.GET);
            return JsonConvert.DeserializeObject<List<Route>>(await response.Content.ReadAsStringAsync());
        }
        public async Task AddRoute(Route newRoute)
        {
            var route = $"{config.WebApi}{WebApiRoutes.ADD_ROUTE}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.POST, newRoute);
        }
        public async Task UpdateRoute(Route updateRoute)
        {
            var route = $"{config.WebApi}{WebApiRoutes.UPDATE_ROUTE}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.PUT, updateRoute);
        }
        public async Task DeleteRoute(int id)
        {
            var route = $"{config.WebApi}{WebApiRoutes.DELETE_ROUTE}{id}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.DELETE);
        }

        public async Task<RouteTemplate> GetRouteTemplate(int id)
        {
            var route = $"{config.WebApi}{WebApiRoutes.GET_ROUTE_TEMPLATE}{id}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.GET);
            return JsonConvert.DeserializeObject<RouteTemplate>(await response.Content.ReadAsStringAsync());
        }
        public async Task<List<Route>> GetRouteTemplates(int id)
        {
            var route = $"{config.WebApi}{WebApiRoutes.GET_ROUTE_TEMPLATES}{id}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.GET);
            return JsonConvert.DeserializeObject<List<Route>>(await response.Content.ReadAsStringAsync());
        }
        public async Task AddRouteTemplate(RouteTemplate newRoute)
        {
            var route = $"{config.WebApi}{WebApiRoutes.ADD_ROUTE_TEMPLATE}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.POST, newRoute);
        }
        public async Task UpdateRouteTemplate(RouteTemplate updateRoute)
        {
            var route = $"{config.WebApi}{WebApiRoutes.UPDATE_ROUTE_TEMPLATE}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.PUT, updateRoute);
        }
        public async Task DeleteRouteTemplate(int id)
        {
            var route = $"{config.WebApi}{WebApiRoutes.DELETE_ROUTE_TEMPLATE}{id}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.DELETE);
        }

    }
}
