namespace PresentConDemo
{
    public class Customer : ICustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool VATPayer { get; set; }
        public int  CountryId { get; set; }
		public string DeliveryAddress { get; set; }
		
	}

}



