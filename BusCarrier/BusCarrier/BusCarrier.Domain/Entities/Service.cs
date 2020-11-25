using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BusCarrier.Domain.Entities
{
    public class Service
    {
        public int  Id { get; set; }
        public int ServiceTemplateId { get; set; }
        public virtual ServiceTemplate ServiceTemplate { get; set; }
    }
}
