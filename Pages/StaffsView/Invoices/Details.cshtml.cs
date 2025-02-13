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
    public class DetailsModel : PageModel
    {
        private readonly QuotationApplication.Data.InvoiceContext _context;

        public DetailsModel(QuotationApplication.Data.InvoiceContext context)
        {
            _context = context;
        }

        public Invoice Invoice { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice.FirstOrDefaultAsync(m => m.InvoiceId == id);

            if (invoice is not null)
            {
                Invoice = invoice;

                return Page();
            }

            return NotFound();
        }
    }
}
