using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarStore.DAL.Entities
{
    public class Person
    {
        public int PersonID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        public string LastName { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}
