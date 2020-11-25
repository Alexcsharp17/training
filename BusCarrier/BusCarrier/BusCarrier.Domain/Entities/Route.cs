using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using System.Text;

namespace BusCarrier.Domain.Entities
{
    public class Route
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int RouteTemplateId { get; set; }
        public virtual RouteTemplate RouteTemplate {get; set; }
    }
}
