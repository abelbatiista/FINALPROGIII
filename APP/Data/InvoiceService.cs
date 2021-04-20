using APP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Data
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ContextDB _context;
        public InvoiceService(ContextDB context)
        {
            _context = context;
        }
        public async Task<bool> DeleteInvoice(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            _context.Invoices.Remove(invoice);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoice()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetInvoiceDetails(int id)
        {
            return await _context.Invoices.FindAsync(id);
        }

        public async Task<bool> InsertInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveInvoice(Invoice invoice)
        {
            if (invoice.InvoiceId > 0)
                return await UpdateInvoice(invoice);
            else
                return await InsertInvoice(invoice);
        }

        public async Task<bool> UpdateInvoice(Invoice invoice)
        {
            _context.Entry(invoice).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
