using System.ComponentModel.DataAnnotations;

namespace QuotationApplication.Models;

public class Quotation
{
    public int QuotationId { get; set; }
    public string Service { get; set; }
    public string Description { get; set; }
    public string Quantity { get; set; }
     public string Price { get; set; }
    public string Tax { get; set; }
    public string Amount{ get; set; }
    public string Status{ get; set; }
    public DateTime Date { get; set; }
    public DateTime ExpireON { get; set; }
}