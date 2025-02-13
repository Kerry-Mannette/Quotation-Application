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

namespace QuotationApplication.Pages_Services
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly QuotationApplication.Data.ServiceContext _context;

        public DetailsModel(QuotationApplication.Data.ServiceContext context)
        {
            _context = context;
        }

        public Service Service { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service.FirstOrDefaultAsync(m => m.ServiceId == id);

            if (service is not null)
            {
                Service = service;

                return Page();
            }

            return NotFound();
        }
    }
}
