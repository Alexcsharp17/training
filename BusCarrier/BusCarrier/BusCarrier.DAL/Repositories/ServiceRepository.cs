using System;
using System.Collections.Generic;
using System.Text;
using BusCarrier.DAL.Interfaces;
using BusCarrier.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusCarrier.DAL.Repositories
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(DbContext context) : base(context)
        {
        }
    }
}
