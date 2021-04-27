namespace PresentConDemo
{
    public interface IPartner
    {
        int Id { get; set; }
        string Name { get; set; }
        bool VATPayer { get; set; }
        int CountryId { get; set; }
    }
}