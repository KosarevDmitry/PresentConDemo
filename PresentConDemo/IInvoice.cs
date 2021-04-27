using System;
using System.Collections.Generic;

namespace PresentConDemo
{
   public interface IInvoice {
		IEnumerable<IProduct> Products { get; set; }
		Customer Customer { get; set; }
		public decimal TaxAmount { get; set; }
		public decimal ExtendedPrice { get; set; }
	}

}



