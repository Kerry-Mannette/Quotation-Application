using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuotationApplication.Pages;

[Authorize]
public class StaffModel : PageModel
{
    private readonly ILogger<StaffModel> _logger;

    public StaffModel(ILogger<StaffModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
