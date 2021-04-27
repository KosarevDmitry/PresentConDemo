using System;

namespace PresentConDemo
{
    public interface IProduct
    {
        int Id { get; set; }
        string Description { get; set; }
        int Quantity { get; set; }
        Decimal UnitPrice { get; set; }
        decimal? TaxRate { get; set; }
        decimal TaxAmount { get; set; }
        decimal ExtendedPrice { get; set; }
         int SupplierId { get; set; }
    }
}