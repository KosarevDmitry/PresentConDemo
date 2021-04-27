namespace PresentConDemo
{
    public class Supplier : ISupplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  bool VATPayer { get; set; }
        public int CountryId { get; set; }
		public string BankAccountName { get; set; }
		public string BankAccountBranch { get; set; }
		public string BankAccountCode { get; set; }
		public string BankAccountNumber { get; set; }
		public string BankInternationalCode { get; set; }
	}

}



