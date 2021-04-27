using System;

namespace PresentConDemo
{
    public interface ICountry
    {
        int Id { get; set; }
        string IsoAlpha3Code { get; set; }
        string Name { get; set; }
        decimal TaxRate { get; set; }
        bool EUCountry { get; set; }
    }
}