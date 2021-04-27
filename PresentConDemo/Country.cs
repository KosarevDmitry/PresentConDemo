using System.Collections;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace PresentConDemo
{

    public class Country : ICountry
    {
        public int Id { get; set; }
        public string Name { get; set; }
		public string IsoAlpha3Code { get; set; }
		public decimal TaxRate { get; set; }
        public bool EUCountry { get ; set; }
    }

}



