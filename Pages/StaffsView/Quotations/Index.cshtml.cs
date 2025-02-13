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
    public class IndexModel : PageModel
    {
        private readonly QuotationApplication.Data.QuotationContext _context;

        public IndexModel(QuotationApplication.Data.QuotationContext context)
        {
            _context = context;
        }

        public IList<Quotation> Quotation { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
         public string? searchOne { get; set; }

        public async Task OnGetAsync()
        {
            var quotation = from m in _context.Quotation
                                select m;

            if (!String.IsNullOrEmpty(searchOne))
            {
                quotation = quotation.Where(s => s.Status!.ToString().Contains(searchOne));
        
            }

           Quotation = await quotation.ToListAsync();
            
        }
    }
}
