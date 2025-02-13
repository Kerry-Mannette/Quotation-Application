using System.ComponentModel.DataAnnotations;

namespace QuotationApplication.Models;

public class Request
{
    public int RequestId { get; set; }
    public string Service { get; set; }
    public string Email { get; set; }
    public string Fname { get; set; }
    public string Lname { get; set; }
    public string Status { get; set; }
}