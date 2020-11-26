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
    public class BusCarrierWebApiClient : IBusCarrierWebApiClient
    {
        private readonly WebApisModel config;

        public BusCarrierWebApiClient(WebApisModel config)
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

        public async Task<Station> GetStation(int id)
        {
            var route = $"{config.WebApi}{WebApiRoutes.GET_STATION}{id}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.GET);
            return JsonConvert.DeserializeObject<Station>(await response.Content.ReadAsStringAsync());
        }
        public async Task<List<Station>> GetStations(int id)
        {
            var route = $"{config.WebApi}{WebApiRoutes.GET_STATIONS}{id}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.GET);
            return JsonConvert.DeserializeObject<List<Station>>(await response.Content.ReadAsStringAsync());
        }
        public async Task AddStation(Station station)
        {
            var route = $"{config.WebApi}{WebApiRoutes.ADD_STATION}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.POST, station);
        }
        public async Task UpdateStation(Route station)
        {
            var route = $"{config.WebApi}{WebApiRoutes.UPDATE_STATION}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.PUT, station);
        }
        public async Task DeleteStation(int id)
        {
            var route = $"{config.WebApi}{WebApiRoutes.DELETE_STATION}{id}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.DELETE);
        }

        public async Task<Service> GetService(int id)
        {
            var route = $"{config.WebApi}{WebApiRoutes.GET_SERVICE}{id}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.GET);
            return JsonConvert.DeserializeObject<Service>(await response.Content.ReadAsStringAsync());
        }
        public async Task<List<Service>> GetServices(int id)
        {
            var route = $"{config.WebApi}{WebApiRoutes.GET_SERVICES}{id}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.GET);
            return JsonConvert.DeserializeObject<List<Service>>(await response.Content.ReadAsStringAsync());
        }
        public async Task AddService(Service service)
        {
            var route = $"{config.WebApi}{WebApiRoutes.ADD_SERVICE}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.POST, service);
        }
        public async Task UpdateService(Service service)
        {
            var route = $"{config.WebApi}{WebApiRoutes.UPDATE_SERVICE}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.PUT, service);
        }
        public async Task DeleteService(int id)
        {
            var route = $"{config.WebApi}{WebApiRoutes.DELETE_SERVICE}{id}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.DELETE);
        }

        public async Task<ServiceTemplate> GetServiceTemplate(int id)
        {
            var route = $"{config.WebApi}{WebApiRoutes.GET_SERVICE_TEMPLATE}{id}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.GET);
            return JsonConvert.DeserializeObject<ServiceTemplate>(await response.Content.ReadAsStringAsync());
        }
        public async Task<List<ServiceTemplate>> GetServiceTemplates(int id)
        {
            var route = $"{config.WebApi}{WebApiRoutes.GET_SERVICE_TEMPLATES}{id}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.GET);
            return JsonConvert.DeserializeObject<List<ServiceTemplate>>(await response.Content.ReadAsStringAsync());
        }
        public async Task AddServiceTemplate(ServiceTemplate service)
        {
            var route = $"{config.WebApi}{WebApiRoutes.ADD_SERVICE_TEMPLATE}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.POST, service);
        }
        public async Task UpdateServiceTemplate(ServiceTemplate service)
        {
            var route = $"{config.WebApi}{WebApiRoutes.UPDATE_SERVICE_TEMPLATE}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.PUT, service);
        }
        public async Task DeleteServiceTemplate(int id)
        {
            var route = $"{config.WebApi}{WebApiRoutes.DELETE_SERVICE_TEMPLATE}{id}";
            var response = await RequestExecuter.ExecuteRequest(route, RequestTypes.DELETE);
        }

    }
}
