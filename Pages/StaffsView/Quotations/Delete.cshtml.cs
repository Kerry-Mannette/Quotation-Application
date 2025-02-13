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
    public class DeleteModel : PageModel
    {
        private readonly QuotationApplication.Data.QuotationContext _context;

        public DeleteModel(QuotationApplication.Data.QuotationContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quotation = await _context.Quotation.FindAsync(id);
            if (quotation != null)
            {
                Quotation = quotation;
                _context.Quotation.Remove(Quotation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
