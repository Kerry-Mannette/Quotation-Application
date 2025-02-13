
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
using Microsoft.Extensions.Configuration;

namespace QuotationApplication.Pages_Customers
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly QuotationApplication.Data.CustomerContext _context;

      private readonly IConfiguration Configuration;

        public IndexModel(CustomerContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

         public string NameSort { get; set; }
        public string EmailSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Customer> Customers { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            EmailSort = sortOrder == "Email" ? "email_desc":"";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
             CurrentFilter = searchString;

            IQueryable<Customer> customers= from s in _context.Customer
                                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                customers= customers.Where(s => s.Fname.Contains(searchString)
                                       || s.Lname.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    customers= customers.OrderByDescending(s => s.CustomerName);
                    break;
                case "email_desc":
                    customers= customers.OrderByDescending(s => s.Email);
                    break;
                default:
                    customers= customers.OrderBy(s => s.CustomerId);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Customers = await PaginatedList<Customer>.CreateAsync(
                customers.AsNoTracking(), pageIndex ?? 1, pageSize);
        }         
    }
}
