using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuotationApplication.Models;
using QuotationApplication.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;



namespace QuotationApplication.Pages_Requests
{
    [Authorize]
    public class RequestsModel : PageModel
    {
        private readonly QuotationApplication.Data.RequestContext _context;

        public RequestsModel(QuotationApplication.Data.RequestContext context)
        {
            _context = context;
        }

        public IList<Request> Request { get;set; } = default!;

        public async Task OnGetAsync()
        {
            
      var userName = User.Identity?.Name;
      var requests = from m in _context.Request
                                select m;

          
        requests = requests.Where(s => s.Email!.ToString().Contains(userName));
        
        Request = await requests.ToListAsync();

        }
    }
}
