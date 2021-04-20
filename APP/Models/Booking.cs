using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Models
{
    public class Booking
    {
        [Key]
        [Required]
        public int BookingId { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int VehicleId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
