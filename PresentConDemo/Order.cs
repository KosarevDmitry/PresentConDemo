using System;
using System.Collections.Generic;

namespace PresentConDemo
{
    public class Order : IOrder
    {  static  private int _id =0;
        public int Id { get; set; }
        public int CustomerId { get;  set; }
        private DateTime _date { get; set; }
        public IList<IProduct> Products { get; set; }
        public Order(int customerId)
        {
          Id=  ++_id;
            CustomerId = customerId;
            _date = DateTime.Now;
             Products = new List<IProduct>();
    }

        
        //	public	Single VAT { get;set; }
        //	set {
        //		int countryId = context.Customer.Where(x => x.CustomerId == CustomerId).CountryId;
        //		value = context.Country.Where(x = x.Id == Country).VAT;
        //	}
        //	get;
        //	single TotalPrice PriceWithoutVat* VAT;

    }

}



