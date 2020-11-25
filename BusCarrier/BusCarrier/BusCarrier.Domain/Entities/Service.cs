using System;
using System.Collections.Generic;
using System.Text;

namespace BusCarrier.Domain.Entities
{
    public class Service
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
