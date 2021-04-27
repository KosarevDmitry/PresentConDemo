using System.Collections.Generic;

namespace PresentConDemo
{
    public interface IOrder
    {
        int Id { get; set; }
        int CustomerId { get; }
         IList<IProduct> Products { get; set; }
    }
}