using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusCarrier.BLL.Interfaces;
using BusCarrier.DAL.Interfaces;
using BusCarrier.Domain.Entities;

namespace BusCarrier.BLL.Services
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository routeRepository;
        private readonly IRepository<RouteTemplate> routeTemplateRepository;
        public RouteService(IRouteRepository routeRepository, IRepository<RouteTemplate> routeTemplateRepository)
        {
            this.routeRepository = routeRepository;
            this.routeTemplateRepository = routeTemplateRepository;
        }
        public async Task CreateRouteAsync(Route route)
        {
            if (route != null)
            {
                await routeRepository.AddAsync(route);
                await routeRepository.SaveAsync();
            }
        }
        public async Task<List<Route>> GetRoutesAsync()
        {
            return await routeRepository.GetAll();
        }
        public async Task<Route> GetRouteAsync(int id)
        {
            return await routeRepository.GetByIdAsync(id);
        }
        public async Task DeleteRouteAsync(int id)
        {
            await routeRepository.Delete(id);
            await routeRepository.SaveAsync();
        }
        public async Task UpdateRouteAsync(Route route)
        {
            if (route != null)
            {
                routeRepository.Update(route);
                await routeRepository.SaveAsync();
            }
        }
        public async Task<List<RouteTemplate>> GetRouteTemplatesAsync()
        {
            return await routeTemplateRepository.GetAll();
        }
        public async Task<RouteTemplate> GetRouteTemplateAsync(int id)
        {
            return await routeTemplateRepository.GetByIdAsync(id);
        }
        public async Task DeleteRouteTemplateAsync(int id)
        {
            await routeTemplateRepository.Delete(id);
            await routeTemplateRepository.SaveAsync();
        }
        public async Task UpdateRouteTemplateAsync(RouteTemplate routeTemplate)
        {
            if (routeTemplate != null)
            {
                routeTemplateRepository.Update(routeTemplate);
                await routeRepository.SaveAsync();
            }
        }
        public async Task CreateRouteTemplateAsync(RouteTemplate routeTemplate)
        {
            if (routeTemplate != null)
            {
                await routeTemplateRepository.AddAsync(routeTemplate);
                await routeRepository.SaveAsync();
            }
        }

    }
}
