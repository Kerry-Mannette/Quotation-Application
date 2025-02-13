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

namespace QuotationApplication.Pages_Quotations
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly QuotationApplication.Data.QuotationContext _context;

        public DetailsModel(QuotationApplication.Data.QuotationContext context)
        {
            _context = context;
        }

        public Quotation Quotation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quotation = await _context.Quotation.FirstOrDefaultAsync(m => m.QuotationId == id);

            if (quotation is not null)
            {
                Quotation = quotation;

                return Page();
            }

            return NotFound();
        }
    }
}
