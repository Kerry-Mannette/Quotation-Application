using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuotationApplication.Models;

namespace QuotationApplication.Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext (DbContextOptions<ServiceContext> options)
            : base(options)
        {
        }

        public DbSet<QuotationApplication.Models.Service> Service { get; set; } = default!;
    }
}
