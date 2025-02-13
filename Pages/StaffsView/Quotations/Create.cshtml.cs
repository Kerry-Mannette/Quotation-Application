using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuotationApplication.Data;
using QuotationApplication.Models;

namespace QuotationApplication.Pages_Quotations
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly QuotationApplication.Data.QuotationContext _context;
        private readonly QuotationApplication.Data.ServiceContext __context;
        public CreateModel(QuotationApplication.Data.QuotationContext context, QuotationApplication.Data.ServiceContext ___context)
        {
            _context = context;
            __context = ___context;
        }

        [BindProperty]
        public Quotation Quotation { get; set; } = default!;
        // public Service Service { get;set; } = default!;


         public IList<Service> Service { get;set; } = default!;
        public async Task<IActionResult> OnGetAsync(int ? id)
        {

            // if (id == null)
            // {
            //     return NotFound();
            // }

            // var service =  await __context.Service.FirstOrDefaultAsync(m => m.ServiceId == id);
            // if (service == null)
            // {
            //     return NotFound();
            // }
            // Service = service;


            var services = from m in __context.Service
                                select m;

            if (id!=null)
            {
                services = services.Where(s => s.ServiceId!.ToString().Contains(id.ToString()));
        
            }

           Service = await services.ToListAsync();
             return Page();
             
        }
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Quotation.Add(Quotation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
