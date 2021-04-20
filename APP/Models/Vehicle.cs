using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Models
{
    public class Vehicle
    {
        [Key]
        [Required]
        public int VehicleId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Brand { get; set; }
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        [MaxLength(100)]
        public string Color { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [MaxLength(100)]
        public string Kind { get; set; }
        [Required]
        public double ChargeCapacity { get; set; }
        [Required]
        public int PassengersNumber { get; set; }
        [Required]
        [MaxLength(100)]
        public string Enrollment { get; set; }
        [Required]
        [MaxLength(100)]
        public string SecureNumber { get; set; }
        [Required]
        [MaxLength(500)]
        public string Image { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Length { get; set; }
    }
}
