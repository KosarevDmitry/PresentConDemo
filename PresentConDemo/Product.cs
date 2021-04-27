namespace PresentConDemo
{
    public class Product : IProduct
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal? TaxRate { get; set; }
		public decimal TaxAmount { get; set; }
		public decimal ExtendedPrice { get; set; }
		public int SupplierId  { get; set; }
        
    }

}



