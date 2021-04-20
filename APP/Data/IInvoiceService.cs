using APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Data
{
    public interface IInvoiceService
    {
        Task<IEnumerable<Invoice>> GetAllInvoice();
        Task<Invoice> GetInvoiceDetails(int id);
        Task<bool> InsertInvoice(Invoice invoice);
        Task<bool> UpdateInvoice(Invoice invoice);
        Task<bool> DeleteInvoice(int id);
        Task<bool> SaveInvoice(Invoice invoice);
    }
}
