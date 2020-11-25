using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace BusCarrier.Domain.Entities
{
    public class Station
    {
        public int Id { get; set; }    
        private string Name { get; set; }

        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public virtual ICollection<Station> Services { get; set; }
    }
}
