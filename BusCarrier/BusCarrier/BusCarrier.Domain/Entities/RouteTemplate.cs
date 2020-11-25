using System;
using System.Collections.Generic;
using System.Text;

namespace BusCarrier.Domain.Entities
{
    public class RouteTemplate
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Station> Stations { get; set; }
    }
}
