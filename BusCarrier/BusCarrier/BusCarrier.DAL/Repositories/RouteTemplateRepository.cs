using System;
using System.Collections.Generic;
using System.Text;
using BusCarrier.DAL.Interfaces;
using BusCarrier.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusCarrier.DAL.Repositories
{
    public class RouteTemplateRepository : Repository<RouteTemplate>, IRouteTemplateRepository
    {
        public RouteTemplateRepository(DbContext context) : base(context)
        {
        }
    }
}
