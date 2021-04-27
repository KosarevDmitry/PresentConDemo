namespace PresentConDemo
{
    public interface ISupplier:IPartner
    {
        string BankAccountName { get; set; }
        string BankAccountBranch { get; set; }
        string BankAccountCode { get; set; }
        string BankAccountNumber { get; set; }
        string BankInternationalCode { get; set; }
        
    }
}