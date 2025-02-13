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
    public class SelectionModel : PageModel
    {
        private readonly QuotationApplication.Data.QuotationContext _context;
        private readonly QuotationApplication.Data.ServiceContext __context;

        public SelectionModel(QuotationApplication.Data.QuotationContext context, QuotationApplication.Data.ServiceContext ___context)
        {
            _context = context;
             __context = ___context;
        }

        public IList<Quotation> Quotation { get;set; } = default!;

        public IList<Service> Service { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Service = await __context.Service.ToListAsync();
        }
    }
}
