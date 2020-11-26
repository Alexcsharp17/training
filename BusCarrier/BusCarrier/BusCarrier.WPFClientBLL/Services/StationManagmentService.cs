using System;
using System.Collections.Generic;
using System.Text;
using BusCarrier.WPFClientBLL.Interfaces;

namespace BusCarrier.WPFClientBLL.Services
{
    public class StationManagmentService
    {
        private IBusCarrierWebApiClient webApiClient;
        public StationManagmentService(IBusCarrierWebApiClient webApiClient)
        {
            this.webApiClient = webApiClient;
        }
    }
}
