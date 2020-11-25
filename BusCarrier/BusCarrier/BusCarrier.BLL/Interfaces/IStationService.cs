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
    }
}
