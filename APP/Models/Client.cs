using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Models
{
    public class Client
    {
        [Key]
        [Required]
        public int ClientId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Cedula { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string DriverLicense { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nacionality { get; set; }
        [Required]
        [MaxLength(100)]
        public string BloodType { get; set; }
        [Required]
        [MaxLength(500)]
        public string CedulaImage { get; set; }
        [Required]
        [MaxLength(500)]
        public string DriverLicenseImage { get; set; }
    }
}
