using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace PresentConDemo
{
    public class ServiceProvider
	{
		private static bool _vatPayer { get; set; }
		private IDataSet _dataSet;
		private ICountry Country { get;  set; }
		private ILog Log { get;  set; }
		public ServiceProvider(bool vatPayer, ICountry country, ILog log, IDataSet dataset)
		{
			_vatPayer = vatPayer;
			_dataSet = dataset;
			Country = country;
			Log = log;
		}
	
		public IInvoice CreateInvoice(int orderId)
		{
			IOrder order = null;
			ICustomer customer = null;
			ICountry country = null;
			IList<ISupplier> suppliers = null;
			try
			{
				order = _dataSet.Orders.Single(x => x.Id == orderId);
				customer = _dataSet.Customers.SingleOrDefault(x => x.Id == order.CustomerId);
				country = _dataSet.Countries.SingleOrDefault(x => x.Id == customer.CountryId);
				suppliers  = _dataSet.Suppliers;
			}
			catch(Exception ex) 
			{
				Log.Write(ex.Message);
				throw new Exception(ex.Message,ex.InnerException);
			}
				IInvoice invoice = new Invoice();
			
			
			foreach (Product product in order.Products)
			{
				///When the service provider is not a VAT payer - VAT is not calculated on the amount of the order.
				if (!_vatPayer)
				{
					Calculate(product, null);
					continue;
				}
				//Where the supplier is a not VAT payer 
				if (!suppliers.SingleOrDefault(x=>x.Id==product.SupplierId).VATPayer)
				{
					Calculate(product, null);
					continue;
				}
				//Where the supplier is a VAT payer and the customer outside the EU - VAT is 0 %
				//or
				//Where the supplier is a VAT payer and the customer lives in the EU,
				//is a VAT payer but lives in a different country from the service provider. 0% reverse charge applies.
				if ( !country.EUCountry ||
						(country.EUCountry && customer.VATPayer && country.Id != this.Country.Id)
				   )
					{
						Calculate(product, 0);
						continue;
					}

					//Where the supplier is a VAT payer and the customer lives in the EU, is not a VAT payer, but lives in a different country from the service provider.
					// VAT x% is applied, where x is the percentage of VAT applied in that country, for example: Lithuania 21% VAT
					//	or
					//Where the supplier is a VAT payer and  when the customer and the service provider
					//live in the same country, VAT always applies
					if ((country.EUCountry && !customer.VATPayer && country.Id != this.Country.Id) ||
						(country.Id == this.Country.Id)
					   )
					{
						Calculate(product, country.TaxRate);
						continue;
					}
				
			}
			invoice.TaxAmount = order.Products.Sum(x => x.TaxAmount);
			invoice.ExtendedPrice = order.Products.Sum(x => x.ExtendedPrice);
			return invoice;
		}

		void Print(int orderId)
		{
			throw new NotImplementedException();
		}

		private void Calculate(Product product, decimal? taxRate) {
			decimal totalPrice = product.Quantity * product.UnitPrice;
			product.TaxRate = taxRate;
			product.TaxAmount = totalPrice * (taxRate??0 / 100);
			product.ExtendedPrice = totalPrice + product.TaxAmount;
		}

	}

}



