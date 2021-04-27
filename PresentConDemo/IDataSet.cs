using System.Collections.Generic;

namespace PresentConDemo
{
  public  interface IDataSet
    {
        IList<ICountry> Countries { get; set; }
        IList<ICustomer> Customers { get; set; }
        IList<IOrder> Orders { get; set; }
        IList<ISupplier> Suppliers { get; set; }
        IList<IProduct> Products { get; set; }
    }
}