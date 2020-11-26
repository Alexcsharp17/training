using System;
using System.Collections.Generic;
using System.Text;
using BusCarrier.WPFClientBLL.Interfaces;

namespace BusCarrier.WPFClientBLL.Services
{
    public class RouteManagmentService
    {
        private IBusCarrierWebApiClient webApiClient;
        public RouteManagmentService(IBusCarrierWebApiClient webApiClient)
        {
            this.webApiClient = webApiClient;
        }
    }
}
