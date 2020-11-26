using System;
using System.Collections.Generic;
using System.Text;
using BusCarrier.WPFClientBLL.Interfaces;

namespace BusCarrier.WPFClientBLL.Services
{
    public class RouteManagmentService
    {
        private IRoutesWebApiClient routesWebApiClient;
        public RouteManagmentService(IRoutesWebApiClient routesWebApiClient)
        {
            this.routesWebApiClient = routesWebApiClient;
        }
    }
}
