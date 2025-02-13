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

namespace QuotationApplication.Pages_Requests
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly QuotationApplication.Data.RequestContext _context;

        public DetailsModel(QuotationApplication.Data.RequestContext context)
        {
            _context = context;
        }

        public Request Request { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Request.FirstOrDefaultAsync(m => m.RequestId == id);

            if (request is not null)
            {
                Request = request;

                return Page();
            }

            return NotFound();
        }
    }
}
