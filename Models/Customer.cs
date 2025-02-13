using System.ComponentModel.DataAnnotations;

namespace QuotationApplication.Models;

public class Customer
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string Email { get; set; }
    public string Fname { get; set; }
     public string Lname { get; set; }
    public string Currency { get; set; }
}