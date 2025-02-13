using System.ComponentModel.DataAnnotations;

namespace QuotationApplication.Models;

public class Invoice
{
    public int InvoiceId { get; set; }
    public string Customer { get; set; }
    public string Number { get; set; }
    public string Email { get; set; }
    public string AmountDue { get; set; }
    public string Status { get; set; }
    public DateTime Date { get; set; }
    public DateTime ExpireON { get; set; }
}