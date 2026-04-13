using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Dal
{
    public class Vehicle
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string brand { get; set; }
        public int year { get; set; }
        public int mileage { get; set; }

        public decimal price { get; set; }

    }
}
