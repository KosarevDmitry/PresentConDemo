using System.Collections.Generic;

namespace PresentConDemo
{
  public  class DataSet : IDataSet
    {

        public IList<ICustomer> Customers { get; set; }
        public IList<ICountry> Countries { get; set; }
        public IList<IOrder> Orders { get; set; }
        public IList<ISupplier> Suppliers{ get; set; }
        public IList<IProduct> Products { get; set; }
        
    }

}



