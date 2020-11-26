using System;
using System.Collections.Generic;
using System.Text;
using BusCarrier.WPFClientBLL.Interfaces;

namespace BusCarrier.WPFClientBLL.Services
{
    public class StationManagmentService
    {
        private IStationsWebApiClient stationsWebApiClient;
        public StationManagmentService(IStationsWebApiClient stationsWebApiClient)
        {
            this.stationsWebApiClient=stationsWebApiClient;
        }
    }
}
