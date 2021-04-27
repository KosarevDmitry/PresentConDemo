using System.Collections.Generic;

namespace PresentConDemo
{
    public class Invoice : IInvoice
	{
		public IEnumerable<IProduct> Products { get; set; }
		public Customer Customer { get; set; }
		public decimal TaxAmount { get; set; }
		public decimal ExtendedPrice { get; set; }
	}

}



