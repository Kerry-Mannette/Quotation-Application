using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuotationApplication.Models;

namespace QuotationApplication.Data
{
    public class RequestContext : DbContext
    {
        public RequestContext (DbContextOptions<RequestContext> options)
            : base(options)
        {
        }

        public DbSet<QuotationApplication.Models.Request> Request { get; set; } = default!;
    }
}
