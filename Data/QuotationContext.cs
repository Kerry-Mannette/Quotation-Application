using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuotationApplication.Models;

namespace QuotationApplication.Data
{
    public class QuotationContext : DbContext
    {
        public QuotationContext (DbContextOptions<QuotationContext> options)
            : base(options)
        {
        }

        public DbSet<QuotationApplication.Models.Quotation> Quotation { get; set; } = default!;
    }
}
