using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarStore.DAL.Entities
{
    public class Order
    {
        public int OrderID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public int CarID { get; set; }

        [Required]
        public int PersonId { get; set; }
    }
}
