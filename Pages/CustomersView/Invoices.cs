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
    public class InvoicesModel : PageModel
    {
        private readonly QuotationApplication.Data.InvoiceContext _context;

        public InvoicesModel(QuotationApplication.Data.InvoiceContext context)
        {
            _context = context;
        }

        public IList<Invoice> Invoice { get;set; } = default!;

        public async Task OnGetAsync()
        {

                       
      var userName = User.Identity?.Name;
      var invoices = from m in _context.Invoice
                                select m;

          
        invoices = invoices.Where(s => s.Email!.ToString().Contains(userName));
        
        Invoice = await invoices.ToListAsync();
           
        }
    }
}
