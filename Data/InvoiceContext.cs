using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuotationApplication.Models;

namespace QuotationApplication.Data
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext (DbContextOptions<InvoiceContext> options)
            : base(options)
        {
        }

        public DbSet<QuotationApplication.Models.Invoice> Invoice { get; set; } = default!;
    }
}
