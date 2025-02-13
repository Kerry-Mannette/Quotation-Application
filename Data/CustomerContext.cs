using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuotationApplication.Models;

namespace QuotationApplication.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext (DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        public DbSet<QuotationApplication.Models.Customer> Customer { get; set; } = default!;
    }
}
