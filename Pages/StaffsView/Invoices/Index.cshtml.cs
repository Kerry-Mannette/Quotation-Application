using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuotationApplication.Data;
using QuotationApplication.Models;

namespace QuotationApplication.Pages_Invoices
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly QuotationApplication.Data.InvoiceContext _context;

        public IndexModel(QuotationApplication.Data.InvoiceContext context)
        {
            _context = context;
        }

        public IList<Invoice> Invoice { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Invoice = await _context.Invoice.ToListAsync();
        }
    }
}
