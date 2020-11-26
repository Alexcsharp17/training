using System;
using System.Collections.Generic;
using System.Text;

namespace BusCarrier.WPFClientBLL.Util
{
    public class WebApiRoutes
    {
        public const string GET_ROUTE = "/api/Routes/GetRoute?id=";
        public const string GET_ROUTES = "/api/Routes/GetRoutes";
        public const string ADD_ROUTE = "/api/Routes/AddRoute";
        public const string UPDATE_ROUTE = "/api/Routes/UpdateRoute";
        public const string DELETE_ROUTE= "/api/Routes/DeleteRoute?id=";

        public const string GET_ROUTE_TEMPLATE = "/api/Routes/GetRouteTemplate?id=";
        public const string GET_ROUTE_TEMPLATES = "/api/Routes/GetRouteTemplates";
        public const string ADD_ROUTE_TEMPLATE = "/api/Routes/AddRouteTemplate";
        public const string UPDATE_ROUTE_TEMPLATE = "/api/Routes/UpdateRouteTemplate";
        public const string DELETE_ROUTE_TEMPLATE = "/api/Routes/DeleteRouteTemplate?id=";

        public const string GET_STATION = "/api/Station/GetStation?id=";
        public const string GET_STATIONS = "/api/Station/GetStations";
        public const string ADD_STATION = "/api/Station/AddStation";
        public const string UPDATE_STATION = "/api/Station/UpdateStation";
        public const string DELETE_STATION = "/api/Station/DeleteStation?id=";

        public const string GET_SERVICE= "/api/Station/GetService?id=";
        public const string GET_SERVICES = "/api/Station/GetServices";
        public const string ADD_SERVICE = "/api/Station/AddService";
        public const string UPDATE_SERVICE = "/api/Station/UpdateService";
        public const string DELETE_SERVICE = "/api/Station/DeleteService?id=";

        public const string GET_SERVICE_TEMPLATE = "/api/Station/GetServiceTemplate?id=";
        public const string GET_SERVICE_TEMPLATES = "/api/Station/GetServiceTemplates";
        public const string ADD_SERVICE_TEMPLATE = "/api/Station/AddServiceTemplate";
        public const string UPDATE_SERVICE_TEMPLATE = "/api/Station/UpdateServiceTemplate";
        public const string DELETE_SERVICE_TEMPLATE = "/api/Station/DeleteServiceTemplate?id=";
    }
}
