using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Models
{
    public class Invoice
    {
        [Key]
        [Required]
        public int InvoiceId { get; set; }
        [Required]
        public int BookingId { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public double AmountPaid { get; set; }
    }
}
